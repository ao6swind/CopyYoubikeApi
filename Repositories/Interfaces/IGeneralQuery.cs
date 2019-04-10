namespace Repositories.Interfaces
{
    interface IGeneralQuery<T>
    {
        bool Create(T entity);
        bool Update(int id, T entity);
        T Find(int id);
    }
}
