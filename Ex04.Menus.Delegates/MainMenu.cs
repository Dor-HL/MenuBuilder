using System;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private readonly MenuItem r_MainMenu;

        public MainMenu()
        {
            r_MainMenu = new MenuItem("MainMenu");
            r_MainMenu.MenuItems.Add(new MenuItem("Exit"));
        }

        public void Show()
        {
            r_MainMenu.Show();
        }

        public MenuItem Menus
        {
            get 
            {
                return r_MainMenu;
            }
        }
    }
}
