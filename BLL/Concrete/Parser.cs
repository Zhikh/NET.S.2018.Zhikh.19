using System;
using BLL.Interface;

namespace BLL.Concrete
{
    public sealed class Parser : IParser<Uri>
    {
        #region Fields
        private IValidator<string> _validator;
        #endregion

        #region Public API
        /// <summary>
        /// Initializes a new instance of the <see cref="Parser" /> with default validator.
        /// </summary>
        public Parser()
        {
            _validator = new Validator();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parser" /> with custom validator.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="validator"> is null. </paramref>
        /// </exception>
        public Parser(IValidator<string> validator)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        /// <summary>
        /// Parses string value
        /// </summary>
        /// <param name="value"> String to parse </param>
        /// <returns> Result of parsing </returns>
        /// <exception cref="ArgumentException"> 
        ///     <paramref name="value"> is invalid. </paramref>
        /// </exception>
        public Uri Parse(string value)
        {
            if (!_validator.IsValid(value))
            {
                throw new ArgumentException($"The {nameof(value)} = {value} is invalid!");
            }

            return new Uri(value);
        }
        #endregion
    }
}
