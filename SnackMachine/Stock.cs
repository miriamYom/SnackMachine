﻿using SnackMachine.ColdDrinks;
using SnackMachine.HotDrinks;
using SnackMachine.Snacks;
using SnackMachine.Suppliers;
using System.Collections.Generic;

namespace SnackMachine;

public class Stock
{
    const int NUMFORORDERS = 10;
    int snacksMin = 20;
    int coldDrinkMin = 5;
    public Dictionary<string, List<Product>> Snacks { get; }
    public Dictionary<string, List<Product>> ColdDrinks { get; }
    public Dictionary<string, List<Product>> HotDrinks { get; }

    public Dictionary<string, Supplier> ProductsSuppliers { get; }


    public Stock(Dictionary<string, List<Product>> snacks, Dictionary<string, 
        List<Product>> coldDrink,  Dictionary<string, Supplier> productsSuppliers)
    {
        Snacks = snacks;
        ColdDrinks = coldDrink; 
        //HotDrinks = hotDrink; 
        ProductsSuppliers = productsSuppliers;
    }

    public Product GetSnacksProduct(string productName)
    {
        if (Snacks.ContainsKey(productName))
        {
            if (Snacks[productName].Count == snacksMin)
            {
                ProductsSuppliers[productName].OrderProduct(productName, NUMFORORDERS);
            }
            if (Snacks[productName].Count == 0)
            {
                return null;
            }
            Product product = Snacks[productName][0];
            Snacks[productName].Remove(product);
            return product;
        }
        return null;
    }

    public Product GetColdDrinksProduct(string productName)
    {
        if (ColdDrinks.ContainsKey(productName))
        {
            if (ColdDrinks[productName].Count == coldDrinkMin)
            {
                ProductsSuppliers[productName].OrderProduct(productName, NUMFORORDERS);
            }
            if (ColdDrinks[productName].Count == 0)
            {
                return null;
            }
            Product product = ColdDrinks[productName][0];
            ColdDrinks[productName].Remove(product);
            return product;
        }
        return null;
    }
    public Product GetHotDrinksProduct(string productName)
    {
        if (productName.Equals("coco"))
        {
            Coco c = new Coco();
            c.AddPowder();
            c.AddSuger();
            c.AddWater();
            c.AddMilk();

            return c.GetHotDrink();
        }
        else if (productName.Equals("cappucino"))
        {
            Coffee coffee = new Coffee();
            coffee.AddPowder();
            coffee.AddSuger();
            coffee.AddWater();
            coffee.AddMilk();

            return coffee.GetHotDrink();
        }

        return null;
    }
}