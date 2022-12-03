using Store.Controllers.MainMenuLayer;
using Store.DBManager;
using Store.DBManager.Dao;
using Store.Model.User;

namespace Store.Controllers.LoginLayer;

public class LoginController : IUserInterface
{
    private const String LoginMessage = "Enter your name: ";
    private readonly DaoUser _daoUser;
    private readonly DbContext _dbContext;
    private GeneralMainMenuController? _generalMainMenuController;

    public LoginController(DbContext dbContext)
    {
        _dbContext = dbContext;
        _daoUser = new DaoUser(dbContext);
    }

    public string Message()
    {
        return LoginMessage;
    }

    public void Action()
    {
        var repeat = true;
        while (repeat)
        {
            Console.WriteLine("----------Login Menu----------");
            Console.Write(Message());
            var name = Console.ReadLine();

            if (name == null) return;

            var user = _daoUser.FindByName(name);

            if (user == null)
            {
                Console.WriteLine("Please, ask administrator to add you to system.\n");
                return;
            }

            _generalMainMenuController = new GeneralMainMenuController(_dbContext, user);
            _generalMainMenuController.Action();
        }
    }
}