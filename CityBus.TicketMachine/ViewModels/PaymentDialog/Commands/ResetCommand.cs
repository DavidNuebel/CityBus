using CityBus.TicketMachine.Libraries.MvvmHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CityBus.TicketMachine.ViewModels.PaymentDialog.Commands
{
    class ResetCommand
    {
        private ICommand cmd;
        public ICommand Cmd => cmd ?? (cmd = new RelayCommand(param => Execute(param), () => CanExecute));

        private bool CanExecute
        {
            get { return true; }
        }

        private async void Execute(object param)
        {
            PaymentDialogViewModel.Instance.Properties.FiftyEuro = 0;
            PaymentDialogViewModel.Instance.Properties.TwentyEuro = 0;
            PaymentDialogViewModel.Instance.Properties.TenEuro = 0;
            PaymentDialogViewModel.Instance.Properties.FiveEuro = 0;
            PaymentDialogViewModel.Instance.Properties.TwoEuro = 0;
            PaymentDialogViewModel.Instance.Properties.OneEuro = 0;
            PaymentDialogViewModel.Instance.Properties.FiftyCent = 0;
            PaymentDialogViewModel.Instance.Properties.TwentyCent = 0;
            PaymentDialogViewModel.Instance.Properties.TenCent = 0;
            PaymentDialogViewModel.Instance.Properties.FiveCent = 0;
            PaymentDialogViewModel.Instance.Properties.TwoCent = 0;
            PaymentDialogViewModel.Instance.Properties.OneCent = 0;
            PaymentDialogViewModel.Instance.Properties.CashInserted = 0;
            PaymentDialogViewModel.Instance.Properties.CashBack = 0;
        }
    }
}
