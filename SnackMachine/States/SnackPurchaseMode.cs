﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unipluss.Sign.ExternalContract.Entities;

namespace SnackMachine.States
{
    public class SnackPurchaseMode : IState
    {
        public static Form form { get; set; } = Application.OpenForms["form1"];
        public Context context { get; set; }

        public SnackPurchaseMode()
        {
            context = new Context(this);
        }
        public void ActionsHandler()
        {
            throw new NotImplementedException();
        }

        public void ButtonsHandler(Product p)
        {
            int x = 200;
            Label? title = form.Controls.Find("title", false).FirstOrDefault() as Label;
            title.Text = "כל החטיפים מיוצרים מקמח שנטחן לאחר הפסח, במיוחד הבמבה";

            Button? coldDrinkBtn = form.Controls.Find("coldDrinkBtn", false).FirstOrDefault() as Button;
            Button? hotDrinkBtn = form.Controls.Find("hotDrinkBtn", false).FirstOrDefault() as Button;
            Button? snackBtn = form.Controls.Find("snackBtn", false).FirstOrDefault() as Button;

            form.Controls.Remove(coldDrinkBtn);
            form.Controls.Remove(hotDrinkBtn);
            form.Controls.Remove(snackBtn);

            foreach (var item in context.Stock.Snacks)
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

        public void ButtonsHandler()
        {
            throw new NotImplementedException();
        }
    }
}
