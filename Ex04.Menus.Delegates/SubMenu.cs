using System;

namespace Ex04.Menus.Delegates
{
    public class SubMenu : MenuItem
    {
        public SubMenu(string i_Title) : base(i_Title)
        {
            ActionsUponPressed += Show;
            this.MenuItems.Add(new MenuItem("go Back"));
        }
    }
}
