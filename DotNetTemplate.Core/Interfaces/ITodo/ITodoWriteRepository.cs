using System;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Core.Filters;

namespace DotNetTemplate.Core.Interfaces;

public interface ITodoWriteRepository : IBaseWriteRepository<Guid, Todo> { }