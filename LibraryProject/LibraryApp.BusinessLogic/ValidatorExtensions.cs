using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
