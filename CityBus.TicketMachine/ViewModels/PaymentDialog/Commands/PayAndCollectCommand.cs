using CityBus.TicketMachine.Libraries.HubConnector;
using CityBus.TicketMachine.Libraries.Maths;
using CityBus.TicketMachine.Libraries.MvvmHelper;
using CityBus.TicketMachine.ViewModels.Dashboard;
using CityBus.TicketMachine.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CityBus.TicketMachine.ViewModels.PaymentDialog.Commands
{
    class PayAndCollectCommand
    {
        private ICommand cmd;
        public ICommand Cmd => cmd ?? (cmd = new RelayCommand(param => Execute(param), () => CanExecute));

        private bool CanExecute
        {
            get { return true; }
        }

        private async void Execute(object param)
        {
            if (PaymentDialogViewModel.Instance.Properties.CashInserted < DashboardViewModel.Instance.Properties.TicketConditionSelected.Amount)
                MessageBox.Show("Please insert more money to pay the ticket!", "More CAAAAAASSSSHHHH!");
            else
            {
                // placeholder
                string outputMessage = "";
                int[] cashback = CashbackGenerator.Generate(PaymentDialogViewModel.Instance.Properties.CashBack);
                for (int i = 0; i < cashback.Length; i++)
                {
                    if (cashback[i] != 0)
                        outputMessage += $"x{cashback[i]} {CashbackGenerator.title[i]}\n";
                }
                if(outputMessage != "")
                    MessageBox.Show(outputMessage, "Cashback!");
                // /placeholder

                await TicketHubConnector.Instance.RequestTicket(PaymentDialogViewModel.Instance.Properties.TicketCondition.ID);
                DashboardViewModel.Instance.PaymentDialog.Close();
                PaymentDialogViewModel.Dispose();
            }
        }
    }
}
