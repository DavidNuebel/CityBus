using CityBus.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityBus.TicketMachine.ViewModels.TicketDetail
{
    class TicketDetailViewModel
    {
        private static TicketDetailViewModel instance;
        public static TicketDetailViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new TicketDetailViewModel();
                return instance;
            }
        }

        public TicketDetailProperties Properties { get; set; }

        private TicketDetailViewModel()
        {
            Properties = new TicketDetailProperties();
        }
    }
}
