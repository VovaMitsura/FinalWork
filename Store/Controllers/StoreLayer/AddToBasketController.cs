using Store.DBManager.Dao;
using Store.Model.Goods;
using Store.Model.User;

namespace Store.Controllers.StoreLayer;

public class AddToBasketController : IUserInterface
{
    private const string AddToBasketMessage = "'2' - add to basket;\n";
    private readonly User _user;
    private readonly IDao<Goods> _daoGoods;

    public AddToBasketController(User user, IDao<Goods> daoGoods)
    {
        _user = user;
        _daoGoods = daoGoods;
    }

    public string Message()
    {
        return AddToBasketMessage;
    }

    public void Action()
    {
        bool repeat = true;
        while (repeat)
        {
            Console.WriteLine("Enter:  '0' - exit\n\t" +
                              "'Book id' - add to basket;");

            Console.Write("-> ");
            var option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 0:
                    repeat = false;
                    break;
                default:
                    var book = _daoGoods.FindById(option);
                    if (book.Amount > 0)
                    {
                        _user.GoodsList?.Add(book);
                        Console.WriteLine($"{book.Title}, {book.Price} added to {_user.Name} basket.\n");
                    }
                    else
                        Console.WriteLine("No exist item in store.");

                    break;
            }
        }
    }
}