using DemoApp.Core;
using DemoApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Models
{
    public class SecurityModel : BindableBase
    {
        private List<HomeMenuItem> _menuItems;

        public SecurityModel()
        {
            MenuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About" }
            };
        }

        public List<HomeMenuItem> MenuItems
        {
            get
            {
                return _menuItems;
            }
            set
            {
                SetProperty(ref _menuItems, value);
            }
        }
    }
}
