using System;

namespace DotNetTemplate.Presentation.DTOs;

public class BaseQueryDto
{
    public int Skip { set; get; } = 0;
    public int Take { set; get; } = 10;
}