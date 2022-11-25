using Store.Model.Goods;

namespace Store.DBManager.Dao;

public class DaoGoods : IDao<Goods>
{
    private DbContext DbContext { get;}

    public DaoGoods(DbContext dbContext)
    {
        DbContext = dbContext;
    }

    public long Add(Goods entity)
    {
        DbContext.GoodsList.Add(entity);
        return entity.Id;
    }

    public List<Goods> All()
    {
        return DbContext.GoodsList;
    }

    public Goods FindById(long id)
    {
        return DbContext.GoodsList.First(x => x.Id.Equals(id));
    }
}