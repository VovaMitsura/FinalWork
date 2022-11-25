namespace Store.Model;

public class History
{
    private static int _longId = 1234;
    public long Id { get; }
    public long UserId { get; }
    public long GoodsId { get; }

    public History(long userId, long goodsId)
    {
        Id = _longId++;
        UserId = userId;
        GoodsId = goodsId;
    }

    public override string ToString()
    {
        return $"Id: {Id}; UserId: {UserId}; GoodsId: {GoodsId}";
    }
}