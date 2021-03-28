using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_OCR.Services.Interfaces;

namespace Bank_OCR.Services
{
    public class AccountNumberService: IAccountNumberService
    {
        private const int CHARS_PER_CHARACTER = 3;
        private const int LINE_LENGTH = 27;

        public List<string[]> GetAccountNumbers(string data)
        {
            var lines = data.Split("\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim('\r'))
                .ToArray();

            var numbers = new List<string[]>();
            for (int i = 0; i < lines.Length; i += 4)
                numbers.Add(lines.Skip(i).Take(3).ToArray());
            return numbers;
        }

        public List<string> GetDigits(string[] lines)
        {
            var digits = new List<string>();
            for (var i = 0; i < LINE_LENGTH; i += CHARS_PER_CHARACTER)
            {
                var sb = new StringBuilder();
                for (var y = 0; y < CHARS_PER_CHARACTER; y++)
                    sb.Append(string.Concat(lines[y].Skip(i).Take(CHARS_PER_CHARACTER)));

                digits.Add(sb.ToString());
            }

            return digits;
        }
    }
}
