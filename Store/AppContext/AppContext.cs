using Store.DBManager;

namespace Store.AppContext;

public class AppContext
{
    public readonly DbContext DbContext;

    public AppContext()
    {
        DbContext = new DbContext();
    }
}


/*
public void MainMenu()
{
    Boolean repeat = true;
    int way;

    Console.Write("----------Hello in book store----------" +
                  "\nEnter your name: ");
    String? name = Console.ReadLine();

    var user = DaoUser.FindByName(name);

    while (repeat)
    {
        Console.WriteLine("\n----------Main menu----------");
        Console.WriteLine("Enter:  '1' - see info;\n\t" +
                          "'2' - make deposit;\n\t" +
                          "'3' - open store;\n\t" +
                          "'0' - exit;");

        Console.Write("-> ");
        way = Convert.ToInt32(Console.ReadLine());

        switch (way)
        {
            case 1:
                if (user.CreditCard != null)
                    Console.WriteLine(
                        $"Name: {user.Name}   Amount Of Money: {user.CreditCard.AmountOfMoney}\t Role: {user.Role}");
                break;
            case 2:
                DepositMenu(user);
                break;
            case 3:
                StoreMenu(user);
                break;
            case 0:
                repeat = false;
                break;
            default:
                Console.WriteLine("Maybe you`ve misclicked. Try again.\n");
                break;
        }
    }

    Console.WriteLine("-----Thanks. Looking forward to see you later-----");
}

private void DepositMenu(User user)
{
    bool openMenu = true;

    while (openMenu)
    {
        Console.WriteLine("\n----------Deposit menu----------");
        Console.WriteLine("Enter:  '1' - make deposit;\n\t" +
                          "'0' - back to main menu;");

        Console.Write("-> ");
        var way = Convert.ToInt32(Console.ReadLine());

        switch (way)
        {
            case 1:
                Console.Write("Enter sum: ");
                var deposit = Convert.ToInt32(Console.ReadLine());

                if (user.CreditCard != null) user.CreditCard.AmountOfMoney += deposit;

                Console.WriteLine("\nTransaction closed successfully");
                break;
            case 0:
                openMenu = false;
                break;
            default:
                Console.WriteLine("Maybe you`ve misclicked. Try again.\n");
                break;
        }
    }
}

private void StoreMenu(User user)
{
    bool openMenu = true;

    while (openMenu)
    {
        Console.WriteLine("\n----------Store menu----------");
        Console.WriteLine("Enter:  '1' - show all books;\n\t" +
                          "'2' - add to basket;\n\t" +
                          "'3' - make purchase;\n\t" +
                          "'4' - show basket;\n\t" +
                          "'5' - remove from basket;\n\t" +
                          "'0' - exit;");

        Console.Write("-> ");
        var way = Convert.ToInt32(Console.ReadLine());

        bool repeat;
        int option;
        switch (way)
        {
            case 1:
                var goodsList = DaoGoods.All();
                for (int i = 0; i < goodsList.Count; i++)
                {
                    Console.WriteLine($"\t{i + 1}.{goodsList[i]}");
                }

                break;
            case 2:
                repeat = true;
                while (repeat)
                {
                    Console.WriteLine("Enter:  '0' - exit\n\t" +
                                      "'Book id' - add to basket;");

                    Console.Write("-> ");
                    option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 0:
                            repeat = false;
                            break;
                        default:
                            var book = DaoGoods.findById(option);
                            user.GoodsList?.Add(book);
                            Console.WriteLine($"{book.Title}, {book.Price} added to {user.Name} basket.\n");
                            break;
                    }
                }

                break;
            case 3:
                Console.WriteLine("Enter:  '1' - pay\n\t" +
                                  "'0' - exit;");
                
                Console.Write("-> ");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        long totalSum = 0;
                        if (!(user.GoodsList is { Count: 0 }) && user.GoodsList != null)
                        {
                            totalSum += user.GoodsList.Sum(t => t.Price);

                            if (user.CreditCard != null && user.CreditCard.AmountOfMoney - totalSum > 0)
                            {
                                user.CreditCard.AmountOfMoney -= totalSum;

                                foreach (var t in user.GoodsList)
                                {
                                    DaoHistory.Add(new History(user.Id, t.Id));
                                }

                                Console.WriteLine("\nTransaction closed successfully");
                            }
                            else
                                Console.WriteLine($"\n{user.Name} haven`t enough money to make purchase.");
                        }
                        else
                            Console.WriteLine("Basket is empty");

                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Maybe you`ve misclicked. Try again.\n");
                        break;
                }

                break;
            case 4:
                if (user.GoodsList is { Count: 0 })
                {
                    Console.WriteLine("Basket is empty");
                }
                else
                {
                    if (user.GoodsList != null)
                    {
                        Console.WriteLine("Basket:");
                        for (var i = 0; i < user.GoodsList.Count; i++)
                        {
                            Console.WriteLine($"\t{i + 1}.{user.GoodsList[i]}");
                        }
                    }
                }

                break;
            case 5:
                repeat = true;
                while (repeat)
                {
                    Console.WriteLine("Enter:  '0' - exit\n\t" +
                                      "'Book id' - remove from basket;");

                    Console.Write("-> ");
                    option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 0:
                            repeat = false;
                            break;
                        default:
                            var book = DaoGoods.findById(option);
                            user.GoodsList?.Remove(book);
                            Console.WriteLine($"{book.Title}, {book.Price} removed from {user.Name} basket.\n");
                            break;
                    }
                }

                break;
            case 0:
                openMenu = false;
                break;
            default:
                Console.WriteLine("Maybe you`ve misclicked. Try again.\n");
                break;
        }
    }
}
*/