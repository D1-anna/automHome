using Classes;

namespace ShopCartTest;
public class ShopCartTests
{
    private Cart4 _cart4;

    [OneTimeSetUp]
    public void Setup()
    {
       _cart4 = new Cart4();
    }

    [Test]
    public void Add_ItemstoCart_Should_Cointains_Cart_Items()
    {
       // _cart4 = new Cart4();
        _cart4.AddItem("item1", 50, 1);
        _cart4.AddItem("item2", 100, 2);

        Assert.IsTrue(_cart4.Items.Any());
    }

    [Test]
    public void Remove_ItemFromCart_Should_Not_Cointains_Removed_Item()
    {
       // _cart4 = new Cart4();
        _cart4.AddItem("item1", 50, 1);
        _cart4.AddItem("item2", 100, 3);
        _cart4.AddItem("item2", 300, 5);

        var itemToRemove = _cart4.Items[1];

        _cart4.RemoveItem(itemToRemove.Id);

        //Assert.IsTrue(!_cart4.Items.Any(x => x.Id == itemToRemove.Id));
        
        Assert.IsTrue(!Any(_cart4.Items, itemToRemove.Id));
    }

    private static bool Any(List<Item4> items, int id) 
    {
        foreach (var x in items) 
        {
            if(x.Id == id)
            {
                return true;
            }
        }

        return false;
    }
    [Test]
    public void Price_CalculationIsCorrect()
    {       
        _cart4.AddItem("item2", 13, 3);
        _cart4.AddItem("item2", 100, 3);
        _cart4.AddItem("item2", 300, 5);

        var amount = _cart4.CalculateAmount();
        var total = 0.0m;
        total += _cart4.Items.Sum(x => x.Price * x.Quantity);                
        Assert.AreEqual(amount, total);
    }  
    
}