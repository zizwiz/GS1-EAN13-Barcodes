using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAN13
{
    class IssuingCountry
    {

        public static string GetIssuingCountry(string CountryCode)
        {
            string _country = "";

            switch (int.Parse(CountryCode))
            {
                case int n when ((n >= 000) && (n <= 019)): _country = "UPC-A compatible - United States and Canada"; break;
                case int n when ((n >= 020) && (n <= 029)): _country = "UPC-A compatible - Used to issue restricted circulation numbers within a geographic region as defined by GS1 Member Organisations"; break;
                case int n when ((n >= 030) && (n <= 039)): _country = "UPC-A compatible - United States drugs (see United States National Drug Code)"; break;
                case int n when ((n >= 040) && (n <= 049)): _country = "UPC-A compatible - Used to issue restricted circulation numbers within a company"; break;
                case int n when ((n >= 050) && (n <= 059)): _country = "UPC-A compatible - GS1 US reserved for future use"; break;
                case int n when ((n >= 060) && (n <= 099)): _country = "UPC-A compatible - United States and Canada"; break;
                case int n when ((n >= 100) && (n <= 139)): _country = "United States"; break;
                case int n when ((n >= 200) && (n <= 299)): _country = "Used to issue GS1 restricted circulation number within a geographic region as defined by GS1 Member Organisations"; break;
                case int n when ((n >= 300) && (n <= 379)): _country = "France and Monaco"; break;
                case 380: _country = "Bulgaria"; break;
                case 383: _country = "Slovenia"; break;
                case 385: _country = "Croatia"; break;
                case 387: _country = "Bosnia and Herzegovina"; break;
                case 389: _country = "Montenegro"; break;
                case 390: _country = "Kosovo"; break;
                case int n when ((n >= 400) && (n <= 439)): _country = "Germany"; break;
                case 440: _country = "Germany (inherited from former East Germany upon reunification in 1990)"; break;
                case int n when ((n >= 450) && (n <= 459)): _country = "Japan (new Japanese Article Number range)"; break;
                case int n when ((n >= 460) && (n <= 469)): _country = "Russia (barcodes inherited from the Soviet Union)"; break;
                case 470: _country = "Kyrgyzstan"; break;
                case 471: _country = "Taiwan"; break;
                case 474: _country = "Estonia"; break;
                case 475: _country = "Latvia"; break;
                case 476: _country = "Azerbaijan"; break;
                case 477: _country = "Lithuania"; break;
                case 478: _country = "Uzbekistan"; break;
                case 479: _country = "Sri Lanka"; break;
                case 480: _country = "Philippines"; break;
                case 481: _country = "Belarus"; break;
                case 482: _country = "Ukraine"; break;
                case 483: _country = "Turkmenistan"; break;
                case 484: _country = "Moldova"; break;
                case 485: _country = "Armenia"; break;
                case 486: _country = "Georgia"; break;
                case 487: _country = "Kazakhstan"; break;
                case 488: _country = "Tajikistan"; break;
                case 489: _country = "Hong Kong"; break;
                case int n when ((n >= 490) && (n <= 499)): _country = "Japan (original Japanese Article Number range)"; break;
                case int n when ((n >= 500) && (n <= 509)): _country = "United Kingdom"; break;
                case int n when ((n >= 520) && (n <= 521)): _country = "Greece"; break;
                case 528: _country = "Lebanon"; break;
                case 529: _country = "Cyprus"; break;
                case 530: _country = "Albania"; break;
                case 531: _country = "North Macedonia"; break;
                case 535: _country = "Malta"; break;
                case 539: _country = "Ireland"; break;
                case int n when ((n >= 540) && (n <= 549)): _country = "Belgium and Luxembourg"; break;
                case 560: _country = "Portugal"; break;
                case 569: _country = "Iceland"; break;
                case int n when ((n >= 570) && (n <= 579)): _country = "Denmark, Faroe Islands and Greenland"; break;
                case 590: _country = "Poland"; break;
                case 594: _country = "Romania"; break;
                case 599: _country = "Hungary"; break;
                case int n when ((n >= 600) && (n <= 601)): _country = "South Africa"; break;
                case 603: _country = "Ghana"; break;
                case 604: _country = "Senegal"; break;
                case 608: _country = "Bahrain"; break;
                case 609: _country = "Mauritius"; break;
                case 611: _country = "Morocco"; break;
                case 613: _country = "Algeria"; break;
                case 615: _country = "Nigeria"; break;
                case 616: _country = "Kenya"; break;
                case 617: _country = "Cameroon"; break;
                case 618: _country = "Ivory Coast"; break;
                case 619: _country = "Tunisia"; break;
                case 620: _country = "Tanzania"; break;
                case 621: _country = "Syria"; break;
                case 622: _country = "Egypt"; break;
                case 623: _country = "Brunei"; break;
                case 624: _country = "Libya"; break;
                case 625: _country = "Jordan"; break;
                case 626: _country = "Iran"; break;
                case 627: _country = "Kuwait"; break;
                case 628: _country = "Saudi Arabia"; break;
                case 629: _country = "United Arab Emirates"; break;
                case 630: _country = "Qatar"; break;
                case 631: _country = "Namibia"; break;
                case int n when ((n >= 640) && (n <= 649)): _country = "Finland"; break;
                case int n when ((n >= 690) && (n <= 699)): _country = "China"; break;
                case int n when ((n >= 700) && (n <= 709)): _country = "Norway"; break;
                case 729: _country = "Israel"; break;
                case int n when ((n >= 730) && (n <= 739)): _country = "Sweden"; break;
                case 740: _country = "Guatemala"; break;
                case 741: _country = "El Salvador"; break;
                case 742: _country = "Honduras"; break;
                case 743: _country = "Nicaragua"; break;
                case 744: _country = "Costa Rica"; break;
                case 745: _country = "Panama"; break;
                case 746: _country = "Dominican Republic"; break;
                case 750: _country = "Mexico"; break;
                case int n when ((n >= 754) && (n <= 755)): _country = "Canada"; break;
                case 759: _country = "Venezuela"; break;
                case int n when ((n >= 760) && (n <= 769)): _country = "Switzerland and Liechtenstein"; break;
                case int n when ((n >= 770) && (n <= 771)): _country = "Colombia"; break;
                case 773: _country = "Uruguay"; break;
                case 775: _country = "Peru"; break;
                case 777: _country = "Bolivia"; break;
                case int n when ((n >= 778) && (n <= 779)): _country = "Argentina"; break;
                case 780: _country = "Chile"; break;
                case 784: _country = "Paraguay"; break;
                case 786: _country = "Ecuador"; break;
                case int n when ((n >= 789) && (n <= 790)): _country = "Brazil"; break;
                case int n when ((n >= 800) && (n <= 839)): _country = "Italy, San Marino and Vatican City"; break;
                case int n when ((n >= 840) && (n <= 849)): _country = "Spain and Andorra"; break;
                case 850: _country = "Cuba"; break;
                case 858: _country = "Slovakia"; break;
                case 859: _country = "Czech Republic (barcode inherited from Czechoslovakia)"; break;
                case 860: _country = "Serbia (barcode inherited from Yugoslavia and Serbia and Montenegro)"; break;
                case 865: _country = "Mongolia"; break;
                case 867: _country = "North Korea"; break;
                case int n when ((n >= 868) && (n <= 869)): _country = "Turkey"; break;
                case int n when ((n >= 870) && (n <= 879)): _country = "Netherlands"; break;
                case 880: _country = "South Korea"; break;
                case 883: _country = "Myanmar"; break;
                case 884: _country = "Cambodia"; break;
                case 885: _country = "Thailand"; break;
                case 888: _country = "Singapore"; break;
                case 890: _country = "India"; break;
                case 893: _country = "Vietnam"; break;
                case 894: _country = "Bangladesh"; break;
                case 896: _country = "Pakistan"; break;
                case 899: _country = "Indonesia"; break;
                case int n when ((n >= 900) && (n <= 919)): _country = "Austria"; break;
                case int n when ((n >= 930) && (n <= 939)): _country = "Australia"; break;
                case int n when ((n >= 940) && (n <= 949)): _country = "New Zealand"; break;
                case 950: _country = "GS1 Global Office: Special applications"; break;
                case 951: _country = "Used to issue General Manager Numbers for the EPC General Identifier (GID) scheme as defined by the EPC Tag Data Standard"; break;
                case 952: _country = "Used for demonstrations and examples of the GS1 system"; break;
                case 955: _country = "Malaysia"; break;
                case 958: _country = "Macau"; break;
                case int n when ((n >= 960) && (n <= 961)): _country = "GS1 UK Office: GTIN-8 allocations"; break;
                case int n when ((n >= 962) && (n <= 969)): _country = "GS1 Global Office: GTIN-8 allocations"; break;
                case 977: _country = "Serial publications (ISSN)"; break;
                case int n when ((n >= 978) && (n <= 979)): _country = "Bookland (ISBN)"; break;
                case 980: _country = "Refund receipts"; break;
                case int n when ((n >= 981) && (n <= 984)): _country = "GS1 coupon identification for common Euro currency areas"; break;
                case int n when ((n >= 990) && (n <= 999)): _country = "GS1 coupon identification"; break;

                default:
                    _country = "Reserved by GS1 Global Office for allocations in countries where there is no GS1 Member Organisation and for future use within the GS1 system";
                    break;
            }
            
            return _country;
        }




    }
}
