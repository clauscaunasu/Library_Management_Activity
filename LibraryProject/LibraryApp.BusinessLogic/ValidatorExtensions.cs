using System;
using System.Net.Mail;

namespace LibraryApp.BusinessLogic
{
    public class ValidatorExtensions
    {
        public static bool IsValidEmailAddress(string s)
        {
            try
            {
                var m = new MailAddress(s);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
