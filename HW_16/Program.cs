using System;
using System.Linq;
using System.Collections.Generic;

class Device
{
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"{Name} ({Manufacturer}) - {Price:C}";
    }
}

class DeviceManufacturerComparer : IEqualityComparer<Device>
{
    public bool Equals(Device x, Device y)
    {
        return x.Manufacturer == y.Manufacturer;
    }

    public int GetHashCode(Device obj)
    {
        return obj.Manufacturer.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        //1
        int[] numbers = { 121, 75, 81 };

        var sortedAscending = numbers.OrderBy(n => n.ToString().Sum(c => c - '0')).ToArray();
        Console.WriteLine("Сортування за зростанням суми цифр числа:");
        Console.WriteLine(string.Join(", ", sortedAscending));

        var sortedDescending = numbers.OrderByDescending(n => n.ToString().Sum(c => c - '0')).ToArray();
        Console.WriteLine("Сортування за зменшенням суми цифр числа:");
        Console.WriteLine(string.Join(", ", sortedDescending));
        //2
        string[] countries1 = { "Ukraine", "France", "Germany", "Italy" };
        string[] countries2 = { "Germany", "Italy", "Spain", "Portugal" };

        var difference = countries1.Except(countries2).ToArray();
        Console.WriteLine("Рiзниця масивiв:");
        Console.WriteLine(string.Join(", ", difference));

        var intersection = countries1.Intersect(countries2).ToArray();
        Console.WriteLine("Перетин масивiв:");
        Console.WriteLine(string.Join(", ", intersection));

        var union = countries1.Union(countries2).ToArray();
        Console.WriteLine("Об'єднання масивiв:");
        Console.WriteLine(string.Join(", ", union));

        var distinct = countries1.Distinct().ToArray();
        Console.WriteLine("Перший масив без повторень:");
        Console.WriteLine(string.Join(", ", distinct));
        //3
        var devices1 = new[]
        {
            new Device { Name = "Laptop", Manufacturer = "Dell", Price = 1000 },
            new Device { Name = "Phone", Manufacturer = "Samsung", Price = 500 },
            new Device { Name = "Tablet", Manufacturer = "Apple", Price = 800 }
        };

        var devices2 = new[]
        {
            new Device { Name = "Smartwatch", Manufacturer = "Apple", Price = 300 },
            new Device { Name = "Monitor", Manufacturer = "Dell", Price = 200 },
            new Device { Name = "Phone", Manufacturer = "Sony", Price = 600 }
        };

        // Різниця масивів
        var deviceDifference = devices1
            .Where(d1 => !devices2.Any(d2 => d2.Manufacturer == d1.Manufacturer))
            .ToArray();
        Console.WriteLine("Рiзниця масивiв пристроiв:");
        foreach (var device in deviceDifference)
        {
            Console.WriteLine(device);
        }

        // Перетин масивів
        var deviceIntersection = devices1
            .Where(d1 => devices2.Any(d2 => d2.Manufacturer == d1.Manufacturer))
            .ToArray();
        Console.WriteLine("Перетин масивiв пристроiв:");
        foreach (var device in deviceIntersection)
        {
            Console.WriteLine(device);
        }

        // Об'єднання масивів
        var deviceUnion = devices1
            .Union(devices2, new DeviceManufacturerComparer())
            .ToArray();
        Console.WriteLine("Об'єднання масивiв пристроiв:");
        foreach (var device in deviceUnion)
        {
            Console.WriteLine(device);
        }
    }
}
