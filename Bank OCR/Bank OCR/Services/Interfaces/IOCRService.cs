
using System.Collections.Generic;
using Bank_OCR.Models;

namespace Bank_OCR.Services.Interfaces
{
    public interface IOCRService
    {
        List<AccountNumber> ParseNumbers(string data);
    }
}
