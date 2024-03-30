using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Api.DTOs;

public class BaseListDto<TKey>
{
    public TKey Id { set; get; }
}