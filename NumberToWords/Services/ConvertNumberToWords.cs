namespace NumberToWords.Services
{
    // This class provides functionality to convert currency numeric values into their equivalent English words representation.
    public class ConvertNumberToWords
    {
        // Arrays to map number values to their corresponding word representations.
        private static readonly string[] Units = { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
        private static readonly string[] Tens = { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

        // Main method to convert a decimal number to its word representation.
        // 'recursive' flag determines if `Convert` function is called recursively or not.
        public string Convert(decimal number, bool recursive = false)
        {
            // Handle special case where the number is zero.
            if (number == 0)
            {
                return recursive ? "" : "ZERO";
            }
            // Handle negative numbers by prefixing with "MINUS".
            else if (number < 0)
            {
                return "MINUS " + Convert(Math.Abs(number), false);
            }

            // Initialize an empty string to build the word representation.
            string words = "";

            // Handle millions place, if applicable.
            if ((number / 1000000) >= 1)
            {
                words += Convert(Math.Truncate(number / 1000000), true) + " MILLION ";
                number %= 1000000; // Remove the millions place from the number.
            }

            // Handle thousands place, if applicable.
            if ((number / 1000) >= 1)
            {
                words += Convert(Math.Truncate(number / 1000), true) + " THOUSAND ";
                number %= 1000; // Remove the thousands place from the number.
            }

            // Handle hundreds place, if applicable.
            if ((number / 100) >= 1)
            {
                words += Convert(Math.Truncate(number / 100), true) + " HUNDRED ";
                number %= 100; // Remove the hundreds place from the number.
            }

            // Handle the remainder of the number.
            if (number >= 1)
            {
                if (number < 20)
                {
                    words += Units[(int)number] + " "; // Numbers less than 20 are directly mapped to units.
                }
                else
                {
                    // Numbers 20 and above are processed using tens and units.
                    words += Tens[(int)Math.Truncate(number / 10)];
                    if ((number % 10) > 0)
                    {
                        words += "-" + Units[(int)(number % 10)] + " ";
                    }
                }
            }

            // For non-recursive calls, add the dollar part and handle cents if needed.
            if (!recursive)
            {
                // Add "DOLLAR" or "DOLLARS" based on the number of dollars.
                words += (words.Trim() == "ONE") ? "DOLLAR" : "DOLLARS";

                // Process cents if there are any.
                decimal cent = (number * 100) % 100;
                if (cent > 0)
                {
                    string centPart = Convert(cent, true); // Convert cents as a fractional part.
                    words += " AND " + centPart + (cent == 1 ? " CENT" : " CENTS");
                }
            }

            // Return the final word representation, trimmed of any extraneous whitespace.
            return words.Trim();
        }
    }
}
