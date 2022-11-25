using Store.AppContext;
using AppContext = Store.AppContext.AppContext;

public class Program
{
    public static void Main(string[] args)
    {
        var appContext = new AppContext();
        var driver = new Driver(appContext);
        driver.Starter();
    }
}