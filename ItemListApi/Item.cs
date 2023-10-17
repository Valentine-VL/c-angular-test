public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class ItemManager
{
    private static ItemManager _instance;
    private List<Item> _items;

    private ItemManager()
    {
        _items = new List<Item>();
        for (int i = 1; i <= 15; i++)
        {
            _items.Add(new Item { Id = i, Name = "Item " + i });
        }
    }

    public static ItemManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ItemManager();
            }
            return _instance;
        }
    }

    public void AddItem(string itemName)
    {
        int newItemId = _items.Count + 1;
        _items.Add(new Item {Id = newItemId, Name = itemName });
    }

    public List<Item> GetAllItems()
    {
        return _items;
    }
}