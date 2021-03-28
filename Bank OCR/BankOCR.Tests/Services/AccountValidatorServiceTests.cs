
using Bank_OCR.Models;
using Bank_OCR.Services;
using Bank_OCR.Services.Interfaces;
using NUnit.Framework;

namespace BankOCR.Tests.Services
{
    class AccountValidatorServiceTests
    {
        private IAccountValidatorService _accountValidatorService;

        [SetUp]
        public void Setup()
        {
            _accountValidatorService = new AccountValidatorService();
        }

        [TestCase("123456789", ExpectedResult = ValidationStatus.Valid)]
        [TestCase("12345678", ExpectedResult = ValidationStatus.InvalidLength)]
        [TestCase(" 12345678", ExpectedResult = ValidationStatus.InvalidCharacter)]
        [TestCase("111111111", ExpectedResult = ValidationStatus.InvalidChecksum)]
        public ValidationStatus ValidateTests(string number)
        {
            return _accountValidatorService.Validate(number);
        }

    }
}
