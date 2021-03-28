using System;
using System.Linq;
using Bank_OCR.Models;
using Bank_OCR.Services.Interfaces;

namespace Bank_OCR.Services
{
    public class AccountValidatorService: IAccountValidatorService
    {
        private const int ACCOUNT_NUMBER_LENGTH = 9;

        public ValidationStatus Validate(string number)
        {
            if (IsInvalidLength(number))
            {
                return ValidationStatus.InvalidLength;
            }

            if (CheckIsInvalidDigits(number))
            {
                return ValidationStatus.InvalidCharacter;
            }

            if (IsInvalidChecksum(number))
            {
                return ValidationStatus.InvalidChecksum;
            }


            return ValidationStatus.Valid;
        }

        private bool IsInvalidLength(string number)
        {
            return number.Length != ACCOUNT_NUMBER_LENGTH;
        }

        private bool CheckIsInvalidDigits(string accountNumber)
        {
            return accountNumber.Any(c => !char.IsDigit(c));
        }

        private bool IsInvalidChecksum(string number)
        {
            var sum = 0;
            for (var i = 0; i < number.Length; i++)
            {
                var charNumber = number[i];
                sum += (int)char.GetNumericValue(charNumber) * (9 - i);

            }
            var checksum = sum % 11;

            return checksum != 0;

        }

    }
}
