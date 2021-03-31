using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MarathonSkills.DesktopApp.Converters
{
    public class CardNumberConverter : IValueConverter
    {
        private static readonly Regex CardNumberRegex = new(@"^(\d{0,4})(\d{0,4})(\d{0,4})(\d{0,4})$");

        /// <summary>
        /// Возвращает 1-4 цифры номера карты с пробелом перед ним.
        /// </summary>
        /// <param name="fourDigits"></param>
        /// <returns></returns>
        private static string GetNumberPart(string fourDigits) =>
            string.IsNullOrWhiteSpace(fourDigits) ? "" : $" {fourDigits}";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cardNumberRaw = (string) value ?? "";
            var groups = CardNumberRegex.Match(cardNumberRaw).Groups;
            return $"{groups[1].Value}{GetNumberPart(groups[2].Value)}" +
                   $"{GetNumberPart(groups[3].Value)}{GetNumberPart(groups[4].Value)}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cardNumberConverted = (string) value ?? "";
            return cardNumberConverted.Replace(" ", "");
        }
    }
}
