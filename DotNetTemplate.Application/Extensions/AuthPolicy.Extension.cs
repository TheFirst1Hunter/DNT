using Microsoft.AspNetCore.Authorization;
using DotNetTemplate.Application.Auth.Policies;


public static class AuthorizationOptionsExtensions
{
    public static void AddBasePolicies<T>(this AuthorizationOptions options, T basePolicy) where T : BasePolicy
    {
        options.AddPolicy(basePolicy.Create, policy => policy.RequireClaim(basePolicy.Create, "true"));
        options.AddPolicy(basePolicy.Read, policy => policy.RequireClaim(basePolicy.Read, "true"));
        options.AddPolicy(basePolicy.Update, policy => policy.RequireClaim(basePolicy.Update, "true"));
        options.AddPolicy(basePolicy.Delete, policy => policy.RequireClaim(basePolicy.Delete, "true"));
        options.AddPolicy(basePolicy.List, policy => policy.RequireClaim(basePolicy.List, "true"));
        options.AddPolicy(basePolicy.Fetch, policy => policy.RequireClaim(basePolicy.Fetch, "true"));
        options.AddPolicy(basePolicy.Mutate, policy => policy.RequireClaim(basePolicy.Mutate, "true"));
        options.AddPolicy(basePolicy.All, policy => policy.RequireClaim(basePolicy.All, "true"));
    }
}