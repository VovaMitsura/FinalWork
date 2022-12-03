using Store.DBManager.Dao;
using Store.Model.Goods;
using Store.Utils;

namespace Store.Controllers.StoreLayer;

public class ShowAllBooksController : IUserInterface
{
    private const string ShowAllBooksMessage = "'1' - show all books;\n";
    private readonly IDao<Goods> _daoGoods;

    public ShowAllBooksController(IDao<Goods> daoGoods)
    {
        _daoGoods = daoGoods;
    }

    public string Message()
    {
        return ShowAllBooksMessage;
    }

    public void Action()
    {
        Console.WriteLine("Goods:");
        PrintUtils.PrintList(_daoGoods.All());
    }
    
}