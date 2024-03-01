using YnovResuction;
using YnovResurrection.Models;

namespace YnovResurrection.Services;

/// <summary>
/// Base abstract class for services
/// </summary>
public abstract class AService
{
    protected readonly AppDb _appDb = new();

    protected static void ApplyId<T>(ref T model) where T : IModel
    {
        model.Id = Guid.NewGuid().ToString();
    }

    protected void Flush()
    {
        _appDb.SaveChanges();
    }

}