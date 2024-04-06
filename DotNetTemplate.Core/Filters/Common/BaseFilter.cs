using System;

namespace DotNetTemplate.Core.Filters;

public class BaseFilter
{
    public int Skip { set; get; } = 0;
    public int Take { set; get; } = 10;
}