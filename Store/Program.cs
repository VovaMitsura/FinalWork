using Store.Controllers;

public class Program
{
    public static void Main(string[] args)
    {
        /*
        var appContext = new AppContext();
        var driver = new Driver(appContext);
        driver.Starter();
        */
        GeneralController generalController = new GeneralController();
        generalController.Action();
    }
}