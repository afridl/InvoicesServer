
namespace Invoices.Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    IList<TEntity> GetAll();

    TEntity? FindById(ulong id);

    TEntity Insert(TEntity entity);

    TEntity Update(TEntity entity);

    void Delete(ulong id);

    bool ExistsWithId(ulong id);
}