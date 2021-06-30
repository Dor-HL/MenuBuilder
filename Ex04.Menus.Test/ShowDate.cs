using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowDate : IMenuAction
    {
        public void OnChosenItem()
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            string time = string.Format("The Date is {0}", date);
            Console.WriteLine(time);
        }
    }
}
