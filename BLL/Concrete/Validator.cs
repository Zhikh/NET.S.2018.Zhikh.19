using System.Text.RegularExpressions;
using BLL.Interface;

namespace BLL.Concrete
{
    public sealed class Validator : IValidator<string>
    {
        private readonly string _uriPattern = @"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";

        public bool IsValid(string value) 
            => Regex.IsMatch(value, _uriPattern, RegexOptions.IgnoreCase);
    }
}
