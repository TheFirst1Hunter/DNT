using DotNetTemplate.Data.DTOs;

namespace DotNetTemplate.Presentation.DTOs;

public class PaginatedResponseWrapper<TKey, TEntity>
where TEntity : BaseListDto<TKey>, new()
{
    public List<TEntity> Data { get; }
    public int TotalCount { get; }
    public int Skip { get; }
    public int Take { get; }
    public int TotalPages { get; }

    public PaginatedResponseWrapper(List<TEntity> data, int totalCount, int skip, int take)
    {
        Data = data;
        TotalCount = totalCount;
        Skip = skip;
        Take = take;
        TotalPages = (int)Math.Ceiling((double)totalCount / take);
    }

}