using Store.DBManager.Dao;
using Store.Model.Goods;
using Store.Model.User;

namespace Store.Controllers.StoreLayer;

public class RemoveFromBasketController : IUserInterface
{
    private const string RemoveFromBasketMessage = "'5' - remove from basket;\n";
    private User _user;
    private readonly IDao<Goods> _daoGoods;

    public RemoveFromBasketController(User user, IDao<Goods> daoGoods)
    {
        _user = user;
        _daoGoods = daoGoods;
    }


    public string Message()
    {
        return RemoveFromBasketMessage;
    }

    public void Action()
    {
        bool repeat = true;
        while (repeat)
        {
            Console.WriteLine("Enter:  '0' - exit\n\t" +
                              "'Book id' - remove from basket;");

            Console.Write("-> ");
            var option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 0:
                    repeat = false;
                    break;
                default:
                    var book = _daoGoods.FindById(option);
                    _user.GoodsList?.Remove(book);
                    Console.WriteLine($"{book.Title}, {book.Price} removed from {_user.Name} basket.\n");
                    break;
            }
        }
    }
}