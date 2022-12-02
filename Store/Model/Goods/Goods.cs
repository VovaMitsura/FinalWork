namespace Store.Model.Goods;

using Description;

public class Goods
{
    public long Id { get; }
    public String Title { get; }
    public long Price { get; }

    private Description Description { get; }

    public int Amount { get; set; }

    public Goods(long id, string title, long price, Description description, int amount)
    {
        Id = id;
        Title = title;
        Price = price;
        Description = description;
        Amount = amount;
    }

    public override string ToString()
    {
        return $"Id: {Id}; Title:  {Title}; Price: {Price}; Amount: {Amount};Description: {Description.GetDescription()}";
    }
}