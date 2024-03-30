using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Api.DTOs;

public class BaseSingleDto<TKey>
{
    public TKey Id { set; get; }
}