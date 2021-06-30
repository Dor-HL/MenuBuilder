using System;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private readonly MenuItem r_MainMenu;

        public MainMenu()
        {
            r_MainMenu = new MenuItem("Main Menu");
        }

        public MenuItem Menu
        {
            get
            {
                return r_MainMenu;
            }
        }

        public void Show()
        {
            r_MainMenu.Show();
        }
    }
}
