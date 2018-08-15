using System;
using BLL.Interface;

namespace BLL.Concrete
{
    public sealed class Parser : IParser<Uri>
    {
        private IValidator<string> _validator;

        public Parser()
        {
            _validator = new Validator();
        }

        public Parser(IValidator<string> validator)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public Uri Parse(string value)
        {
            if (!_validator.IsValid(value))
            {
                throw new ArgumentException($"The {nameof(value)} = {value} is invalid!");
            }

            return new Uri(value);
        }
    }
}
