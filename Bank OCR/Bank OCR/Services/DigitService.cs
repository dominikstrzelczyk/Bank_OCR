using System.Collections.Generic;
using Bank_OCR.Services.Interfaces;

namespace Bank_OCR.Services
{
    public class DigitService: IDigitService
    {
        private Dictionary<string, string> _numberCodes;

        public DigitService()
        {
            _numberCodes = new()
            {
                { " _ | ||_|", "0" },
                { "     |  |", "1" },
                { " _  _||_ ", "2" },
                { " _  _| _|", "3" },
                { "   |_|  |", "4" },
                { " _ |_  _|", "5" },
                { " _ |_ |_|", "6" },
                { " _   |  |", "7" },
                { " _ |_||_|", "8" },
                { " _ |_| _|", "9" },
            };
        }


        public string Parse(string digit)
        {
            if (_numberCodes.ContainsKey(digit))
            {
                return _numberCodes[digit];
            }

            return null;
        }
    }
}
