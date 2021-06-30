using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowTime : IMenuAction
    {
        public void OnChosenItem()
        {
            TimeSpan currentTimeOfDay  = DateTime.Now.TimeOfDay;
            string time = string.Format("The time now is {0}", currentTimeOfDay);
            Console.WriteLine(time);
        }
    }
}
