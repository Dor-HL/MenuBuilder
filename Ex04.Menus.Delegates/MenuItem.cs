using System;
using System.Collections.Generic;
using System.Threading;

namespace Ex04.Menus.Delegates
{
   public class MenuItem
    {
        private readonly List<MenuItem> r_ListOfMenuItems;
        private string m_Title;
        private int m_Level = 0;

        public event Action ActionsUponPressed;

        public string Title
        {
            get
            {
                return m_Title;
            }

            private set
            {
                m_Title = value;
            }
        }

        public int Level
        {
            get
            {
                return m_Level;
            }

            private set
            {
                m_Level = value;
            }
        }

        public List<MenuItem> MenuItems
        {
            get
            {
                return r_ListOfMenuItems;
            }
        }

        public MenuItem(string i_Title)
        {
            m_Title = i_Title;
            r_ListOfMenuItems = new List<MenuItem>();
        }

        public MenuItem(string i_Title, Action io_ToDoUponPressed)
        {
            m_Title = i_Title;
            r_ListOfMenuItems = new List<MenuItem>();
            ActionsUponPressed += io_ToDoUponPressed;
        }

        protected virtual void OnBecamePressed()
        {
            if (ActionsUponPressed != null)
            {
                ActionsUponPressed.Invoke();
            }
        }

        public void MenuItem_OnBecamePressed()
        {
            OnBecamePressed();
        }

        public void AddMenuOption(MenuItem io_Item)
        {
            MenuItems.Add(io_Item);
            io_Item.Level = this.Level + 1;
            io_Item.UpdateLevels(this.Level + 1);
        }

        public void UpdateLevels(int i_PreviousLevel)
        {
            foreach(MenuItem currentItem in r_ListOfMenuItems)
            {
                currentItem.m_Level = i_PreviousLevel + 1;
                currentItem.UpdateLevels(i_PreviousLevel + 1);
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
                Console.WriteLine(Title);
                int counter = 0;
                foreach (MenuItem currentItem in MenuItems)
                {
                    string display = string.Format("Please press {0} to {1}", counter, currentItem.Title);
                    Console.WriteLine(display);
                    counter++;
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
                        if (userChoiceAsInt < 0 || userChoiceAsInt > MenuItems.Count - 1)
                        {
                            throw new ValueOutOfRangeException(new Exception(), MenuItems.Count - 1, 0, "input");
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
                    Console.Clear();
                    MenuItems[userChoiceAsInt].MenuItem_OnBecamePressed();
                    Thread.Sleep(2500);
                    Console.Clear();
                }
            }
        }
    }
}
