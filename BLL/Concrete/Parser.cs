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

        public IEnumerable<Uri> Parse(IEnumerable<string> values)
        {
            List<Uri> list = new List<Uri>();

            foreach (var value in values)
            {
                Uri result = null;

                try
                {
                    result = _validator.Validate(value);
                }
                catch(Exception ex)
                {
                    // TODO: save in logger
                }

                if (result != null)
                {
                    list.Add(result);
                }
            }

            return list;
        }
    }
}
