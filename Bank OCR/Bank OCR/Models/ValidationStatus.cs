using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_OCR.Models
{
    public enum ValidationStatus
    {
        Valid,
        InvalidLength,
        InvalidChecksum,
        InvalidCharacter
    }
}
