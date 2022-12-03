using Store.Model.User;
using Store.Utils;

namespace Store.Controllers.StoreLayer;

public class ShowBasketController : IUserInterface
{
    private const string ShowBasketMessage = "'4' - show basket;\n";
    private readonly User _user;

    public ShowBasketController(User user)
    {
        _user = user;
    }

    public string Message()
    {
        return ShowBasketMessage;
    }

    public void Action()
    {
        if (_user.GoodsList is { Count: 0 } || _user.GoodsList == null)
        {
            Console.WriteLine("Basket is empty");
        }
        else
        {
            Console.WriteLine("Basket:");
            PrintUtils.PrintList(_user.GoodsList);
        }
    }
}