using Store.Model.User;

namespace Store.DBManager.Dao;

public interface IDao<T>
{
    public long Add(T entity);
    public List<T> All();
    public T FindById(long id);
    //public T deleteById(long id);
}