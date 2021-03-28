
using Bank_OCR.Services;
using Bank_OCR.Services.Interfaces;
using NUnit.Framework;

namespace BankOCR.Tests.Services
{
    class DigitServiceTests
    {
        private IDigitService _digitService;

        [SetUp]
        public void Setup()
        {
            _digitService = new DigitService();
        }

        [TestCase(" _ " +
                  "| |" +
                  "|_|", ExpectedResult = "0")]
        [TestCase("   " +
                  "  |" +
                  "  |", ExpectedResult = "1")]
        [TestCase(" _ " +
                  " _|" +
                  "|_ ", ExpectedResult = "2")]
        [TestCase(" _ " +
                  " _|" +
                  " _|", ExpectedResult = "3")]
        [TestCase("   " +
                  "|_|" +
                  "  |", ExpectedResult = "4")]
        [TestCase(" _ " +
                  "|_ " +
                  " _|", ExpectedResult = "5")]
        [TestCase(" _ " +
                  "|_ " +
                  "|_|", ExpectedResult = "6")]
        [TestCase(" _ " +
                  "  |" +
                  "  |", ExpectedResult = "7")]
        [TestCase(" _ " +
                  "|_|" +
                  "|_|", ExpectedResult = "8")]
        [TestCase(" _ " +
                  "|_|" +
                  " _|", ExpectedResult = "9")]
        public string Parse(string digit)
        {
            return _digitService.Parse(digit);
        }
    }
}
