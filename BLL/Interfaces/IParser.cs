using System.Collections.Generic;

namespace BLL.Interface
{
    public interface IParser<out TResult>
    {
        TResult Parse(string value);
    }
}
