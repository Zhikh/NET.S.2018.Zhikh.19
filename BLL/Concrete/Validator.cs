using BLL.Interface;
using System;
using System.Text.RegularExpressions;

namespace BLL
{
    public sealed class Validator : IValidator<string>
    {
        private readonly string _uriPattern = @"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";

        public bool IsValid(string value) 
            => Regex.IsMatch(value, _uriPattern, RegexOptions.IgnoreCase);
    }
}
