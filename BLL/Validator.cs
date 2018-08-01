using BLL.Interface;
using System;

namespace BLL
{
    public sealed class Validator : IValidator<string, Uri>
    {
        public Uri Validate(string value)
        {
            return new Uri(value);
        }
    }
}
