﻿using SnackMachine.ColdDrinks;
using SnackMachine.Snacks;
using SnackMachine.Suppliers;

namespace SnackMachine;

public class Stock
{
    //מילון עם שם המוצר כאילו הסוג ורשימת מוצרים
    //public Dictionary<Snack, int> Snacks { get ; }
    //public Dictionary<ColdDrink, int> ColdDrinks { get; }

    //public Dictionary<HotDrink, int> HotDrinks { get; }

    public Dictionary<Product, List<Product>> Snacks { get ; }
    public Dictionary<Product, List<Product>> ColdDrinks { get; }
    public Dictionary<Product, List<Product>> HotDrinks { get; }



    //פונקציה שמקבלת סטרינג או אינם ומחזירה את המוצר
    //תעדכן את הספקים
    public Stock()
    {
        Snacks = new();
        ColdDrinks = new();
        HotDrinks = new();

        List<Supplier> suppliers = new();
        suppliers.Add(new OsemSupplier("Giora", "giora@kibbutz.cat", new List<Product> { new Snack("ביסלי", 4.90, 6), new Snack("במבה", 3.90, 10), new ColdDrink("לימונדה", 8, 2) }));
        suppliers.Add(new CocaColaSupplier("Yoram", "yoram@crazy.com", new List<Product> { new ColdDrink("קוקה קולה", 9, 22), new ColdDrink("פאנטה", 9, 17) }));
        suppliers.Add(new OmerBarLevSupplier("Omer Bar Lev", "director@angel.monkey", new List<Product> { new HotDrink("קפוצ'ינו", 10, 100), new HotDrink("שוקו פרלינים", 24, 5), new HotDrink("תה חמדת השקד", 6, 1) }));
        foreach (var item in suppliers)
        {
            item.Products.ForEach((p) =>
            {
                if (p is Snack)
                {
                    Snacks.Add(new Snack(p.Name, p.Price), new List<Snack>() { new Snack("ביסלי", 4.90, 6), new Snack("ביסלי", 4.90, 6) });
                }
                else if (p is ColdDrink)
                {
                    ColdDrinks.Add(new ColdDrink(p.Name, p.Price), );
                }
                else if (p is HotDrink)
                {
                    HotDrinks.Add(new HotDrink(p.Name, p.Price), );
                }
            });
        }
        //Machine machine = new (Snacks, ColdDrinks, HotDrinks);
    }
}