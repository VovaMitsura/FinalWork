namespace Store.Model.Goods;

using Description;

public class Goods
{
    public long Id { get;}
    public String Title { get;}
    public long Price { get;}
    private Description Description { get;}

    public Goods(long id, string title, long price, Description description)
    {
        Id = id;
        Title = title;
        Price = price;
        Description = description;
    }

    public override string ToString()
    {
        return $"Id: {Id}; Title:  {Title}; Price: {Price}; Description: {Description.GetDescription()}"; 
    }
}