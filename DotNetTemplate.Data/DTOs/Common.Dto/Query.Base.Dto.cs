using System;

namespace DotNetTemplate.Data.DTOs;

public class BaseQuery
{
    public int Skip { set; get; } = 0;
    public int Take { set; get; } = 10;
}