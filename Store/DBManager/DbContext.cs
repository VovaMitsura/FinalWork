namespace Store.DBManager;

using Model;
using Model.User;
using Model.Goods;
using Model.Payment;
using Model.Description;

public class DbContext
{
    public List<User> Users { get; }
    public List<History> Histories { get; }
    public List<Goods> GoodsList { get; }

    public DbContext()
    {
        Users = new List<User>
        {
            new User(1L, "Jack", new CreditCard("123456", 123456),
                new List<Goods>(), Role.Customer),
            new User(2L, "John", new CreditCard("123456", 123456),
                new List<Goods>(), Role.Customer),
            new User(3L, "Mike", new CreditCard("123456", 123456),
                new List<Goods>(), Role.Customer),
            new User(3L, "Alex", new CreditCard("154326", 156),
                new List<Goods>(), Role.Administrator)
        };

        Histories = new List<History>
        {
            new History(1L, 1L),
            new History(1L, 2L),
            new History(1L, 3L),
        };

        GoodsList = new List<Goods>
        {
            new Goods(1L, "Clean Code", 600,
                new SmallDescription("Book", "Author: Robert Cecil Martin")),
            new Goods(2L, "Head First Java", 500,
                new SmallDescription("Book", "Author: Bert Bates and Kathy Sierra")),
            new Goods(3L, "Effective java", 750,
                new SmallDescription("Book", "Author: Joshua Bloch"))
        };
    }
}