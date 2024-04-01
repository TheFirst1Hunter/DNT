using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Presentation.DTOs;

public class BaseSingleDto<TKey>
{
    public TKey Id { set; get; }
}