namespace Store.Model.Description;

public abstract class Description
{
    public String Type { get; set; }

    protected Description(string type)
    {
        Type = type;
    }

    public abstract string GetDescription();
}