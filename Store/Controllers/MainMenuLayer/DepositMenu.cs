using Store.Model.User;

namespace Store.Controllers.MainMenuLayer;

public class DepositMenu : IUserInterface
{
    private const String DepositMessage = "'2' - make deposit;\n";
    private readonly User _user;

    public DepositMenu(User user)
    {
        _user = user;
    }

    public string Message()
    {
        return DepositMessage;
    }

    public void Action()
    {
        Console.Write("Enter sum: ");
        var deposit = Convert.ToInt32(Console.ReadLine());

        if (deposit < 10)
        {
            Console.WriteLine("Cannot accept less than 10");
        }
        else
        {
            if (_user.CreditCard != null) _user.CreditCard.AmountOfMoney += deposit;

            Console.WriteLine("\nTransaction closed successfully.");
        }
    }
}