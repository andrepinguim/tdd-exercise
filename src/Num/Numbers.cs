using System;
using System.Collections.Generic;

namespace Num
{
    public class Numbers
    {
        private static Dictionary<int, string> largeDic = new Dictionary<int, string>()
        {
            {0, ""},
            {3, ""},
            {6, "mil"},
            {9, "milhões"},
            {12, "bilhões"},
            {15, "trilhões"},
            {18, "quatrilhões"},
            {21, "quintilhões"}
        };

        private static Dictionary<Int64, string> dic = new Dictionary<Int64, string>()
        {
            {0, "zero"},
            {1, "um"},
            {2, "dois"},
            {3, "três"},
            {4, "quatro"},
            {5, "cinco"},
            {6, "seis"},
            {7, "sete"},
            {8, "oito"},
            {9, "nove"},
            {10, "dez"},
            {11, "onze"},
            {12, "doze"},
            {13, "treze"},
            {14, "quatorze"},
            {15, "quinze"},
            {16, "dezesseis"},
            {17, "dezessete"},
            {18, "dezoito"},
            {19, "dezenove"},
            {20, "vinte"},
            {30, "trinta"},
            {40, "quarenta"},
            {50, "cinquenta"},
            {60, "sessenta"},
            {70, "setenta"},
            {80, "oitenta"},
            {90, "noventa"},
            {100, "cem"},
            {200, "duzentos"},
            {300, "trezentos"},
            {400, "quatrocentos"},
            {500, "quinhentos"},
            {600, "seiscentos"},
            {700, "setecentos"},
            {800, "oitocentos"},
            {900, "novecentos"}
        };

        private const string _SEPARATOR = " e ";

        public string Write(Int64 n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException($"Apenas valores maiores que 0 são permitidos");

            if (n < 20)
                return dic[n];

            var num = n.ToString();

            if (num.Length > 3)
            {
                var adjust = num.Length % 3;
                if (adjust != 0)
                    num = num.PadLeft((3 - adjust) + num.Length, '0');

                var originalLength = num.Length;
                var ar = new List<string>();
                while (num.Length != 0)
                {
                    var newNum = num.Substring(num.Length - 3);
                    num = num.Substring(0, num.Length - 3);

                    ar.Add(newNum);
                }

                ar.Reverse();

                var resultParcial = string.Empty;
                for (int i = 0; i < ar.Count; i++)
                {
                    if (ar[i] == "000")
                    {
                        originalLength = originalLength - 3;
                        continue;
                    }

                    var value = Convert.ToInt16(ar[i]);

                    resultParcial += (value < 20)
                        ? $"e {Write(value)} {largeDic[originalLength]} "
                        : $"{Write(value)} {largeDic[originalLength]} ";

                    originalLength = originalLength - 3;
                }

                return resultParcial.TrimStart("e ".ToCharArray()).Trim();
            }

            var result = string.Empty;
            var len = num.Length;

            for (int i = 0; i <= num.Length - 1 && len >= 0; i++)
            {
                var x = num[i].ToString();
                if (x == "0")
                {
                    len--;
                    continue;
                }

                string digit;
                if (x == "1" && len == 2)
                {
                    digit = num.Substring(1);

                    result += string.IsNullOrEmpty(result)
                        ? $"{dic[Convert.ToInt32(digit)]}"
                        : $"{_SEPARATOR}{dic[Convert.ToInt32(digit)]}";

                    break;
                }

                digit = x.PadRight(len, '0');

                result += string.IsNullOrEmpty(result)
                    ? $"{dic[Convert.ToInt32(digit)]}"
                    : $"{_SEPARATOR}{dic[Convert.ToInt32(digit)]}";

                len--;
            }

            return (n > 99 && n < 200)
                ? result.Replace("cem e ", "cento e ")
                : result;
        }
    }
}
