using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_OCR.Models
{
    public class AccountNumber
    {
        public string Number { get; set; }

        public ValidationStatus ValidationStatus { get; set; }
    }
}
