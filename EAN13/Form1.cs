using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace EAN13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtbx_input_data_TextChanged(object sender, EventArgs e)
        {
            bool flag = false;
            
            //977 shows 2
            //978 and 979 show 5 but 9790 none

            if (txtbx_input_data.Text.Length >= 3)
            {
                if (txtbx_input_data.Text.Substring(0, 3) == "977") //ISSN
                {
                    txtbx_input_extended_data.MaxLength = 2; // Set to 2 items only
                    flag = true; //show items
                }
                else if ((txtbx_input_data.Text.Substring(0, 3) == "978") || (txtbx_input_data.Text.Substring(0, 3) == "979")) //IBSN and ISMN
                {
                    txtbx_input_extended_data.MaxLength = 5;
                    
                    if ((txtbx_input_data.Text.Length >= 4)&&(txtbx_input_data.Text.Substring(0, 4) == "9790") )//ISMN
                    {
                        flag = false; //Music has no extended
                        txtbx_input_extended_data.Text = ""; //remove anything already there
                    }
                    else
                    {
                        flag = true; //show items
                    }
                }
                
                if (flag) // Do we show extended?
                {
                    lbl_extended_data.Visible = txtbx_input_extended_data.Visible = true;
                    flag = false;
                }
                else
                {
                    lbl_extended_data.Visible = txtbx_input_extended_data.Visible = false;
                }
            }
            else
            {
                lbl_extended_data.Visible = txtbx_input_extended_data.Visible = false;
                txtbx_input_extended_data.Text = "";
            }
            
            CalculateBarCode(); //draw it etc
        }


        private void CalculateBarCode()
        {
            string BarCode, CheckDigit;

            rchtxtbx_output.Clear();
            rchtxtbx_data_plus_checkdigit.Text = lbl_RawBarCode.Text = lbl_output.Text = "";

            if (txtbx_input_data.Text != "") // we decide to draw the extended or not here
            {
                if ((lbl_extended_data.Visible) && (txtbx_input_data.Text.Length >= 3) &&
                    (txtbx_input_data.Text.Substring(0, 3) == "977"))
                { //shows when we have 977 but is restricted to 2 digits.
                    lbl_RawBarCode.Text = lbl_output.Text = EAN13Class.EAN13(txtbx_input_data.Text.PadRight(12, '0')) +
                                                            EAN13Class.ExtendedData(txtbx_input_extended_data.Text);
                }
                  else if (lbl_extended_data.Visible && txtbx_input_data.Text.Length >= 3 && txtbx_input_extended_data.Text.Length == 5 &&
                           (txtbx_input_data.Text.Substring(0, 3) == "978"|| txtbx_input_data.Text.Substring(0, 3) == "979"))
                { //only show if we have 5 digits in extended
                    lbl_RawBarCode.Text = lbl_output.Text = EAN13Class.EAN13(txtbx_input_data.Text.PadRight(12, '0')) +
                                                            EAN13Class.ExtendedData(txtbx_input_extended_data.Text);
                    if ((txtbx_input_data.Text.Length >= 4) && (txtbx_input_data.Text.Substring(0, 4) == "9790")) //ISMN does not have extended
                    {
                        lbl_RawBarCode.Text = lbl_output.Text = EAN13Class.EAN13(txtbx_input_data.Text.PadRight(12, '0'));
                    }
                }
                else
                {// these have no extended
                    lbl_RawBarCode.Text = lbl_output.Text = EAN13Class.EAN13(txtbx_input_data.Text.PadRight(12, '0'));
                }

                //center the barcode in the panel
                CenterLabel();

                if (!String.Equals(EAN13Class.Barcode13Digits, "") || (EAN13Class.Barcode13Digits != ""))
                {
                    rchtxtbx_data_plus_checkdigit.Text = EAN13Class.Barcode13Digits + txtbx_input_extended_data.Text;

                    // Show CheckDigit in red
                    ChangeTextColor.ChangeColor(rchtxtbx_data_plus_checkdigit, 12);
                }


            }
        }

        private void CenterLabel()
        {
            int x, y;

            //center the barcode in the panel both x and y
            x = (panel1.Size.Width - lbl_output.Size.Width) / 2;
            y = (panel1.Size.Height - lbl_output.Size.Height) / 2;

            lbl_output.Location = new Point(x, y);
        }

        private void btn_make_image_Click(object sender, EventArgs e)
        {
           SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Png files (*.png)|*.png|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var path = saveFileDialog1.FileName;

               var bitmap = new Bitmap(lbl_output.Size.Width, lbl_output.Size.Height);
                lbl_output.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                bitmap.Save(path, ImageFormat.Png);
            }
        }

        private void btn_decipher_Click(object sender, EventArgs e)
        {
            rchtxtbx_output.Clear();

            string _countryCode = rchtxtbx_data_plus_checkdigit.Text.Substring(0, 3);


            if ((int.Parse(_countryCode) >= 020) && (int.Parse(_countryCode) <= 029))
            {
                //UPC-A compatible - Used to issue restricted circulation numbers within a geographic region as defined by GS1 Member Organisations
                rchtxtbx_output.AppendText("Type = " + IssuingCountry.GetIssuingCountry(_countryCode) + "\r");

                rchtxtbx_output.AppendText("\rCould be one of these two:\r\t");

                rchtxtbx_output.AppendText("Item reference assigned by retailer = " +
                                           rchtxtbx_data_plus_checkdigit.Text.Substring(2, 5) + "\r\t");
                rchtxtbx_output.AppendText("Price or Weight Check Digit = " +
                                           rchtxtbx_data_plus_checkdigit.Text.Substring(7, 1) + "\r\t");
                rchtxtbx_output.AppendText("Price or Weight = " + rchtxtbx_data_plus_checkdigit.Text.Substring(8, 4) +
                                           "\r");

                rchtxtbx_output.AppendText("or:\r\t");

                rchtxtbx_output.AppendText("Item reference assigned by retailer = " +
                                           rchtxtbx_data_plus_checkdigit.Text.Substring(2, 4) + "\r\t");
                rchtxtbx_output.AppendText("Price or Weight Check Digit = " +
                                           rchtxtbx_data_plus_checkdigit.Text.Substring(6, 1) + "\r\t");
                rchtxtbx_output.AppendText("Price or Weight = " + rchtxtbx_data_plus_checkdigit.Text.Substring(7, 5) +
                                           "\r");

                rchtxtbx_output.AppendText("\rBarcode Check Digit = " +
                                           rchtxtbx_data_plus_checkdigit.Text.Substring(12, 1) + "\r"); //Check digit
            }
            else if ((int.Parse(_countryCode) >= 040) && (int.Parse(_countryCode) <= 049))
            {
                //UPC-A compatible - Used to issue restricted circulation numbers within a company
                rchtxtbx_output.AppendText("Type = " + IssuingCountry.GetIssuingCountry(_countryCode) + "\r");
                rchtxtbx_output.AppendText("Item reference assigned by company = " +
                                           rchtxtbx_data_plus_checkdigit.Text.Substring(2, 10) + "\r\t");
                rchtxtbx_output.AppendText("\rBarcode Check Digit = " +
                                           rchtxtbx_data_plus_checkdigit.Text.Substring(12, 1) + "\r"); //Check digit
            }
            else if ((int.Parse(_countryCode) >= 200) && (int.Parse(_countryCode) <= 290))
            {
                //Used to issue GS1 restricted circulation number within a geographic region as defined by GS1 Member Organisations
                rchtxtbx_output.AppendText("Type = " + IssuingCountry.GetIssuingCountry(_countryCode) + "\r");

                rchtxtbx_output.AppendText("\rCould be one of these two:\r\t");

                rchtxtbx_output.AppendText("Item reference assigned by retailer = " +
                                           rchtxtbx_data_plus_checkdigit.Text.Substring(2, 6) + "\r\t");
                rchtxtbx_output.AppendText("Price or Weight = " + rchtxtbx_data_plus_checkdigit.Text.Substring(8, 4) +
                                           "\r");

                rchtxtbx_output.AppendText("or:\r\t");

                rchtxtbx_output.AppendText("Item reference assigned by retailer = " +
                                           rchtxtbx_data_plus_checkdigit.Text.Substring(2, 5) + "\r\t");
                rchtxtbx_output.AppendText("Price or Weight = " + rchtxtbx_data_plus_checkdigit.Text.Substring(7, 5) +
                                           "\r");

                rchtxtbx_output.AppendText("\rBarcode Check Digit = " +
                                           rchtxtbx_data_plus_checkdigit.Text.Substring(12, 1) + "\r"); //Check digit
            }
            else if (_countryCode == "977") //ISSN for newspapers and periodicals
            {

                rchtxtbx_output.AppendText("Publication = " + IssuingCountry.GetIssuingCountry(_countryCode) + "\r");

                rchtxtbx_output.AppendText("\rCould be one of these two:\r\r\t");

                rchtxtbx_output.AppendText("International Standard Serial Number (ISSN) = " +
                                           rchtxtbx_data_plus_checkdigit.Text.Substring(3, 7) + "\r\t");
                rchtxtbx_output.AppendText("Variant = " + rchtxtbx_data_plus_checkdigit.Text.Substring(10, 2) + "\r\r");

                if ((rchtxtbx_data_plus_checkdigit.Text.Length > 13) &&
                    (rchtxtbx_data_plus_checkdigit.Text.Length < 16))
                {

                    rchtxtbx_output.AppendText("\tExtended publication data will be one of these: \r\r");



                    int period = int.Parse(rchtxtbx_data_plus_checkdigit.Text.Substring(13, 2));
                    int subPeriod = (int.Parse(period.ToString().Substring(1, 1)));


                    if ((period >= 00) || (period <= 99))
                    {
                        rchtxtbx_output.AppendText(
                            "\t\t\u2022Bi-Annual period: " +
                            "\r\t\t\t\u2023last digit of the year = " + period.ToString().Substring(0, 1) +
                            "\r\t\t\t\u2023number of the first season of the respective period = " + period.ToString().Substring(1, 1));
                        rchtxtbx_output.AppendText("\r\t\t\u2022Special intervals: " +
                                                   "\r\t\t\t\u2023(Consecutively numbered from 01 to 99) = " + period + "\r");
                    }

                    if ((period >= 01) && (period <= 53))
                    {
                        rchtxtbx_output.AppendText(
                            "\t\t\u2022Dailies(or more generally publications with several issues a week): " +
                            "\r\t\t\t\u2023Number of the week = " +
                            period + "\r");
                        rchtxtbx_output.AppendText("\t\t\u2022Weeklies: " +
                                                   "\r\t\t\t\u2023Number of the week = " + period + "\r");
                        rchtxtbx_output.AppendText(
                            "\t\t\u2022Bi-weeklies: " +
                            "\r\t\t\t\u2023Number of the first week of the respective period = " + period + "\r");
                    }

                    if ((subPeriod >= 1) || (subPeriod <= 4))
                    {
                        string season;

                        switch (subPeriod)
                        {
                            case 1:
                                season = "Spring";
                                break;
                            case 2:
                                season = "Summer";
                                break;
                            case 3:
                                season = "Autumn";
                                break;
                            case 4:
                                season = "Winter";
                                break;
                            default:
                                season = "Unknown";
                                break;
                        }

                        rchtxtbx_output.AppendText("\t\t\u2022Seasonal period: = " +
                                                   "\r\t\t\t\u2023last digit of the year = " + period.ToString().Substring(0, 1) +
                                                   "\r\t\t\t\u2023Season (careful of hemisphere it was published in) = " + season);

                    }


                    if (subPeriod == 5)
                    {
                        rchtxtbx_output.AppendText("\r\t\t\u2022Annuals: " +
                                                   "\r\t\t\t\u2023Last digit of the year = " + period.ToString().Substring(0, 1));
                    }

                    if ((period >= 01) || (period <= 12))
                    {
                        rchtxtbx_output.AppendText("\r\t\t\u2022Monthlies: " +
                                                   "\r\t\t\t\u2023Number of the month = " + period + "\r");
                        rchtxtbx_output.AppendText(
                            "\t\t\u2022Bi - Monthlies: " +
                            "\r\t\t\t\u2023Number of the first month of the respective period = " + period + "\r");
                        rchtxtbx_output.AppendText(
                            "\t\t\u2022Quarterlies: " +
                            "\r\t\t\t\u2023Number of the first month of the respective period = " + period + "\r");
                    }
                }

                rchtxtbx_output.AppendText("\rOr:");

                rchtxtbx_output.AppendText("\r\r\tCompany + Product numbers = " +
                                           rchtxtbx_data_plus_checkdigit.Text.Substring(3, 9) + "\r");







                rchtxtbx_output.AppendText("\rBarcode Check Digit = " +
                                           rchtxtbx_data_plus_checkdigit.Text.Substring(12, 1) + "\r");


            }
            else if ((_countryCode == "978") || (_countryCode == "979"))
            {
                if ((_countryCode == "979") && (rchtxtbx_data_plus_checkdigit.Text.Substring(3, 1) == "0")) //ISMN - Sheet music
                {
                    string _itemNum = "";
                    string _publisherNum = "";

                    switch (rchtxtbx_data_plus_checkdigit.Text.Substring(4, 1))
                    {
                        case "0":
                            _publisherNum = rchtxtbx_data_plus_checkdigit.Text.Substring(4, 3);
                            _itemNum = rchtxtbx_data_plus_checkdigit.Text.Substring(7, 5);
                            break;
                        case "1":
                            _publisherNum = rchtxtbx_data_plus_checkdigit.Text.Substring(4, 4);
                            _itemNum = rchtxtbx_data_plus_checkdigit.Text.Substring(8, 4); 
                            break;
                        case "4":
                        case "5":
                        case "6":
                            _publisherNum = rchtxtbx_data_plus_checkdigit.Text.Substring(4, 5);
                            _itemNum = rchtxtbx_data_plus_checkdigit.Text.Substring(9, 3);
                            break;
                        case "7":
                        case "8":
                            _publisherNum = rchtxtbx_data_plus_checkdigit.Text.Substring(4, 6);
                            _itemNum = rchtxtbx_data_plus_checkdigit.Text.Substring(10, 2);
                            break;
                        case "9":
                            _publisherNum = rchtxtbx_data_plus_checkdigit.Text.Substring(4, 7);
                            _itemNum = rchtxtbx_data_plus_checkdigit.Text.Substring(11, 1);
                            break;
                        default:
                            _publisherNum = "Check Barcode Number its seems incorrect";
                            break;
                    }
                    
                    rchtxtbx_output.AppendText("Type = Musicland, ISMN-13, replaces deprecated ISMN M- numbers" + "\r");
                    rchtxtbx_output.AppendText("\rPublisher Number = " + _publisherNum + "\r");
                    rchtxtbx_output.AppendText("Item Number = " + _itemNum + "\r");
                    rchtxtbx_output.AppendText("\rBarcode Check Digit = " + rchtxtbx_data_plus_checkdigit.Text.Substring(12, 1) + "\r"); //Check digit
                }
                else //ISBN for books poss also with 5 digit add on
                {

                    rchtxtbx_output.AppendText("Publication = " + IssuingCountry.GetIssuingCountry(_countryCode) + "\r");

                    //Get XML file from https://www.isbn-international.org/range_file_generation


                    string[] ISBNData = isbn_RegistrationGroup.GetRegistrationGroup(rchtxtbx_data_plus_checkdigit.Text);
                    rchtxtbx_output.AppendText("\rRegistration group = " + ISBNData[0] + "\r");
                    rchtxtbx_output.AppendText("\rRegistrant and Publication = " + ISBNData[1] + "\r");
                   


                    rchtxtbx_output.AppendText("\rBarcode Check Digit = " + rchtxtbx_data_plus_checkdigit.Text.Substring(12, 1) + "\r"); //Check digit
                    
                    /* Work out the price via 5 digit extended data but only works for US$
                     *
                     * 00000 None Designated Do Not Use 
                       10000 – 19999 US$100.00 – US$199.99 Increased range 
                       20000 – 29999 US$200.00 – US$299.99 Increased range 
                       30000 – 39999 US$300.00 – US$399.99 Increased range 
                       40000 – 49999 US$400.00 – US$499.99 Increased range
                       50001 – 59998 US$0.01 – US$99.98 Previously existing rule 59999 Price is not encoded and is understood to exceed US$99.98. (Note: A price of US$99.99 cannot be encoded.) This value indicates a price greater than US$99.98 and not encoded in the add-on, whether the price is within the increased range or not. 
                       
                       60000 – 89999 No current meaning for price information. Values in this range are to be ignored for pricing. 
                       90000 Price is not encoded for this title. 90000 is understood to mean a net priced title or a title for which a list price is not suggested 
                       90001 – 99989 No current meaning for price information.Range reserved for industry wide uses. 
                       99990 – 99999 Interpretation specified by NACS Range reserved for designation by NACS for College Store uses. 
                       
                     *
                     *
                     */

                    String _bookPrice = "";

                    if (txtbx_input_extended_data.Text.Length == 5)
                    {
                        int _priceID = int.Parse(txtbx_input_extended_data.Text.Substring(0, 1));

                        if (_priceID == 5)
                        {
                            if (int.Parse(txtbx_input_extended_data.Text) <= 59998)
                            {
                                _bookPrice = ("US $" + txtbx_input_extended_data.Text.Substring(1, 2) + "." +
                                              txtbx_input_extended_data.Text.Substring(3, 2) + "\r");
                            }
                            else
                            {
                                _bookPrice = "Check the extended data as 59999 is not used anymore, it used to indicate a price higher than US$99.98\r";
                            }
                        }
                        else if (_priceID == 0)
                        {

                            _bookPrice = ("This could be one of the following two:\r\t\u2022Range No Longer Used\r");

                            _bookPrice = _bookPrice + ("\t\u2022GB £" + txtbx_input_extended_data.Text.Substring(1, 2) + "." +
                                          txtbx_input_extended_data.Text.Substring(3, 2) + "\r");
                        }
                        else if ((_priceID >= 1) && (_priceID <= 4))
                        {
                            _bookPrice = ("US $" + txtbx_input_extended_data.Text.Substring(0, 3) + "." +
                                          txtbx_input_extended_data.Text.Substring(3, 2) + "\r");
                        }
                        else if ((_priceID >= 6) && (_priceID <= 8))
                        {
                            _bookPrice = ("No current meaning for price information. Values in this range are to be ignored for pricing.\r");
                        }
                        else if (_priceID == 9)
                        {
                            if (int.Parse(txtbx_input_extended_data.Text) == 90000)
                            {
                                _bookPrice = ("Price is not encoded for this title. 90000 is understood to mean a net priced title or a title for which a list price is not suggested\r");
                            }
                            else if ((int.Parse(txtbx_input_extended_data.Text) >= 90001)&&(int.Parse(txtbx_input_extended_data.Text) <= 99989))
                            {
                                _bookPrice = ("No current meaning for price information. Range reserved for industry wide uses.\r");
                            }

                            else if ((int.Parse(txtbx_input_extended_data.Text) >= 99990) && (int.Parse(txtbx_input_extended_data.Text) <= 99999))
                            {
                                _bookPrice = ("Interpretation specified by NACS Range reserved for designation by NACS for College Store uses.\r");
                            }
                        }
                        
                        rchtxtbx_output.AppendText("\rBook Price = " + _bookPrice + "\r");
                    }
                    else
                    {
                        rchtxtbx_output.AppendText("\rError = Check Extended data needs to be 5 digits long\r"); 
                    }

                    
                }
            }
            else if (_countryCode == "980")
            {
                //Refund Receipt
                rchtxtbx_output.AppendText("Type = " + IssuingCountry.GetIssuingCountry(_countryCode) + "\r");
                rchtxtbx_output.AppendText("Security Number = " + rchtxtbx_data_plus_checkdigit.Text.Substring(3, 5) + "\r"); //Security #
                rchtxtbx_output.AppendText("Monetary Value = " + rchtxtbx_data_plus_checkdigit.Text.Substring(8, 4) + "\r"); //Monetary value
                rchtxtbx_output.AppendText("Barcode Check Digit = " + rchtxtbx_data_plus_checkdigit.Text.Substring(12, 1) + "\r"); //Check digit
            }
            else if ((_countryCode == "981") || (_countryCode == "982") || (_countryCode == "983"))
            {
                //GS1 Common currency coupon in Euro
                rchtxtbx_output.AppendText("Type = " + IssuingCountry.GetIssuingCountry(_countryCode) + "\r");
                rchtxtbx_output.AppendText("Coupon issuer number (issued by a GS1 Member Organisation) = " + rchtxtbx_data_plus_checkdigit.Text.Substring(3, 4) + "\r"); //issuer
                rchtxtbx_output.AppendText("Coupon reference number (allocated by a coupon issuer) = " + rchtxtbx_data_plus_checkdigit.Text.Substring(7, 2) + "\r"); //Coupon Reference

                if (_countryCode == "981") //value
                {
                    rchtxtbx_output.AppendText("Redemption value (expressed in euro); value 000 indicates free gift = " + rchtxtbx_data_plus_checkdigit.Text.Substring(9, 2));
                    rchtxtbx_output.AppendText(".");
                    rchtxtbx_output.AppendText(rchtxtbx_data_plus_checkdigit.Text.Substring(11, 1) + "\r");
                }
                else if (_countryCode == "982") //value
                {
                    rchtxtbx_output.AppendText("Redemption value (expressed in euro); value 000 indicates free gift = " + rchtxtbx_data_plus_checkdigit.Text.Substring(9, 1));
                    rchtxtbx_output.AppendText(".");
                    rchtxtbx_output.AppendText(rchtxtbx_data_plus_checkdigit.Text.Substring(10, 2) + "\r");
                }
                else if (_countryCode == "983") //value
                {
                    rchtxtbx_output.AppendText("Redemption value (expressed in euro); value 000 indicates free gift = " + rchtxtbx_data_plus_checkdigit.Text.Substring(9, 3) + "\r");

                }
                else
                {
                    rchtxtbx_output.AppendText("Value = Undefined\r");
                }

                rchtxtbx_output.AppendText("Barcode Check Digit = " + rchtxtbx_data_plus_checkdigit.Text.Substring(12, 1) + "\r"); //Check digit


            }
            else if ((int.Parse(_countryCode) >= 990) && (int.Parse(_countryCode) <= 999))
            {
                //Money off coupons in local currency
                rchtxtbx_output.AppendText("Type = " + IssuingCountry.GetIssuingCountry(_countryCode) + "\r");
                rchtxtbx_output.AppendText("Taxable, non - taxable, different currency coupons or indication of the decimal position = " + rchtxtbx_data_plus_checkdigit.Text.Substring(2, 1) + "\r");

                rchtxtbx_output.AppendText("\rCould be one of these four:\r\t");
                rchtxtbx_output.AppendText("Coupon issuer number (issued by the GS1 Member Organisation) = " + rchtxtbx_data_plus_checkdigit.Text.Substring(2, 4) + "\r\t");
                rchtxtbx_output.AppendText("Coupon reference number (allocated by a coupon issuer) = " + rchtxtbx_data_plus_checkdigit.Text.Substring(6, 3) + "\r\t");
                rchtxtbx_output.AppendText("Redemption value = " + rchtxtbx_data_plus_checkdigit.Text.Substring(9, 3) + "\r");

                rchtxtbx_output.AppendText("or:\r\t");
                rchtxtbx_output.AppendText("Coupon issuer number (issued by the GS1 Member Organisation) = " + rchtxtbx_data_plus_checkdigit.Text.Substring(2, 3) + "\r\t");
                rchtxtbx_output.AppendText("Coupon reference number (allocated by a coupon issuer) = " + rchtxtbx_data_plus_checkdigit.Text.Substring(5, 3) + "\r\t");
                rchtxtbx_output.AppendText("Redemption value = " + rchtxtbx_data_plus_checkdigit.Text.Substring(8, 4) + "\r");


                rchtxtbx_output.AppendText("or:\r\t");
                rchtxtbx_output.AppendText("Coupon issuer number (issued by the GS1 Member Organisation) = " + rchtxtbx_data_plus_checkdigit.Text.Substring(2, 5) + "\r\t");
                rchtxtbx_output.AppendText("Coupon reference number (allocated by a coupon issuer) = " + rchtxtbx_data_plus_checkdigit.Text.Substring(7, 3) + "\r\t");
                rchtxtbx_output.AppendText("Value code (standardised by the GS1 Member Organisation) = " + rchtxtbx_data_plus_checkdigit.Text.Substring(10, 2) + "\r");


                rchtxtbx_output.AppendText("or:\r\t");
                rchtxtbx_output.AppendText("Coupon issuer number (issued by the GS1 Member Organisation) = " + rchtxtbx_data_plus_checkdigit.Text.Substring(2, 5) + "\r\t");
                rchtxtbx_output.AppendText("Coupon reference number (allocated by a coupon issuer) = " + rchtxtbx_data_plus_checkdigit.Text.Substring(7, 5) + "\r");

                rchtxtbx_output.AppendText("\rBarcode Check Digit = " + rchtxtbx_data_plus_checkdigit.Text.Substring(12, 1) + "\r");
            }
            else
            {
                //Country issue
                rchtxtbx_output.AppendText("Country of Issue = " + IssuingCountry.GetIssuingCountry(_countryCode) + "\r");
                rchtxtbx_output.AppendText("Company + Product numbers = " + rchtxtbx_data_plus_checkdigit.Text.Substring(3, 9) + "\r");
                rchtxtbx_output.AppendText("Barcode Check Digit = " + rchtxtbx_data_plus_checkdigit.Text.Substring(12, 1) + "\r");
            }
            
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rdobtn_upc_a_CheckedChanged(object sender, EventArgs e)
        {
            if (rdobtn_upc_a.Checked) //upc-a
            {
                if (txtbx_input_data.Text.Length < 12) //ean = 12 + CDigit
                {
                    txtbx_input_data.Text = "0" + txtbx_input_data.Text; //put in leading zero
                }
                else
                {
                    txtbx_input_data.Text = "0"; //clear what is in box and add just zero
                }
            }
            else if (txtbx_input_data.Text.Length > 0) //ean-13
            {
                if (txtbx_input_data.Text.Length > 0)
                {
                    txtbx_input_data.Text = txtbx_input_data.Text.Substring(1, txtbx_input_data.Text.Length - 1);
                }
            }

            CalculateBarCode();
            txtbx_input_data.Focus();
            txtbx_input_data.SelectionStart = txtbx_input_data.Text.Length; //put cursor at end of data so we do not overwrite the zero
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CalculateBarCode();
            Size = new Size(1200, 600);
            StartPosition = FormStartPosition.CenterScreen;

            lbl_extended_data.Visible = txtbx_input_extended_data.Visible = false;


            //We add the font file to resources so we know it will be on the computer
            //we we load teh form we need ot get hold of the font file and this is how I do it.
            // there are other ways to do it using unsafe code but I do it this way.

            //create and instance of PrivateFoneCollection
            PrivateFontCollection pfc = new PrivateFontCollection();

            //Read the font file from resources. It comes out as byte array
            var FontFile = Properties.Resources.ean13;

            //Write the byte array to a file in same directory as the exe we are running
            File.WriteAllBytes("ean13.ttf", Properties.Resources.ean13.ToArray());

            //add the font file to our instance of PrivateFontCollection
            pfc.AddFontFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ean13.ttf");

            //Make sure the lable that should use it will use it
            lbl_output.Font = new Font(pfc.Families[0], 96, FontStyle.Regular);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //center the barcode in the panel
            CenterLabel();
        }

        
    }
}
