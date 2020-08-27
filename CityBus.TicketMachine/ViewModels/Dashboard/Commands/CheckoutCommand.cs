using CityBus.TicketMachine.Libraries.HubConnector;
using CityBus.TicketMachine.Libraries.MvvmHelper;
using CityBus.TicketMachine.Views;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CityBus.TicketMachine.ViewModels.Dashboard.Commands
{
    class CheckoutCommand
    {
        private ICommand cmd;
        public ICommand Cmd => cmd ?? (cmd = new RelayCommand(param => Execute(param), () => CanExecute));

        private bool CanExecute
        {
            get { return true; }
        }

        private async void Execute(object param)
        {
            DashboardViewModel.Instance.PaymentDialog = new Views.PaymentDialog(DashboardViewModel.Instance.Properties.TicketConditionSelected);
            DashboardViewModel.Instance.PaymentDialog.ShowDialog();
        }
    }
}
