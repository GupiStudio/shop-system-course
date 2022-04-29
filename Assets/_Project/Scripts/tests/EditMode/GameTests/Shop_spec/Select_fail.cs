using System.Collections;
using System.Collections.Generic;
using Froggi.Game;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

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
    public void provided_negative_id()
    {
        Assert.False(_shop.Select(-7));
    }

    [Test]
    public void have_no_purchased_actor()
    {
        var data = _shop.Data;
        data.PurchasedActorIndexes.Clear();
        _shop.Data = data;

        Assert.False(_shop.Select(7));
    }

    [Test]
    public void actor_have_not_been_purchased()
    {
        var data = _shop.Data;
        data.PurchasedActorIndexes.Clear();
        _shop.Data = data;

        _shop.Purchase(1);

        Assert.False(_shop.Select(7));
    }
}
