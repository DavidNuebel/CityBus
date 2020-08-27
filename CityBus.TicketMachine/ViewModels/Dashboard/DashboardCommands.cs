using System;
using System.Collections.Generic;
using System.Text;

namespace CityBus.TicketMachine.ViewModels.Dashboard.Commands
{
    class DashboardCommands
    {
        public CheckoutCommand Checkout { get; set; }
        public ViewTicketCommand ViewTicket { get; set; }

        public DashboardCommands() 
        {
            Checkout = new CheckoutCommand();
            ViewTicket = new ViewTicketCommand();
        }
    }
}
