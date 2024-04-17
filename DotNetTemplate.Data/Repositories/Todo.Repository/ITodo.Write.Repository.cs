using System;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Presentation.DTOs;

namespace DotNetTemplate.Data.Interfaces;

public interface ITodoWriteRepository : IBaseWriteRepository<Guid, Todo> { }