using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlogSitesi.BL.StaticMethods
{
    public class RegexControl
    {
        //(?=(?:.*[A-Z]){2,}):
        //En az 2 büyük harf zorunluluğu.
        //(?=(?:.*[a-z]){3,}):
        //En az 3 küçük harf zorunluluğu.
        //(?=(?:.*[@!:+*]){2,}):
        //Belirtilen özel karakterlerden en az 2 tanesi zorunluluğu.
        //[A-Za-z\d@!:+*]{ 8,}:
        //Şifrenin en az 8 karakter uzunluğunda olması.
        public static bool SifreGucluMu(string sifre)
        {
            string pattern = @"^(?=(?:.*[A-Z]){2,})(?=(?:.*[a-z]){3,})(?=(?:.*[@!:+*]){2,})[A-Za-z\d@!:+*]{8,}$";
            return Regex.IsMatch(sifre, pattern) ? true : false;
        }
    }
}
