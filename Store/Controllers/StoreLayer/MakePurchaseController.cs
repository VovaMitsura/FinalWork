using Store.DBManager.Dao;
using Store.Model;
using Store.Model.Goods;
using Store.Model.User;

namespace Store.Controllers.StoreLayer;

public class MakePurchaseController : IUserInterface
{
    private const string MakePurchaseMessage = "'3' - make purchase;\n";
    private readonly User _user;
    private readonly IDao<Goods> _daoGoods;
    private readonly IDao<History> _daoHistory;

    public MakePurchaseController(User user, IDao<Goods> daoGoods, IDao<History> daoHistory)
    {
        _user = user;
        _daoGoods = daoGoods;
        _daoHistory = daoHistory;
    }

    public string Message()
    {
        return MakePurchaseMessage;
    }

    public void Action()
    {
        Console.WriteLine("Enter:  '1' - pay\n\t" +
                          "'0' - exit;");

        Console.Write("-> ");
        var option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                long totalSum = 0;
                if (!(_user.GoodsList is { Count: 0 }) && _user.GoodsList != null)
                {
                    totalSum += _user.GoodsList.Sum(t => t.Price);

                    if (_user.CreditCard != null && _user.CreditCard.AmountOfMoney - totalSum > 0)
                    {
                        _user.CreditCard.AmountOfMoney -= totalSum;

                        foreach (var t in _user.GoodsList)
                        {
                            _daoHistory.Add(new History(_user.Id, t.Id));
                        }

                        foreach (var t in _user.GoodsList)
                        {
                            var goodsById = _daoGoods.FindById(t.Id);
                            goodsById.Amount--;
                        }

                        _user.GoodsList = new List<Goods>();

                        Console.WriteLine("\nTransaction closed successfully.");
                    }
                    else
                        Console.WriteLine($"\n{_user.Name} haven`t enough money to make purchase.");
                }
                else
                    Console.WriteLine("Basket is empty.");

                break;
            case 0:
                break;
            default:
                Console.WriteLine("Maybe you`ve misclicked. Try again.\n");
                break;
        }
    }
}