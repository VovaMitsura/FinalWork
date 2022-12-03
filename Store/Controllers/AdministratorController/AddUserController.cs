using Store.DBManager.Dao;
using Store.Model.User;

namespace Store.Controllers.AdministratorController;

public class AddUserController : IUserInterface
{
    private const string AddUserMessage = "'2' - add user;\n";
    private readonly DaoUser _daoUser;

    public AddUserController(DaoUser daoUser)
    {
        _daoUser = daoUser;
    }

    public string Message()
    {
        return AddUserMessage;
    }

    public void Action()
    {
        Console.Write("Enter name: ");
        var userName = Console.ReadLine();

        Console.Write("Role: [admin/customer] ");
        var roleInput = Console.ReadLine();
        Role role = roleInput is "admin" ? Role.Administrator : Role.Customer;

        Console.Write("Credit UID: ");
        var uid = Console.ReadLine();

        _daoUser.Add(new User(userName, uid, role));
        Console.WriteLine("User added to system.");
    }
}