﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackMachine.States
{
    public class HotDrinkPurchaseMode : IState
    {
        public static Form form = Application.OpenForms["form1"];
        public Context context { get; set; }
        //public Button BackBtn { get; set; } = form.Controls.Find("back", false).First() as Button;

        public HotDrinkPurchaseMode()
        {
            context = new Context(this);
        }
        public void ActionsHandler()
        {
            
        }

        public void ButtonsHandler(Product product)
        {
            int x = 200;
            Label? title = form.Controls.Find("title", false).FirstOrDefault() as Label;
            title.Text = "פיהוק הוא צעקה שקטה לקפה";

            Button? coldDrinkBtn = form.Controls.Find("coldDrinkBtn", false).FirstOrDefault() as Button;
            Button? hotDrinkBtn = form.Controls.Find("hotDrinkBtn", false).FirstOrDefault() as Button;
            Button? snackBtn = form.Controls.Find("snackBtn", false).FirstOrDefault() as Button;

            form.Controls.Remove(coldDrinkBtn);
            form.Controls.Remove(hotDrinkBtn);
            form.Controls.Remove(snackBtn);

            foreach (var item in context.Stock.HotDrinks)
            {
                Button btn = new Button();
                form.Controls.Add(btn);

                string name = item.Key.Name;

                btn.Width = 150;
                btn.Height = 30;
                btn.Text = $"{name} ₪{item.Key.Price}";
                btn.Location = new Point(x += 100, 200);
                btn.Name = name;
                btn.Click += (sender, e) =>
                {
                    Product product = context.Stock.GetProduct(name);
                    PaymentMode paymentMode = new PaymentMode();
                    context.ChangeMode(paymentMode);
                    context.State.ButtonsHandler(product);
                };
            }
        }

        
    }
}