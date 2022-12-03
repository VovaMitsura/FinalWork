using Store.Controllers.StoreLayer;
using Store.DBManager;
using Store.DBManager.Dao;
using Store.Model.User;

namespace Store.Controllers.MainMenuLayer;

public class OpenStoreController : IUserInterface
{
    private const string OpenStoreMessage = "'3' - open store;\n";
    private List<IUserInterface> UIs { get; set; }

    public OpenStoreController(DbContext dbContext, User user)
    {
        var daoGoods = new DaoGoods(dbContext);
        var daoHistory = new DaoHistory(dbContext);

        UIs = new List<IUserInterface>()
        {
            new ShowAllBooksController(daoGoods),
            new AddToBasketController(user, daoGoods),
            new MakePurchaseController(user, daoGoods, daoHistory),
            new ShowBasketController(user),
            new RemoveFromBasketController(user, daoGoods)
        };
    }

    public string Message()
    {
        return OpenStoreMessage;
    }

    private void Show()
    {
        Console.WriteLine("\n----------Store menu----------");
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