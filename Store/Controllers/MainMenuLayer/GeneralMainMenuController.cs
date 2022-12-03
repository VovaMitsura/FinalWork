using Store.DBManager;
using Store.DBManager.Dao;
using Store.Model.User;

namespace Store.Controllers.MainMenuLayer;

public class GeneralMainMenuController
{
    private List<IUserInterface> UIs { get; set; }

    public GeneralMainMenuController(DbContext dbContext, User user)
    {
        UIs = new List<IUserInterface>()
        {
            new SeeInfoController(user),
            new DepositMenu(user),
            new OpenStoreController(dbContext, user),
            new OpenAdministratorMenuController(user, dbContext)
        };
    }

    public void Show()
    {
        Console.WriteLine("\n----------Main menu----------");
        foreach (var t in UIs)
        {
            Console.Write(t.Message());
        }

        Console.WriteLine("'0' - exit");
    }

    public void Action()
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