using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CustomLibrary.Helper
{
    public class RegexUtils
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool IsValidPhoneNumber(string number, out string formattednumber)
        {
            formattednumber = null;
            if (string.IsNullOrWhiteSpace(number))
                return false;

            var unwantedCharacters = new string[] { " ", "-", "+", ".", "(", ")" };
            // hilangkan karakter dalam nomor hp yang diperbolehkan 
            foreach (var item in unwantedCharacters)
            {
                if (number.Contains(item)) number = number.Replace(item, string.Empty);
            }
            // rubah format 62 ke 0
            if (number.StartsWith("62"))
            {
                // hilangkan karakter 62
                number = number[2..];
                // tambahkan karakter 0 ke nomor hp
                number = number.Insert(0, "0");
            }

            try
            {
                formattednumber = number;
                return Regex.IsMatch(number, "^0[0-9]{9,13}$",
                    RegexOptions.None, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}