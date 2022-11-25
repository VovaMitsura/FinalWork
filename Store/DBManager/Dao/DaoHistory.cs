using Store.Model;

namespace Store.DBManager.Dao;

public class DaoHistory : IDao<History>
{
    private DbContext DbContext { get;}

    public DaoHistory(DbContext dbContext)
    {
        DbContext = dbContext;
    }

    public long Add(History entity)
    {
        DbContext.Histories.Add(entity);
        return entity.Id;
    }

    public List<History> All()
    {
        return DbContext.Histories;
    }
    
    public List<History> AllByUserId(long id)
    {
        return DbContext.Histories.Where(x => x.Id.Equals(id)).ToList();
    }

    public History FindById(long id)
    {
        return DbContext.Histories.First(x => x.Id.Equals(id));
    }
}