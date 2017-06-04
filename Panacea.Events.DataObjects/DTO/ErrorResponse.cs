using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Panacea.Events.DataObjects.DTO
{
    public class ErrorResponse
    {
        private string _ErrorCode;
        private string _ErrorDescription;

        [DataMember(Name = "ErrorCode")]
        public string ErrorCode { get { return _ErrorCode; } set { _ErrorCode = value; } }

        [DataMember(Name = "ErrorDescription")]
        public string ErrorDescription { get { return _ErrorDescription; } set { _ErrorDescription = value; } }
    }
}
