using Store.Controllers.LoginLayer;
using Store.DBManager;

namespace Store.Controllers;

public class GeneralController
{
    private List<IUserInterface> UIs { get; set; }

    public GeneralController()
    {
        var dbContext = new DbContext();
        UIs = new List<IUserInterface>()
        {
            new LoginController(dbContext)
        };
    }

    public void Action()
    {
        UIs[0].Action();
    }
}