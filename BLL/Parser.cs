using BLL.Interface;
using System;
using System.Collections.Generic;
namespace BLL
{
    public sealed class Parser : IParser<Uri>
    {
        private IValidator<string, Uri> _validator;
        private ILogger _logger;

        public Parser()
        {
            _validator = new Validator();
            _logger = new Logger();
        }

        public Parser(IValidator<string, Uri> validator, ILogger logger)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<Uri> Parse(string value)
        {
            var lines = value.Split(new string[] { "\n" }, StringSplitOptions.None);

            foreach (var line in lines)
            {
                Uri result = null;

                try
                {
                    result = _validator.Validate(line);
                }
                catch(Exception ex)
                {

                }

                if (result != null)
                {
                    yield return result;
                }
            }
        }
    }
}
