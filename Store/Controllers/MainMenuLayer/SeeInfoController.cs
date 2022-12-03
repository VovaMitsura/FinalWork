using Store.Model.User;

namespace Store.Controllers.MainMenuLayer;

public class SeeInfoController : IUserInterface
{
    private const String InfoMessage = "'1' - see info;\n";
    private readonly User _user;

    public SeeInfoController(User user)
    {
        _user = user;
    }

    public string Message()
    {
        return InfoMessage;
    }

    public void Action()
    {
        if (_user.CreditCard != null)
            Console.WriteLine(
                $"Name: {_user.Name}   Amount Of Money: {_user.CreditCard.AmountOfMoney}\t Role: {_user.Role}");
    }
}