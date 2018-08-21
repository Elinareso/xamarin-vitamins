using DemoApp.Core.Entities;
using DemoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private SecurityModel _securityModel;

        public MenuViewModel()
        {
            _securityModel = new SecurityModel();
        }

        public List<HomeMenuItem> MenuItems => _securityModel.MenuItems;
    }
}
