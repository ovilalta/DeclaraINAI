using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Declara_V2.Exceptions
{
    public class RowNotFoundException : CustomException
    {
        private const String StrMessage = "No se encontró el registro";
        public RowNotFoundException() : base(StrMessage, new Exception(StrMessage)) { }

        private RowNotFoundException(String message) : base(message) { }

        private RowNotFoundException(String message, Exception innerException) : base(message, innerException) { }
    }
}
