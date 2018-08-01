using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public sealed class Validator : IValidator<string, Uri>
    {
        public Uri Validate(string value)
        {
            throw new NotImplementedException();
        }
    }
}
