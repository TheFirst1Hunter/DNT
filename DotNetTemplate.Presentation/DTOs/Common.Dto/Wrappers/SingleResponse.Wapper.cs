using DotNetTemplate.Data.DTOs;

namespace DotNetTemplate.Presentation.DTOs;

public class SingleResponseWrapper<TKey, TEntity>
where TEntity : BaseSingleDto<TKey>, new()
{
    public TEntity Data { get; set; }
    public String Message { get; set; }
    public bool Error { get; set; }

    public SingleResponseWrapper(TEntity _data, String _message, bool _err = false)
    {
        Data = _data;
        Message = _message;
        Error = _err;
    }
}