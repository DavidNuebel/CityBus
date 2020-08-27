using CityBus.TicketMachine.Libraries.MvvmHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace CityBus.TicketMachine.ViewModels.PaymentDialog.Commands
{
    class CashCommands
    {
        
        private ICommand cmd;
        public ICommand Cmd => cmd ?? (cmd = new RelayCommand(param => Execute(param), () => CanExecute));

        private bool CanExecute
        {
            get { return true; }
        }

        private async void Execute(object param)
        {
            Dispatcher.CurrentDispatcher.Invoke(() =>
            {
                float val = Convert.ToSingle(param) / 100f;
                switch (val)
                {
                    case 50f:
                        PaymentDialogViewModel.Instance.Properties.FiftyEuro++;
                        break;
                    case 20f:
                        PaymentDialogViewModel.Instance.Properties.TwentyEuro++;
                        break;
                    case 10f:
                        PaymentDialogViewModel.Instance.Properties.TenEuro++;
                        break;
                    case 5f:
                        PaymentDialogViewModel.Instance.Properties.FiveEuro++;
                        break;
                    case 2f:
                        PaymentDialogViewModel.Instance.Properties.TwoEuro++;
                        break;
                    case 1f:
                        PaymentDialogViewModel.Instance.Properties.OneEuro++;
                        break;
                    case 0.5f:
                        PaymentDialogViewModel.Instance.Properties.FiftyCent++;
                        break;
                    case 0.2f:
                        PaymentDialogViewModel.Instance.Properties.TwentyCent++;
                        break;
                    case 0.1f:
                        PaymentDialogViewModel.Instance.Properties.TenCent++;
                        break;
                    case 0.05f:
                        PaymentDialogViewModel.Instance.Properties.FiveCent++;
                        break;
                    case 0.02f:
                        PaymentDialogViewModel.Instance.Properties.TwoCent++;
                        break;
                    default:
                        PaymentDialogViewModel.Instance.Properties.OneCent++;
                        break;
                }
                PaymentDialogViewModel.Instance.Properties.CashInserted += val;
            });
        }
        
    }
}
