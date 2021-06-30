using System;
using System.Threading;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class UI
    {
        private readonly Interfaces.MainMenu r_InterfaceMainMenu;
        private readonly Delegates.MainMenu r_DelegateMainMenu;

        public UI()
        {
            r_DelegateMainMenu = new MainMenu();
            r_InterfaceMainMenu = new Interfaces.MainMenu();
        }

        public void BuildMenusAndRunThemOneByOne()
        { 
            BuildInterfaceMenu(); 
            BuildDelegatesMenu();
            Console.WriteLine("Now displaying interface test");
            Thread.Sleep(2000);
            Console.Clear();
            r_InterfaceMainMenu.Show();
            Console.Clear();
            Console.WriteLine("Now moving to delegates test");
            Thread.Sleep(2000);
            r_DelegateMainMenu.Show();
        }

        public void BuildInterfaceMenu()
        {
            Interfaces.MenuItem versionAndSpaces = new Ex04.Menus.Interfaces.MenuItem("Version and spaces");
            versionAndSpaces.AddMenuOption("show Version", new Version());
            versionAndSpaces.AddMenuOption("Count Spaces", new SpaceCounter());
            r_InterfaceMainMenu.Menu.AddSubMenu(versionAndSpaces);
            Interfaces.MenuItem showDateTime = new Ex04.Menus.Interfaces.MenuItem("Show Date/Time");
            showDateTime.AddMenuOption("Show Date", new ShowDate());
            showDateTime.AddMenuOption("show Time", new ShowTime());
            r_InterfaceMainMenu.Menu.AddSubMenu(showDateTime);
        }

        public void BuildDelegatesMenu()
        {
            SubMenu versionAndSpaces = new SubMenu("Version And Spaces");
            MenuItem showVersion = new MenuItem("Show Version", new Version().OnChosenItem);
            versionAndSpaces.AddMenuOption(showVersion);
            MenuItem countSpaces = new MenuItem("Count Spaces", new SpaceCounter().OnChosenItem);
            versionAndSpaces.AddMenuOption(countSpaces);
            r_DelegateMainMenu.Menus.AddMenuOption(versionAndSpaces);
            SubMenu showDateTime = new SubMenu("Show Date/Time");
            MenuItem showTime = new MenuItem("Show Time", new ShowTime().OnChosenItem);
            MenuItem showDate = new MenuItem("Show Date", new ShowDate().OnChosenItem);
            showDateTime.AddMenuOption(showDate);
            showDateTime.AddMenuOption(showTime);
            r_DelegateMainMenu.Menus.AddMenuOption(showDateTime);
        }
    }
}
