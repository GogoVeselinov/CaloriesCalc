namespace CaloriesCalc
{
    class Program
    {
        static void Main()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Add_Item cart = new Add_Item();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nИзберете опция:");
                Console.WriteLine("1. Добавяне на продукт");
                Console.WriteLine("2. Преглед на добавените продукти");
                Console.WriteLine("3. Изтриване на всички продукти и показване на калориите");
                Console.WriteLine("4. Изход");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Тип на продукта (1 - Храна, 2 - Напитка): ");
                        string productType = Console.ReadLine();

                        Console.Write("Въведете име на продукта: ");
                        string name = Console.ReadLine();

                        Console.Write("Въведете цена: ");
                        if (!double.TryParse(Console.ReadLine(), out double price))
                        {
                            Console.WriteLine("Невалидна цена.");
                            break;
                        }

                        Console.Write("Въведете калории: ");
                        if (!int.TryParse(Console.ReadLine(), out int calories))
                        {
                            Console.WriteLine("Невалиден брой калории.");
                            break;
                        }

                        Item newItem;
                        if (productType == "1")
                        {
                            newItem = new FoodItem(name, price, calories);
                        }
                        else if (productType == "2")
                        {
                            newItem = new DrinkItem(name, price, calories);
                        }
                        else
                        {
                            Console.WriteLine("Невалиден тип продукт.");
                            break;
                        }

                        cart.AddProduct(newItem);
                        Console.WriteLine("Продуктът е добавен.");
                        break;

                    case "2":
                        cart.PrintProducts();
                        break;

                    case "3":
                        cart.ClearProducts();
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Изход от програмата.");
                        break;

                    default:
                        Console.WriteLine("Невалидна опция. Опитайте отново.");
                        break;
                }
            }
        }
    }
}