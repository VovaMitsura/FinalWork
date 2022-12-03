using Store.DBManager.Dao;
using Store.Model;
using Store.Utils;

namespace Store.Controllers.AdministratorController;

public class ShowHistoryController : IUserInterface
{
    private const string ShowHistoryMessage = "'1' - show history;\n";
    private readonly IDao<History> _daoHistory;

    public ShowHistoryController(IDao<History> daoHistory)
    {
        _daoHistory = daoHistory;
    }

    public string Message()
    {
        return ShowHistoryMessage;
    }

    public void Action()
    {
        Console.WriteLine("History: ");
        PrintUtils.PrintList(_daoHistory.All());
    }
}