using System.Collections.Generic;

namespace MiniprojektEFCRUD2
{
    class Branch
    {
        public Branch(string name)
        {
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Laptop> Laptops { get; set; }
        public List<Mobile> Mobiles { get; set; }
    }

    class Product
    {
        public int Id { get; set; }
        public string PurchaseDate { get; set; }
        public string ModelName { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }

    class Laptop : Product
    {
        public string SystemOperation { get; set; }
        public Laptop(string purchaseDate, string modelName, string systemOperation, string color, int price, int branchId)
        {
            PurchaseDate = purchaseDate;
            ModelName = modelName;
            SystemOperation = systemOperation;
            Color = color;
            Price = price;
            BranchId = branchId;
        }
    }

    class Mobile : Product
    {
        public Mobile(string purchaseDate, string modelName, string color, int price, int branchId)
        {
            PurchaseDate = purchaseDate;
            ModelName = modelName;
            Color = color;
            Price = price;
            BranchId = branchId;
        }
    }
}