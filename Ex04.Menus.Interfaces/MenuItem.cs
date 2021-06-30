using System;
using System.Collections.Generic;
using System.Threading;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : IMenuAction
    {
        private readonly Dictionary<int, string> r_MenusOptionList; 
        private readonly Dictionary<int, IMenuAction> r_MenusActivityList; 
        private readonly string r_ItemTitle;
        private int m_Level = 0;

        public int Level
        {
            get
            {
                return m_Level;
            }

            set
            {
                m_Level = value;
            }
        }

        public MenuItem(string i_Title) 
        {
            r_ItemTitle = i_Title;
            r_MenusOptionList = new Dictionary<int, string>();
            r_MenusActivityList = new Dictionary<int, IMenuAction>();
            r_MenusOptionList.Add(0, "exit");
        }

        public void AddMenuOption(string i_StringToDisplay, IMenuAction io_MenuItem)
        {
            int itemNumber = r_MenusOptionList.Count;
            r_MenusOptionList.Add(itemNumber, i_StringToDisplay);
            r_MenusActivityList.Add(itemNumber, io_MenuItem); 
        }

        public void AddSubMenu(MenuItem io_SubMenu)
        {
            AddMenuOption(io_SubMenu.r_ItemTitle, io_SubMenu);
            io_SubMenu.m_Level = m_Level + 1;
            io_SubMenu.r_MenusOptionList[0] = "go Back";
            io_SubMenu.UpdateLevels(m_Level + 1);
        }

        public void UpdateLevels(int i_PreviousLevel)
        {
            foreach(KeyValuePair<int, IMenuAction> currentOption in r_MenusActivityList)
            {
                MenuItem item = currentOption.Value as MenuItem;
                if(item != null)
                {
                    item.Level = i_PreviousLevel + 1;
                    item.UpdateLevels(i_PreviousLevel + 1);
                }
            }
        }

        public void Show()
        {
            Console.Clear();
            bool isMenuStillActive = true;

            while (isMenuStillActive)
            {
                string level = string.Format("Current level is: {0}", m_Level);
                Console.WriteLine(level);
                Console.WriteLine(r_ItemTitle);
                foreach (KeyValuePair<int, string> currentMenuOption in r_MenusOptionList)
                {
                    string display = string.Format("Please press {0} to {1}", currentMenuOption.Key, currentMenuOption.Value);
                    Console.WriteLine(display);
                }

                Console.WriteLine("Please choose an option");
                bool invalidInput = true;
                int userChoiceAsInt = 0;
                while (invalidInput)
                {
                    string userChoice = Console.ReadLine(); 

                    try
                    {
                        userChoiceAsInt = int.Parse(userChoice);
                        if (userChoiceAsInt < 0 || userChoiceAsInt > r_MenusOptionList.Count - 1)
                        {
                            throw new ValueOutOfRangeException(new Exception(), r_MenusOptionList.Count - 1, 0, "input");
                        }

                        invalidInput = false;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter a number not a symbol or a letter");
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                if (userChoiceAsInt == 0)
                {
                    if (m_Level != 0)
                    {
                        Console.WriteLine("Going back to last menu");
                    }

                    isMenuStillActive = false;
                }
                else
                {
                    r_MenusActivityList.TryGetValue(userChoiceAsInt, out IMenuAction returnedActivity); 
                    Console.Clear();
                    returnedActivity.OnChosenItem();
                    Thread.Sleep(2500);
                    Console.Clear();
                }
            }
        }

        public void OnChosenItem()
        {
            Show();
        }
    }
}
