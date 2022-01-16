namespace EAN13
{
    class isbn_RegistrationGroup
    {

        public static string[] GetRegistrationGroup(string data)
        {
            string[] ISBNData = {"",""};


            if ((int.Parse(data.Substring(0, 4)) >= 9780) && (int.Parse(data.Substring(0, 4)) <= 9785) ||
                (int.Parse(data.Substring(0, 4)) == 9787))
            {
                switch (data.Substring(0, 4))
                {
                    case "9780":
                        ISBNData[0] = "English language";
                        break;
                    case "9781":
                        ISBNData[0] = "English language";
                        break;
                    case "9782":
                        ISBNData[0] = "French language";
                        break;
                    case "9783":
                        ISBNData[0] = "German language";
                        break;
                    case "9784":
                        ISBNData[0] = "Japan";
                        break;
                    case "9785":
                        ISBNData[0] = "Former U.S.S.R";
                        break;
                    case "9787":
                        ISBNData[0] = "Peoples Republic of China";
                        break;
                    default:
                        ISBNData[0] = "Unknown";
                        break;
                }

                ISBNData[1] = data.Substring(4, 8);

            }
            else if ((int.Parse(data.Substring(0, 5)) == 97865))
            {
                ISBNData[0] = "Brazil";
                ISBNData[1] = data.Substring(5, 7);
            }
            else if ((int.Parse(data.Substring(0, 6)) >= 978600) && (int.Parse(data.Substring(0, 6)) <= 978628))
            {
                switch (data.Substring(0, 6))
                {
                    case "978600":
                        ISBNData[0] = "Iran";
                        break;
                    case "978601":
                        ISBNData[0] = "Kazakhstan";
                        break;
                    case "978602":
                        ISBNData[0] = "Indonesia";
                        break;
                    case "978603":
                        ISBNData[0] = "Saudi Arabia";
                        break;
                    case "978604":
                        ISBNData[0] = "Vietnam";
                        break;
                    case "978605":
                        ISBNData[0] = "Turkey";
                        break;
                    case "978606":
                        ISBNData[0] = "Romania";
                        break;
                    case "978607":
                        ISBNData[0] = "Mexico";
                        break;
                    case "978608":
                        ISBNData[0] = "North Macedonia";
                        break;
                    case "978609":
                        ISBNData[0] = "Lithuania";
                        break;
                    case "978611":
                        ISBNData[0] = "Thailand";
                        break;
                    case "978612":
                        ISBNData[0] = "Peru";
                        break;
                    case "978613":
                        ISBNData[0] = "Mauritius";
                        break;
                    case "978614":
                        ISBNData[0] = "Lebanon";
                        break;
                    case "978615":
                        ISBNData[0] = "Hungary";
                        break;
                    case "978616":
                        ISBNData[0] = "Thailand";
                        break;
                    case "978617":
                        ISBNData[0] = "Ukraine";
                        break;
                    case "978618":
                        ISBNData[0] = "Greece";
                        break;
                    case "978619":
                        ISBNData[0] = "Bulgaria";
                        break;
                    case "978620":
                        ISBNData[0] = "Mauritius";
                        break;
                    case "978621":
                        ISBNData[0] = "Philippines";
                        break;
                    case "978622":
                        ISBNData[0] = "Iran";
                        break;
                    case "978623":
                        ISBNData[0] = "Indonesia";
                        break;
                    case "978624":
                        ISBNData[0] = "Sri Lanka";
                        break;
                    case "978625":
                        ISBNData[0] = "Turkey";
                        break;
                    case "978626":
                        ISBNData[0] = "Taiwan";
                        break;
                    case "978627":
                        ISBNData[0] = "Pakistan";
                        break;
                    case "978628":
                        ISBNData[0] = "Colombia";
                        break;
                    default:
                        ISBNData[0] = "Unknown";
                        break;
                }
                ISBNData[1] = data.Substring(6, 6);
            }
            else if ((int.Parse(data.Substring(0, 5)) >= 97880) && (int.Parse(data.Substring(0, 5)) <= 97894))
            {
                switch (data.Substring(0, 5))
                {
                    case "97880":
                        ISBNData[0] = "former Czechoslovakia";
                        break;
                    case "97881":
                        ISBNData[0] = "India";
                        break;
                    case "97882":
                        ISBNData[0] = "Norway";
                        break;
                    case "97883":
                        ISBNData[0] = "Poland";
                        break;
                    case "97884":
                        ISBNData[0] = "Spain";
                        break;
                    case "97885":
                        ISBNData[0] = "Brazil";
                        break;
                    case "97886":
                        ISBNData[0] = "former Yugoslavia";
                        break;
                    case "97887":
                        ISBNData[0] = "Denmark";
                        break;
                    case "97888":
                        ISBNData[0] = "Italy";
                        break;
                    case "97889":
                        ISBNData[0] = "Korea, Republic";
                        break;
                    case "97890":
                        ISBNData[0] = "Netherlands";
                        break;
                    case "97891":
                        ISBNData[0] = "Sweden";
                        break;
                    case "97892":
                        ISBNData[0] = "International NGO Publishers and EU Organizations";
                        break;
                    case "97893":
                        ISBNData[0] = "India";
                        break;
                    case "97894":
                        ISBNData[0] = "Netherlands";
                        break;
                    default:
                        ISBNData[0] = "Unknown";
                        break;
                }
                ISBNData[1] = data.Substring(5, 7);
            }
            else if ((int.Parse(data.Substring(0, 6)) >= 978950) && (int.Parse(data.Substring(0, 6)) <= 978989))
            {
                switch (data.Substring(0, 6))
                {
                    case "978950":
                        ISBNData[0] = "Argentina";
                        break;
                    case "978951":
                        ISBNData[0] = "Finland";
                        break;
                    case "978952":
                        ISBNData[0] = "Finland";
                        break;
                    case "978953":
                        ISBNData[0] = "Croatia";
                        break;
                    case "978954":
                        ISBNData[0] = "Bulgaria";
                        break;
                    case "978955":
                        ISBNData[0] = "Sri Lanka";
                        break;
                    case "978956":
                        ISBNData[0] = "Chile";
                        break;
                    case "978957":
                        ISBNData[0] = "Taiwan";
                        break;
                    case "978958":
                        ISBNData[0] = "Colombia";
                        break;
                    case "978959":
                        ISBNData[0] = "Cuba";
                        break;
                    case "978960":
                        ISBNData[0] = "Greece";
                        break;
                    case "978961":
                        ISBNData[0] = "Slovenia";
                        break;
                    case "978962":
                        ISBNData[0] = "Hong Kong, China";
                        break;
                    case "978963":
                        ISBNData[0] = "Hungary";
                        break;
                    case "978964":
                        ISBNData[0] = "Iran";
                        break;
                    case "978965":
                        ISBNData[0] = "Israel";
                        break;
                    case "978966":
                        ISBNData[0] = "Ukraine";
                        break;
                    case "978967":
                        ISBNData[0] = "Malaysia";
                        break;
                    case "978968":
                        ISBNData[0] = "Mexico";
                        break;
                    case "978969":
                        ISBNData[0] = "Pakistan";
                        break;
                    case "978970":
                        ISBNData[0] = "Mexico";
                        break;
                    case "978971":
                        ISBNData[0] = "Philippines";
                        break;
                    case "978972":
                        ISBNData[0] = "Portugal";
                        break;
                    case "978973":
                        ISBNData[0] = "Romania";
                        break;
                    case "978974":
                        ISBNData[0] = "Thailand";
                        break;
                    case "978975":
                        ISBNData[0] = "Turkey";
                        break;
                    case "978976":
                        ISBNData[0] = "Caribbean Community";
                        break;
                    case "978977":
                        ISBNData[0] = "Egypt";
                        break;
                    case "978978":
                        ISBNData[0] = "Nigeria";
                        break;
                    case "978979":
                        ISBNData[0] = "Indonesia";
                        break;
                    case "978980":
                        ISBNData[0] = "Venezuela";
                        break;
                    case "978981":
                        ISBNData[0] = "Singapore";
                        break;
                    case "978982":
                        ISBNData[0] = "South Pacific";
                        break;
                    case "978983":
                        ISBNData[0] = "Malaysia";
                        break;
                    case "978984":
                        ISBNData[0] = "Bangladesh";
                        break;
                    case "978985":
                        ISBNData[0] = "Belarus";
                        break;
                    case "978986":
                        ISBNData[0] = "Taiwan";
                        break;
                    case "978987":
                        ISBNData[0] = "Argentina";
                        break;
                    case "978988":
                        ISBNData[0] = "Hong Kong, China";
                        break;
                    case "978989":
                        ISBNData[0] = "Portugal";
                        break;
                    default:
                        ISBNData[0] = "Unknown";
                        break;
                }
                ISBNData[1] = data.Substring(6, 6);
            }
            else if ((int.Parse(data.Substring(0, 7)) >= 9789912) && (int.Parse(data.Substring(0, 7)) <= 9789989))
            {
                switch (data.Substring(0, 7))
                {
                    case "9789912":
                        ISBNData[0] = "Tanzania";
                        break;
                    case "9789913":
                        ISBNData[0] = "Uganda";
                        break;
                    case "9789914":
                        ISBNData[0] = "Kenya";
                        break;
                    case "9789915":
                        ISBNData[0] = "Uruguay";
                        break;
                    case "9789916":
                        ISBNData[0] = "Estonia";
                        break;
                    case "9789917":
                        ISBNData[0] = "Bolivia";
                        break;
                    case "9789918":
                        ISBNData[0] = "Malta";
                        break;
                    case "9789919":
                        ISBNData[0] = "Mongolia";
                        break;
                    case "9789920":
                        ISBNData[0] = "Morocco";
                        break;
                    case "9789921":
                        ISBNData[0] = "Kuwait";
                        break;
                    case "9789922":
                        ISBNData[0] = "Iraq";
                        break;
                    case "9789923":
                        ISBNData[0] = "Jordan";
                        break;
                    case "9789924":
                        ISBNData[0] = "Cambodia";
                        break;
                    case "9789925":
                        ISBNData[0] = "Cyprus";
                        break;
                    case "9789926":
                        ISBNData[0] = "Bosnia and Herzegovina";
                        break;
                    case "9789927":
                        ISBNData[0] = "Qatar";
                        break;
                    case "9789928":
                        ISBNData[0] = "Albania";
                        break;
                    case "9789929":
                        ISBNData[0] = "Guatemala";
                        break;
                    case "9789930":
                        ISBNData[0] = "Costa Rica";
                        break;
                    case "9789931":
                        ISBNData[0] = "Algeria";
                        break;
                    case "9789932":
                        ISBNData[0] = "Lao People's Democratic Republic";
                        break;
                    case "9789933":
                        ISBNData[0] = "Syria";
                        break;
                    case "9789934":
                        ISBNData[0] = "Latvia";
                        break;
                    case "9789935":
                        ISBNData[0] = "Iceland";
                        break;
                    case "9789936":
                        ISBNData[0] = "Afghanistan";
                        break;
                    case "9789937":
                        ISBNData[0] = "Nepal";
                        break;
                    case "9789938":
                        ISBNData[0] = "Tunisia";
                        break;
                    case "9789939":
                        ISBNData[0] = "Armenia";
                        break;
                    case "9789940":
                        ISBNData[0] = "Montenegro";
                        break;
                    case "9789941":
                        ISBNData[0] = "Georgia";
                        break;
                    case "9789942":
                        ISBNData[0] = "Ecuador";
                        break;
                    case "9789943":
                        ISBNData[0] = "Uzbekistan";
                        break;
                    case "9789944":
                        ISBNData[0] = "Turkey";
                        break;
                    case "9789945":
                        ISBNData[0] = "Dominican Republic";
                        break;
                    case "9789946":
                        ISBNData[0] = "Korea, P.D.R.";
                        break;
                    case "9789947":
                        ISBNData[0] = "Algeria";
                        break;
                    case "9789948":
                        ISBNData[0] = "United Arab Emirates";
                        break;
                    case "9789949":
                        ISBNData[0] = "Estonia";
                        break;
                    case "9789950":
                        ISBNData[0] = "Palestine";
                        break;
                    case "9789951":
                        ISBNData[0] = "Kosova";
                        break;
                    case "9789952":
                        ISBNData[0] = "Azerbaijan";
                        break;
                    case "9789953":
                        ISBNData[0] = "Lebanon";
                        break;
                    case "9789954":
                        ISBNData[0] = "Morocco";
                        break;
                    case "9789955":
                        ISBNData[0] = "Lithuania";
                        break;
                    case "9789956":
                        ISBNData[0] = "Cameroon";
                        break;
                    case "9789957":
                        ISBNData[0] = "Jordan";
                        break;
                    case "9789958":
                        ISBNData[0] = "Bosnia and Herzegovina";
                        break;
                    case "9789959":
                        ISBNData[0] = "Libya";
                        break;
                    case "9789960":
                        ISBNData[0] = "Saudi Arabia";
                        break;
                    case "9789961":
                        ISBNData[0] = "Algeria";
                        break;
                    case "9789962":
                        ISBNData[0] = "Panama";
                        break;
                    case "9789963":
                        ISBNData[0] = "Cyprus";
                        break;
                    case "9789964":
                        ISBNData[0] = "Ghana";
                        break;
                    case "9789965":
                        ISBNData[0] = "Kazakhstan";
                        break;
                    case "9789966":
                        ISBNData[0] = "Kenya";
                        break;
                    case "9789967":
                        ISBNData[0] = "Kyrgyz Republic";
                        break;
                    case "9789968":
                        ISBNData[0] = "Costa Rica";
                        break;
                    case "9789970":
                        ISBNData[0] = "Uganda";
                        break;
                    case "9789971":
                        ISBNData[0] = "Singapore";
                        break;
                    case "9789972":
                        ISBNData[0] = "Peru";
                        break;
                    case "9789973":
                        ISBNData[0] = "Tunisia";
                        break;
                    case "9789974":
                        ISBNData[0] = "Uruguay";
                        break;
                    case "9789975":
                        ISBNData[0] = "Moldova";
                        break;
                    case "9789976":
                        ISBNData[0] = "Tanzania";
                        break;
                    case "9789977":
                        ISBNData[0] = "Costa Rica";
                        break;
                    case "9789978":
                        ISBNData[0] = "Ecuador";
                        break;
                    case "9789979":
                        ISBNData[0] = "Iceland";
                        break;
                    case "9789980":
                        ISBNData[0] = "Papua New Guinea";
                        break;
                    case "9789981":
                        ISBNData[0] = "Morocco";
                        break;
                    case "9789982":
                        ISBNData[0] = "Zambia";
                        break;
                    case "9789983":
                        ISBNData[0] = "Gambia";
                        break;
                    case "9789984":
                        ISBNData[0] = "Latvia";
                        break;
                    case "9789985":
                        ISBNData[0] = "Estonia";
                        break;
                    case "9789986":
                        ISBNData[0] = "Lithuania";
                        break;
                    case "9789987":
                        ISBNData[0] = "Tanzania";
                        break;
                    case "9789988":
                        ISBNData[0] = "Ghana";
                        break;
                    case "9789989":
                        ISBNData[0] = "North Macedonia";
                        break;
                    default:
                        ISBNData[0] = "Unknown";
                        break;
                }
                ISBNData[1] = data.Substring(7, 5);
            }
            else if ((int.Parse(data.Substring(0, 8)) >= 97899901) && (int.Parse(data.Substring(0, 8)) <= 97899988))
            {
                switch (data.Substring(0, 8))
                {
                    case "97899901":
                        ISBNData[0] = "Bahrain";
                        break;
                    case "97899902":
                        ISBNData[0] = "Reserved Agency";
                        break;
                    case "97899903":
                        ISBNData[0] = "Mauritius";
                        break;
                    case "97899904":
                        ISBNData[0] = "Curaçao";
                        break;
                    case "97899905":
                        ISBNData[0] = "Bolivia";
                        break;
                    case "97899906":
                        ISBNData[0] = "Kuwait";
                        break;
                    case "97899908":
                        ISBNData[0] = "Malawi";
                        break;
                    case "97899909":
                        ISBNData[0] = "Malta";
                        break;
                    case "97899910":
                        ISBNData[0] = "Sierra Leone";
                        break;
                    case "97899911":
                        ISBNData[0] = "Lesotho";
                        break;
                    case "97899912":
                        ISBNData[0] = "Botswana";
                        break;
                    case "97899913":
                        ISBNData[0] = "Andorra";
                        break;
                    case "97899914":
                        ISBNData[0] = "International NGO Publishers";
                        break;
                    case "97899915":
                        ISBNData[0] = "Maldives";
                        break;
                    case "97899916":
                        ISBNData[0] = "Namibia";
                        break;
                    case "97899917":
                        ISBNData[0] = "Brunei Darussalam";
                        break;
                    case "97899918":
                        ISBNData[0] = "Faroe Islands";
                        break;
                    case "97899919":
                        ISBNData[0] = "Benin";
                        break;
                    case "97899920":
                        ISBNData[0] = "Andorra";
                        break;
                    case "97899921":
                        ISBNData[0] = "Qatar";
                        break;
                    case "97899922":
                        ISBNData[0] = "Guatemala";
                        break;
                    case "97899923":
                        ISBNData[0] = "El Salvador";
                        break;
                    case "97899924":
                        ISBNData[0] = "Nicaragua";
                        break;
                    case "97899925":
                        ISBNData[0] = "Paraguay";
                        break;
                    case "97899926":
                        ISBNData[0] = "Honduras";
                        break;
                    case "97899927":
                        ISBNData[0] = "Albania";
                        break;
                    case "97899928":
                        ISBNData[0] = "Georgia";
                        break;
                    case "97899929":
                        ISBNData[0] = "Mongolia";
                        break;
                    case "97899930":
                        ISBNData[0] = "Armenia";
                        break;
                    case "97899931":
                        ISBNData[0] = "Seychelles";
                        break;
                    case "97899932":
                        ISBNData[0] = "Malta";
                        break;
                    case "97899933":
                        ISBNData[0] = "Nepal";
                        break;
                    case "97899934":
                        ISBNData[0] = "Dominican Republic";
                        break;
                    case "97899935":
                        ISBNData[0] = "Haiti";
                        break;
                    case "97899936":
                        ISBNData[0] = "Bhutan";
                        break;
                    case "97899937":
                        ISBNData[0] = "Macau";
                        break;
                    case "97899938":
                        ISBNData[0] = "Srpska, Republic of";
                        break;
                    case "97899939":
                        ISBNData[0] = "Guatemala";
                        break;
                    case "97899940":
                        ISBNData[0] = "Georgia";
                        break;
                    case "97899941":
                        ISBNData[0] = "Armenia";
                        break;
                    case "97899942":
                        ISBNData[0] = "Sudan";
                        break;
                    case "97899943":
                        ISBNData[0] = "Albania";
                        break;
                    case "97899944":
                        ISBNData[0] = "Ethiopia";
                        break;
                    case "97899945":
                        ISBNData[0] = "Namibia";
                        break;
                    case "97899946":
                        ISBNData[0] = "Nepal";
                        break;
                    case "97899947":
                        ISBNData[0] = "Tajikistan";
                        break;
                    case "97899948":
                        ISBNData[0] = "Eritrea";
                        break;
                    case "97899949":
                        ISBNData[0] = "Mauritius";
                        break;
                    case "97899950":
                        ISBNData[0] = "Cambodia";
                        break;
                    case "97899951":
                        ISBNData[0] = "Reserved Agency";
                        break;
                    case "97899952":
                        ISBNData[0] = "Mali";
                        break;
                    case "97899953":
                        ISBNData[0] = "Paraguay";
                        break;
                    case "97899954":
                        ISBNData[0] = "Bolivia";
                        break;
                    case "97899955":
                        ISBNData[0] = "Srpska, Republic of";
                        break;
                    case "97899956":
                        ISBNData[0] = "Albania";
                        break;
                    case "97899957":
                        ISBNData[0] = "Malta";
                        break;
                    case "97899958":
                        ISBNData[0] = "Bahrain";
                        break;
                    case "97899959":
                        ISBNData[0] = "Luxembourg";
                        break;
                    case "97899960":
                        ISBNData[0] = "Malawi";
                        break;
                    case "97899961":
                        ISBNData[0] = "El Salvador";
                        break;
                    case "97899962":
                        ISBNData[0] = "Mongolia";
                        break;
                    case "97899963":
                        ISBNData[0] = "Cambodia";
                        break;
                    case "97899964":
                        ISBNData[0] = "Nicaragua";
                        break;
                    case "97899965":
                        ISBNData[0] = "Macau";
                        break;
                    case "97899966":
                        ISBNData[0] = "Kuwait";
                        break;
                    case "97899967":
                        ISBNData[0] = "Paraguay";
                        break;
                    case "97899968":
                        ISBNData[0] = "Botswana";
                        break;
                    case "97899969":
                        ISBNData[0] = "Oman";
                        break;
                    case "97899970":
                        ISBNData[0] = "Haiti";
                        break;
                    case "97899971":
                        ISBNData[0] = "Myanmar";
                        break;
                    case "97899972":
                        ISBNData[0] = "Faroe Islands";
                        break;
                    case "97899973":
                        ISBNData[0] = "Mongolia";
                        break;
                    case "97899974":
                        ISBNData[0] = "Bolivia";
                        break;
                    case "97899975":
                        ISBNData[0] = "Tajikistan";
                        break;
                    case "97899976":
                        ISBNData[0] = "Srpska, Republic of";
                        break;
                    case "97899977":
                        ISBNData[0] = "Rwanda";
                        break;
                    case "97899978":
                        ISBNData[0] = "Mongolia";
                        break;
                    case "97899979":
                        ISBNData[0] = "Honduras";
                        break;
                    case "97899980":
                        ISBNData[0] = "Bhutan";
                        break;
                    case "97899981":
                        ISBNData[0] = "Macau";
                        break;
                    case "97899982":
                        ISBNData[0] = "Benin";
                        break;
                    case "97899983":
                        ISBNData[0] = "El Salvador";
                        break;
                    case "97899985":
                        ISBNData[0] = "Tajikistan";
                        break;
                    case "97899986":
                        ISBNData[0] = "Myanmar";
                        break;
                    case "97899987":
                        ISBNData[0] = "Luxembourg";
                        break;
                    case "97899988":
                        ISBNData[0] = "Sudan";
                        break;
                    default:
                        ISBNData[0] = "Unknown";
                        break;
                }
                ISBNData[1] = data.Substring(8, 4);
            }
            else if ((int.Parse(data.Substring(0, 4)) == 9798))
            {
                ISBNData[0] = "United States";
                ISBNData[1] = data.Substring(4, 8);
            }
            else if ((int.Parse(data.Substring(0, 5)) >= 97910) && (int.Parse(data.Substring(0, 5)) <= 97912))
            {
                switch (data.Substring(0, 5))
                {
                    case "97910":
                        ISBNData[0] = "France";
                        break;
                    case "97911":
                        ISBNData[0] = "Republic of Korea";
                        break;
                    case "97912":
                        ISBNData[0] = "Italy";
                        break;
                    default:
                        ISBNData[0] = "Unknown";
                        break;
                }
                ISBNData[1] = data.Substring(5, 7);
            }
            else
            {
                ISBNData[0] = "Unknown";
                ISBNData[1] = "Unknown";
            }

            return ISBNData;
        }
    }
}
