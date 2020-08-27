using CityBus.TicketMachine.ViewModels.PaymentDialog.Commands;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CityBus.TicketMachine.ViewModels.PaymentDialog
{
    class PaymentDialogCommands
    {
        public CashCommands CashCommands { get; set; }
        public PayAndCollectCommand PayAndCollect { get; set; }
        public ResetCommand Reset { get; set; }

        public PaymentDialogCommands()
        {
            CashCommands = new CashCommands();
            PayAndCollect = new PayAndCollectCommand();
            Reset = new ResetCommand();
        }
    }
}
