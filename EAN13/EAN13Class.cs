using System;
using System.Text.RegularExpressions;

namespace EAN13
{
    class EAN13Class
    {

        public static string Barcode13Digits = "";

        public static string EAN13(string DataString)
        {
            int i;
            int first;
            int checkSum = 0;
            string Barcode = "";
            bool tableA;

            if (Regex.IsMatch(DataString, "^\\d{12}$"))
            {
                for (i = 1; i < 12; i += 2)
                {
                    System.Diagnostics.Debug.WriteLine(DataString.Substring(i, 1));
                    checkSum += Convert.ToInt32(DataString.Substring(i, 1));
                }

                checkSum *= 3;

                for (i = 0; i < 12; i += 2)
                {
                    checkSum += Convert.ToInt32(DataString.Substring(i, 1));
                }

                DataString += (10 - checkSum % 10) % 10;

                Barcode13Digits = DataString.ToString();

                Barcode = DataString.Substring(0, 1) + (char) (65 + Convert.ToInt32(DataString.Substring(1, 1)));
                first = Convert.ToInt32(DataString.Substring(0, 1));

                for (i = 2; i <= 6; i++)
                {

                    tableA = false;

                    switch (i)
                    {
                        case 2:
                            if (first >= 0 && first <= 3) tableA = true;
                            break;
                        case 3:
                            if (first == 0 || first == 4 || first == 7 || first == 8) tableA = true;
                            break;
                        case 4:
                            if (first == 0 || first == 1 || first == 4 || first == 5 || first == 9) tableA = true;
                            break;
                        case 5:
                            if (first == 0 || first == 2 || first == 5 || first == 6 || first == 7) tableA = true;
                            break;
                        case 6:
                            if (first == 0 || first == 3 || first == 6 || first == 8 || first == 9) tableA = true;
                            break;
                    }

                    if (tableA)
                    {
                        Barcode += (char) (65 + Convert.ToInt32(DataString.Substring(i, 1)));

                    }
                    else
                    {
                        Barcode += (char) (75 + Convert.ToInt32(DataString.Substring(i, 1)));
                    }

                }

                Barcode += "*";

                for (i = 7; i <= 12; i++)
                {
                    Barcode += (char) (97 + Convert.ToInt32(DataString.Substring(i, 1)));
                }

                Barcode += "+";

            }

            return Barcode;

        }



		public static string ExtendedData(string extendedData)
		{
			//  'Parameters : A 2 or 5 digits length string
			//  'Return : * a string which give the add-on bar code when it is dispayed with EAN13.TTF font
			//  '         * an empty string if the supplied parameter is no good

			
			int i;
			int checksum = 0;
			bool tableA;
			string _extendedData = "";

			//  'Check for 2 or 5 characters 'And it is digits
			if (Regex.IsMatch(extendedData, "^\\d{2}$") || Regex.IsMatch(extendedData, "^\\d{5}$"))
			{
				// Checksum calculation
				if (extendedData.Length == 2)
					checksum = 10 + Convert.ToInt32(extendedData) % 4;
				else
				{
					for (i = 0; i < 5; i += 2)
					{
						checksum += Convert.ToInt32(extendedData.Substring(i, 1));
					}
					checksum = (checksum * 3 + Convert.ToInt32(extendedData.Substring(1, 1)) * 9 + Convert.ToInt32(extendedData.Substring(3, 1)) * 9) % 10;
				}
				_extendedData = "[";

				for (i = 0; i < extendedData.Length; i++)
				{
					tableA = false;
					switch (i)
					{
						case 0:
							if ((checksum >= 4 && checksum <= 9) || checksum == 10 || checksum == 11) tableA = true;
							break;
						case 1:
							if (checksum == 1 || checksum == 2 || checksum == 3 || checksum == 5 || checksum == 6
								|| checksum == 9 || checksum == 10 || checksum == 12) tableA = true;
							break;
						case 2:
							if (checksum == 0 || checksum == 2 || checksum == 3 || checksum == 6
								|| checksum == 7 || checksum == 8) tableA = true;
							break;
						case 3:
							if (checksum == 0 || checksum == 1 || checksum == 3 || checksum == 4
								|| checksum == 8 || checksum == 9) tableA = true;
							break;
						case 4:
							if (checksum == 0 || checksum == 1 || checksum == 2 || checksum == 4
								|| checksum == 5 || checksum == 7) tableA = true;
							break;
					}
					if (tableA)
						_extendedData += (char)(65 + Convert.ToInt32(extendedData.Substring(i, 1)));
					else
						_extendedData += (char)(75 + Convert.ToInt32(extendedData.Substring(i, 1)));

					if ((extendedData.Length == 2 && i == 0) || (extendedData.Length == 5 && i < 4)) _extendedData += (char)(92); // Add character separator
				}
			}
			return _extendedData;
		}
	}
}