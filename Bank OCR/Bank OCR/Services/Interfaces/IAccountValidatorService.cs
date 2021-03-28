
using Bank_OCR.Models;

namespace Bank_OCR.Services.Interfaces
{
    public interface IAccountValidatorService
    {
        ValidationStatus Validate(string number);
    }
}
