using NUnit.Framework;
using Froggi.Game;

[TestFixture]
public class Purchase_fail
{
    private Shop _shop;

    [SetUp]
    public void Awake()
    {
        _shop = new Shop();
    }

    [Test]
    public void purchase_an_already_purchased_actor()
    {
        _shop.Purchase(0);

        var rePurchased = _shop.Purchase(0);
        Assert.False(rePurchased);
    }

    [Test]
    public void provided_negative_id()
    {
        Assert.False(_shop.Purchase(-7));
    }
}
