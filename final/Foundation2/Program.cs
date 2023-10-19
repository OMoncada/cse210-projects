using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address addy1 = new Address("123 Main Street", "Anytown", "AG", "USA");
        Customer person1 = new Customer("Alex", addy1);
        List<Product> products1 = new List<Product>();
        Product product1 = new Product("Kung Pao Shrimp", 202, 3.01f, 1);
        Product product2 = new Product("Beef with Broccoli", 203, 2.10f, 2);
        products1.Add(product1);
        products1.Add(product2);
        Order order1 = new Order(person1, products1);

        Console.WriteLine("Order 1");
        Console.WriteLine("======================================");

        foreach (var product in products1)
        {
            Console.WriteLine($"{product.Quantity} x {product.Price:C}");
            Console.WriteLine($"{product.ProductID,-3}\t{ToTitleCase(product.Name),-20}\t{product.Price:C}");
        }

        float subtotal1 = order1.CalcTotalPrice() - (order1.Customer.InUSA() ? 5f : 35f);
        float shippingCost1 = order1.Customer.InUSA() ? 5f : 35f;

        Console.WriteLine("======================================");
        Console.WriteLine($"SUBTOTAL{subtotal1,29:C}");
        Console.WriteLine($"SHIPPING COST{shippingCost1,24:C}");
        Console.WriteLine($"TOTAL{order1.CalcTotalPrice(),33:C}");
        Console.WriteLine("======================================");

        Console.WriteLine("PACKING LABEL");
        Console.WriteLine(order1.MakePackLabel());
        Console.WriteLine("======================================");

        Console.WriteLine("SHIPPING LABEL");
        Console.WriteLine(order1.MakeShipLabel());
        Console.WriteLine("======================================");

        Console.WriteLine("//////////////////////////////////////");

        Address addy2 = new Address("456 Maple Avenue", "Maplewood", "ON", "CANADA");
        Customer person2 = new Customer("Gabriela", addy2);
        List<Product> products2 = new List<Product>();
        Product product3 = new Product("Sweet and Sour Pork", 213, 4.50f, 2);
        Product product4 = new Product("Vegetable Chow Fun", 217, 3.50f, 1);
        products2.Add(product3);
        products2.Add(product4);
        Order order2 = new Order(person2, products2);

        Console.WriteLine("Order 2");
        Console.WriteLine("======================================");

        foreach (var product in products2)
        {
            Console.WriteLine($"{product.Quantity} x {product.Price:C}");
            Console.WriteLine($"{product.ProductID,-3}\t{ToTitleCase(product.Name),-20}\t{product.Price:C}");
        }

        float subtotal2 = order2.CalcTotalPrice() - (order2.Customer.InUSA() ? 5f : 35f);
        float shippingCost2 = order2.Customer.InUSA() ? 5f : 35f;

        Console.WriteLine("======================================");
        Console.WriteLine($"SUBTOTAL{subtotal2,30:C}");
        Console.WriteLine($"SHIPPING COST{shippingCost2,25:C}");
        Console.WriteLine($"TOTAL{order2.CalcTotalPrice(),33:C}");
        Console.WriteLine("======================================");

        Console.WriteLine("PACKING LABEL");
        Console.WriteLine(order2.MakePackLabel());
        Console.WriteLine("======================================");

        Console.WriteLine("SHIPPING LABEL");
        Console.WriteLine(order2.MakeShipLabel());
        Console.WriteLine("======================================");
    }

    static string ToTitleCase(string str)
    {
        if (str.Length < 2)
            return str.ToUpper();
        return char.ToUpper(str[0]) + str.Substring(1).ToLower();
    }
}