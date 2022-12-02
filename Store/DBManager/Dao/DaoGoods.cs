using Store.Model.Goods;

namespace Store.DBManager.Dao;

public class DaoGoods : IDao<Goods>
{
    private DbContext DbContext { get; }

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
        try
        {
            return DbContext.GoodsList;
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Goods not found.");
            return null!;
        }
    }

    public Goods FindById(long id)
    {
        try
        {
            return DbContext.GoodsList.First(x => x.Id.Equals(id));
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("Goods not found.");
            return null!;
        }
    }
}