using Store.DBManager.Dao;
using Store.Utils;

namespace Store.Controllers.AdministratorController;

public class ShowAllUsers : IUserInterface
{
    private const string ShowAllUsersMessage = "'3' - show all users;\n";
    private readonly DaoUser _daoUser;

    public ShowAllUsers(DaoUser daoUser)
    {
        _daoUser = daoUser;
    }

    public string Message()
    {
        return ShowAllUsersMessage;
    }

    public void Action()
    {
        Console.WriteLine("Users: ");
        PrintUtils.PrintList(_daoUser.All());
    }
}