﻿using System.Collections.Generic;

namespace BLL.Interface
{
    public interface IParser<out TResult>
    {
        IEnumerable<TResult> Parse(string value);
    }
}
