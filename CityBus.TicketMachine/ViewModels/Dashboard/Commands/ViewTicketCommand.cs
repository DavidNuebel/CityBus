using CityBus.Database.Models;
using CityBus.TicketMachine.Libraries.MvvmHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CityBus.TicketMachine.ViewModels.Dashboard.Commands
{
    class ViewTicketCommand
    {
        private ICommand cmd;
        public ICommand Cmd => cmd ?? (cmd = new RelayCommand(param => Execute(param), () => CanExecute));

        private bool CanExecute
        {
            get { return true; }
        }

        private async void Execute(object param)
        {
            Ticket ticket = param as Ticket;
            Views.TicketDetail dialog = new Views.TicketDetail(ticket);
            dialog.ShowDialog();
        }
    }
}
