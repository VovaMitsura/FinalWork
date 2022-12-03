using Store.Controllers.AdministratorController;
using Store.DBManager;
using Store.DBManager.Dao;
using Store.Model.User;

namespace Store.Controllers.MainMenuLayer;

public class OpenAdministratorMenuController : IUserInterface
{
    private const string OpenAdministratorMenuMessage = "'4' - administrator menu;\n";
    private List<IUserInterface> UIs { get; set; }

    private readonly User _user;

    public OpenAdministratorMenuController(User user, DbContext dbContext)
    {
        _user = user;
        var daoHistory = new DaoHistory(dbContext);
        var daoUser = new DaoUser(dbContext);
        UIs = new List<IUserInterface>()
        {
            new ShowHistoryController(daoHistory),
            new AddUserController(daoUser),
            new ShowAllUsers(daoUser)
        };
    }

    public string Message()
    {
        return OpenAdministratorMenuMessage;
    }

    private void Show()
    {
        Console.WriteLine("\n----------Administrator menu----------");
        foreach (var t in UIs)
        {
            Console.Write(t.Message());
        }

        Console.WriteLine("'0' - exit");
    }

    public void Action()
    {
        if (!_user.Role.Equals(Role.Administrator))
        {
            Console.WriteLine("You are not allowed to use this functionality.\n");
        }
        else
        {
            var repeat = true;
            while (repeat)
            {
                Show();
                Console.Write("-> ");
                int action = Convert.ToInt32(Console.ReadLine());
                if (action == 0)
                {
                    repeat = false;
                }
                else
                    UIs[action - 1].Action();
            }
        }
    }
}