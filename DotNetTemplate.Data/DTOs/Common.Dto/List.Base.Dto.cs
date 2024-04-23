using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Data.DTOs;

public class BaseListDto<TKey>
{
    public TKey Id { set; get; }
    public DateTime CreatedAt { set; get; }
}