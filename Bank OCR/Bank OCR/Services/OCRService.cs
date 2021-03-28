using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bank_OCR.Models;
using Bank_OCR.Services.Interfaces;

namespace Bank_OCR.Services
{
    public class OCRService : IOCRService
    {
        private readonly IDigitService _digitService;
        private readonly IAccountValidatorService _accountValidatorService;
        private readonly IAccountNumberService _accountNumberService;

        public OCRService()
        {
            _digitService = new DigitService();
            _accountValidatorService = new AccountValidatorService();
            _accountNumberService = new AccountNumberService();
        }

        public List<AccountNumber> ParseNumbers(string data)
        {
            var parsedAccountNumbers = new List<AccountNumber>();
            var accountNumbers = _accountNumberService.GetAccountNumbers(data);

            foreach (var accountNumber in accountNumbers)
            {
                var parsedAccountNumber = new AccountNumber();

                var digits = _accountNumberService.GetDigits(accountNumber);

                foreach (var digit in digits)
                {
                    parsedAccountNumber.Number += _digitService.Parse(digit);
                }

                parsedAccountNumber.ValidationStatus = _accountValidatorService.Validate(parsedAccountNumber.Number);
                parsedAccountNumbers.Add(parsedAccountNumber);
            }

            return parsedAccountNumbers;
        }

    }
}
