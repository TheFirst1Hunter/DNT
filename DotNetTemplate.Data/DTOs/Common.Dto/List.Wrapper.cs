using DotNetTemplate.Core.Entities;

namespace DotNetTemplate.Data.DTOs;

public class CountRepositoryWrapper<TKey, TEntity>
where TEntity : BaseListDto<TKey>, new()

{
    public List<TEntity> Data { get; set; }
    public int Count { get; set; }

    public CountRepositoryWrapper(List<TEntity> _data, int _count)
    {
        Data = _data;
        Count = _count;
    }

}