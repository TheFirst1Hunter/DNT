using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Presentation.DTOs;

public class BaseListDto<TKey>
{
    public TKey Id { set; get; }
}