using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaloriesCalc
{
    public abstract class Item
    {
        private string _name; public string Name { get => _name; set => _name = value; }
        private double _price; public double Price { get => _price; set => _price = value; }
        private double _calories; public double Calories { get => _calories; set => _calories = value; }

        public Item(string Name, double Price, double Calories)
        {
            _name = Name;
            _price = Price;
            _calories = Calories;
        }

        public abstract string GetDescription();
    }

    class FoodItem : Item
    {
        public FoodItem(string name, double price, int calories)
            : base(name, price, calories) { }

        public override string GetDescription()
        {
            return $"{Name} - Храна: {Price:F2} лв, Калории: {Calories} kcal";
        }
    }

    class DrinkItem : Item
    {
        public DrinkItem(string name, double price, int calories)
            : base(name, price, calories) { }

        public override string GetDescription()
        {
            return $"{Name} - Напитка: {Price:F2} лв, Калории: {Calories} kcal";
        }
    }
    class Add_Item
    {
        private List<Item> purchasedItems = new List<Item>();

        public double TotalPrice { get; private set; } = 0;
        public double TotalCalories { get; private set; } = 0;

        public void AddProduct(Item item)
        {
            purchasedItems.Add(item);
            TotalPrice += item.Price;
            TotalCalories += item.Calories;
        }

        public void PrintProducts()
        {
            if (purchasedItems.Count == 0)
            {
                Console.WriteLine("Няма добавени продукти.");
                return;
            }

            Console.WriteLine("Закупени продукти:");
            foreach (var item in purchasedItems)
            {
                Console.WriteLine(item.GetDescription());
            }
            Console.WriteLine($"Обща сума: {TotalPrice:F2} лв");
            Console.WriteLine($"Общо калории: {TotalCalories} kcal");
        }

        public void ClearProducts()
        {
            purchasedItems.Clear();
            Console.WriteLine($"Консумирани калории: {TotalCalories} kcal.");
            TotalPrice = 0;
            TotalCalories = 0;
        }
    }
}