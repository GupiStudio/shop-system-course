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
        var actor = new ActorData();
        actor.Id = 1;

        _shop.Purchase(actor);

        var rePurchased = _shop.Purchase(actor);
        Assert.False(rePurchased);
    }
}
