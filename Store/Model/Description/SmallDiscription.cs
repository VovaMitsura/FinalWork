namespace Store.Model.Description;

public class SmallDescription : Description
{
    private const String ToLongDescriptionMessage = "Description length too long for small.";
    public string Text { get; set; }

    public SmallDescription(string type, string smallText) : base(type)
    {
        Text =
            smallText.Length > 300 ? throw new ArgumentException(ToLongDescriptionMessage, smallText) : smallText;
    }

    public override string GetDescription()
    {
        return $"Type: {Type}; {Text}";
    }
}