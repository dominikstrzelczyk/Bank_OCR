using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_OCR.Services.Interfaces
{
    public interface IAccountNumberService
    {
        List<string[]> GetAccountNumbers(string data);

        List<string> GetDigits(string[] lines);
    }
}
