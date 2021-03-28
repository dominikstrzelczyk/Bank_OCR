

using System.Collections.Generic;
using Bank_OCR.Services;
using Bank_OCR.Services.Interfaces;
using NUnit.Framework;

namespace BankOCR.Tests.Services
{
    class AccountNumberServiceTests
    {
        private IAccountNumberService _accountNumberService;

        [SetUp]
        public void Setup()
        {
            _accountNumberService = new AccountNumberService();
        }

        [TestCase("    _  _     _  _  _  _  _ " + "\r\n" +
                  "  | _| _||_||_ |_   ||_||_|" + "\r\n" +
                  "  ||_  _|  | _||_|  ||_| _|")]
        public void GetAccountNumbers_Account_Number_Test(string data)
        {
            var accountNumber = _accountNumberService.GetAccountNumbers(data);

            var restult = new List<string[]>();
            string[] chars = new[]
            {
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|"
            };
            restult.Add(chars);

            Assert.AreEqual(accountNumber, restult);

        }
        [Test]
        public void GetDigits_Tests()
        {
            string[] chars = new[]
            {
                "    _  _     _  _  _  _  _ ",
                "  | _| _||_||_ |_   ||_||_|",
                "  ||_  _|  | _||_|  ||_| _|"
            };

            var result =_accountNumberService.GetDigits(chars);

            Assert.AreEqual(9,result.Count);
            Assert.AreEqual(result[0], "     |  |");
            Assert.AreEqual(result[1], " _  _||_ ");
            Assert.AreEqual(result[2], " _  _| _|");
            Assert.AreEqual(result[3], "   |_|  |");
            Assert.AreEqual(result[4], " _ |_  _|");
            Assert.AreEqual(result[5], " _ |_ |_|");
            Assert.AreEqual(result[6], " _   |  |");
            Assert.AreEqual(result[7], " _ |_||_|");
            Assert.AreEqual(result[8], " _ |_| _|");
        }
    }
}
