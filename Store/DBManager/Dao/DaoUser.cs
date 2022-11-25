using Store.Model.User;

namespace Store.DBManager.Dao;

public class DaoUser : IDao<User>
{
    private DbContext DbContext { get; }

    public DaoUser(DbContext dbContext)
    {
        DbContext = dbContext;
    }

    public long Add(User entity)
    {
        DbContext.Users.Add(entity);
        return entity.Id;
    }

    public List<User> All()
    {
        return DbContext.Users;
    }

    public User FindById(long id)
    {
        return DbContext.Users.First(x => x.Id.Equals(id));
    }

    public User FindByName(String name)
    {
        try
        {
            return DbContext.Users.First(x => x.Name.Equals(name));
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine("User not found.");
            return null!;
        }
    }
}