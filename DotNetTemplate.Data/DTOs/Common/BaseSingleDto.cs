using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Data.DTOs;

public class BaseSingleDto<TKey>
{
    public TKey Id { set; get; }
}