using CityBus.TicketMachine.ViewModels.Dashboard.Commands;
using CityBus.TicketMachine.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CityBus.TicketMachine.ViewModels.Dashboard
{
    class DashboardViewModel
    {
        private static DashboardViewModel instance;
        public static DashboardViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new DashboardViewModel();
                return instance;
            }
        }

        public DashboardProperties Properties { get; set; }
        public DashboardCommands Commands { get; set; }
        public Views.PaymentDialog PaymentDialog { get; set; }

        private DashboardViewModel()
        {
            Properties = new DashboardProperties();
            Commands = new DashboardCommands();
        }
    }
}
