using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class ErrorMessage
    {
        public const string NOT_FOUND_RECORD_ID = "{0} with id: {1} not found";
        public const string NOT_FOUND_RECORD = "{0} with {1}: {2} not found";
        public const string NOT_VALID = "{0} are mandatory";
    }
}
