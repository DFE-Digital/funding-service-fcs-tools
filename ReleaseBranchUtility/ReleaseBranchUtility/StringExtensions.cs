namespace ReleaseBranchUtility
{
    using System;
    using System.Linq;

    public static class StringExtensions
    {
        public static (int numberPart, string suffix) GetNumberPartAndSuffix(this string text)
        {
            var numberPartChars = text.Where(Char.IsDigit).ToArray();
            var suffixChars = text.Where(c => !Char.IsDigit(c)).ToArray();
            string numberPartString = new string(numberPartChars);

            return (numberPart: int.Parse(numberPartString), suffix: new string(suffixChars));
        }
    }
}
