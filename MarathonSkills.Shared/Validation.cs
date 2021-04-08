using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarathonSkills.Shared
{
    public static class Validation
    {
        public static bool IsValidEmail(string email) =>
            email is not null &&
            Regex.IsMatch(email, @"^[^@]+@[^@\.]+\.[^@\.]+$", RegexOptions.IgnoreCase);

        public static bool IsValidPassword(string password)
        {
            if (password is null) return false;
            var lengthMatch = password.Length >= 6;
            var letterMatch = Regex.IsMatch(password, @"[a-zа-яё]+", RegexOptions.IgnoreCase);
            var digitMatch = Regex.IsMatch(password, @"[0-9]+");
            var specialCharactersMatch = Regex.IsMatch(password, @"[:!@#\$%\^]+");
            return lengthMatch && letterMatch && digitMatch && specialCharactersMatch;
        }
    }
}
