using NumberToWords.Services;

namespace NumberToWordsTests
{
    [TestClass]
    public class NumberToWordsControllerTests
    {
        [TestMethod]
        public void TestConvertNumberToWords()
        {
            var ConvertN2WService = new ConvertNumberToWords();

            // Test cases with expected results
            var testCases = new (decimal number, string expectedWords)[]
            {
                (0, "ZERO"),
                (1, "ONE DOLLAR"),
                (1.01m, "ONE DOLLAR AND ONE CENT"),
                (12, "TWELVE DOLLARS"),
                (123, "ONE HUNDRED TWENTY-THREE DOLLARS"),
                (1234, "ONE THOUSAND TWO HUNDRED THIRTY-FOUR DOLLARS"),
                (12345, "TWELVE THOUSAND THREE HUNDRED FORTY-FIVE DOLLARS"),
                (123456, "ONE HUNDRED TWENTY-THREE THOUSAND FOUR HUNDRED FIFTY-SIX DOLLARS"),
                (1234567, "ONE MILLION TWO HUNDRED THIRTY-FOUR THOUSAND FIVE HUNDRED SIXTY-SEVEN DOLLARS"),
                (-1234567, "MINUS ONE MILLION TWO HUNDRED THIRTY-FOUR THOUSAND FIVE HUNDRED SIXTY-SEVEN DOLLARS"),
                (1000000.00m, "ONE MILLION DOLLARS"),
                (1000000.01m, "ONE MILLION DOLLARS AND ONE CENT"),
                (1000000.1m, "ONE MILLION DOLLARS AND TEN CENTS"),
                (1000000.10m, "ONE MILLION DOLLARS AND TEN CENTS"),
                (1000000.99m, "ONE MILLION DOLLARS AND NINETY-NINE CENTS")
            };

            // Act & Assert
            foreach (var testCase in testCases)
            {
                string words = ConvertN2WService.Convert(testCase.number);
                var equalTo = testCase.expectedWords == words;
                Assert.AreEqual(testCase.expectedWords, words);
            }
        }
    }
}
