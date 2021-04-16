using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Declara_V2.Exceptions
{
    public class NonPaginatedException : CustomException
    {
        private const String StrMessage = "Se debe establecer un tamaño de página";
        public NonPaginatedException() : base(StrMessage, new Exception(StrMessage)) { }

        private NonPaginatedException(String message) : base(message) { }

        private NonPaginatedException(String message, Exception innerException) : base(message, innerException) { }
    }
}
