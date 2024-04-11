namespace DotNetTemplate.Application.Auth.Policies;

public class BasePolicy
{
    public BasePolicy(string entity)
    {
        List = $"List:{entity}";
        Read = $"Read:{entity}";
        Create = $"Create:{entity}";
        Update = $"Update:{entity}";
        Delete = $"Delete:{entity}";
        Mutate = $"Mutate:{entity}";
        Fetch = $"Fetch:{entity}";
        All = $"All:{entity}";
    }

    public string List;
    public string Read;
    public string Create;
    public string Update;
    public string Delete;
    public string Fetch;
    public string Mutate;
    public string All;
}

