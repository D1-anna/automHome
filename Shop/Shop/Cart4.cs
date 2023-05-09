namespace Classes;

public class Cart4
{
    public int UserId { get; set; }
    private static int _userId = 123456;
    public List<Item4> Items { get; set; } = new List<Item4>();
    public decimal Amount
    {
        get
        {
            return CalculateAmount();
        }
    }
    public Cart4()
    {
        UserId = _userId;
        _userId++;
    }
    public void AddItem(string name, decimal price, int quantities)
    {
        if (price < 0)
        {
            price = 0;
           // throw new ArgumentOutOfRangeException($"{nameof(price)}, {name} item Price {price} is negative, its doesn`t culculated.");
        }
        var item = new Item4(name, price, quantities);
        Items.Add(item);
    }

    public void RemoveItem(int id)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Id == id)
            {
                Items.RemoveAt(i);
                break;
            }
        }
    }
    public void DecreaseQuantity(int id)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Id == id)
            {
                Console.WriteLine("{0} --- quantity was --- {1} ", Items[i].Name, Items[i].Quantity.ToString());
                if (Items[i].Quantity == 1)
                {
                    Console.WriteLine("{0} any items for it", Items[i].Name);
                    RemoveItem(id);
                }
                else
                {
                    Items[i].Quantity--;
                    Console.WriteLine(" {0} --- now quantity --- {1}", Items[i].Name, Items[i].Quantity.ToString());
                }
            }
        }
    }
    public void IncreaseQuantity(int id)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Id == id)
            {
                Console.WriteLine("{0} --- quantity was --- {1}", Items[i].Name, Items[i].Quantity.ToString());
                Items[i].Quantity++;
                Console.WriteLine("{0} --- quantity now --- {1}", Items[i].Name, Items[i].Quantity.ToString());
            }
        }
    }
    public decimal CalculateAmount()
    {
        var amount = 0.0m;
        for (int i = 0; i < Items.Count; i++)
        {
            var price = Items[i].Price * Items[i].Quantity;
            amount += price;
        }
        return amount;
    }
}
public class Item4
{
    public int Id { get; set; }
    private static int _itemId = 1;
    public string Name { get; set; }
    public decimal Price { get; private set; }
    public int Quantity { get; set; }
    public Item4(string name, decimal price, int quantity)
    {
        Id = _itemId;
        _itemId++;
        Name = name;
        Price = price;
        Quantity = quantity;
    }
}
