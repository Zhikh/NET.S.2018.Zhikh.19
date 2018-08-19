using System.Text.RegularExpressions;
using BLL.Interface;

namespace BLL.Concrete
{
    public sealed class Validator : IValidator<string>
    {
        #region Constants
        private const string _uriPattern = @"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";
        #endregion

        #region Public Api
        /// <summary>
        /// Checks value on valid
        /// </summary>
        /// <param name="value"> Value to check </param>
        /// <returns> If value is valid, it's true, else - false </returns>
        public bool IsValid(string value) 
            => Regex.IsMatch(value, _uriPattern, RegexOptions.IgnoreCase);
        #endregion
    }
}
