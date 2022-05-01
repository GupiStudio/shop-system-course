using Froggi.Game;
using NUnit.Framework;

[TestFixture]
public class Select_fail
{
    private Shop _shop;

    [SetUp]
    public void Awake()
    {
        _shop = new Shop();
    }

    [Test]
    public void have_no_purchased_actor()
    {
        var data = _shop.Data;
        data.PurchasedActorIndexes.Clear();
        _shop.Data = data;

        var actor = new ActorData();
        actor.Id = 7;

        Assert.False(_shop.Select(actor));
    }

    [Test]
    public void actor_have_not_been_purchased()
    {
        var data = _shop.Data;
        data.PurchasedActorIndexes.Clear();
        _shop.Data = data;

        var actor = new ActorData();
        actor.Id = 1;

        _shop.Purchase(actor);

        var otherActor = new ActorData();
        otherActor.Id = 7;

        Assert.False(_shop.Select(otherActor));
    }
}
