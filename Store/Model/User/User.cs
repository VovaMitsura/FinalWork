namespace Store.Model.User;

using Payment;
using Goods;

public class User
{
    private static long _id = 1234;
    public long Id { get; }
    public string Name { get; }
    public CreditCard? CreditCard { get; }
    public List<Goods>? GoodsList { get; set; }
    public Role Role { get; }

    public User(string name, string creditUid, Role role)
    {
        Id = _id++;
        Name = name;
        CreditCard = new CreditCard(creditUid, 0);
        GoodsList = new List<Goods>();
        Role = role;
    }

    public User(long id, string name, CreditCard? creditCard, List<Goods>? goodsList, Role role)
    {
        Id = id;
        Name = name;
        CreditCard = creditCard;
        GoodsList = goodsList;
        Role = role;
    }

    public override string ToString()
    {
        return $"ID: {Id}; Name: {Name}; Role: {Role}";
    }
}