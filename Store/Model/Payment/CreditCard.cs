namespace Store.Model.Payment;

public class CreditCard
{
    private String Uid { get; }
    public long AmountOfMoney { get; set; }

    public CreditCard(string uid, long amountOfMoney)
    {
        Uid = uid;
        AmountOfMoney = amountOfMoney;
    }
}