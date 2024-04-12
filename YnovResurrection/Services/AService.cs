using YnovResurrection.Models;

namespace YnovResurrection.Services;

/// <summary>
/// Base abstract class for services
/// </summary>
public abstract class AService
{
    protected readonly AppDb _appDb;

    /// <summary>
    /// Apply random uuid to entity
    /// </summary>
    /// <param name="model"></param>
    /// <typeparam name="T"></typeparam>
    protected static void ApplyId(IModel model)
    {
        model.Id = Guid.NewGuid().ToString();
    }

    /// <summary>
    /// Flush changes to database
    /// </summary>
    protected void Flush()
    {
        _appDb.SaveChanges();
    }

}
