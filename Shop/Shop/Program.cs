namespace Classes;

class Program
{
    static void Main(string[] args)
    {
        var cart1 = new Cart(255);
        cart1.AddItem("Sprite", -32.60m, 2);
        cart1.AddItem("Fanta", 8.10m, 3);
        cart1.AddItem("Chocolate", -25.50m, 1);
        Console.WriteLine("Cart Amount is: {0}", cart1.Amount);
        cart1.RemoveItem(2);
        Console.WriteLine("Cart Amount is: {0}", cart1.Amount);

        var cart2 = new Cart(38);
        cart2.AddItem("Sprite4", 10m, 2);
        cart2.AddItem("Sprite5", -50m, 3);
        cart2.AddItem("Sprite6", 30m, 1);
        Console.WriteLine("Cart Amount is: {0}", cart2.Amount);
        cart2.RemoveItem(2);      
        
    }
    public class Cart
    {
        public int UserId { get; }
        public Dictionary<Item, int> CartItems { get; set; } = new Dictionary<Item, int>();
        public int Quantity { get; set; }
        public Cart(int userId)
        {
            UserId = userId;
        }
        public decimal Amount
        {
            get
            {
                return CalculateAmount();
            }
        }
        public void AddItem(string name, decimal price, int quantities)
        {
            var item = new Item(name, price);
            try
            {
                if (item.Price > 0)
                {
                    CartItems.Add(item, quantities);
                }
           
                else if (item.Price <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(item.Price), item.Name + " item Price " + item.Price + " is negative, it`s doesn`t culculated");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public void RemoveItem(int id)
        {
            foreach (var item in CartItems)
            {
                if (item.Key.Id == id)
                {
                    CartItems.Remove(item.Key);
                }
            }
        }
        private decimal CalculateAmount()
        {
            var amount = 0.0m;
            foreach (var item in CartItems)
            {
                var price = item.Key.Price * item.Value;
                amount += price;
            }           
            return amount;
        }
    }

    public class Item
    {
        public int Id { get; set; }
        private static int _itemId = 224545;
        public string Name { get; set; }
        public decimal Price { get; private set; }
        public Item(string name, decimal price)
        {
            
            Id = _itemId;
            _itemId++;
            Name = name;
            Price = price;
        }
    }
}