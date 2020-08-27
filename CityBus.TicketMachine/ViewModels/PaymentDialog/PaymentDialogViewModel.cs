using System;
using System.Collections.Generic;
using System.Text;

namespace CityBus.TicketMachine.ViewModels.PaymentDialog
{
    class PaymentDialogViewModel
    {
        private static PaymentDialogViewModel instance;

        public static PaymentDialogViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new PaymentDialogViewModel();
                return instance;
            }
        }


        public static void Dispose()
        {
            instance = null;
        }

        public PaymentDialogProperties Properties { get; set; }
        public PaymentDialogCommands Commands { get; set; }

        private PaymentDialogViewModel()
        {
            Properties = new PaymentDialogProperties();
            Commands = new PaymentDialogCommands();
        }

    }
}
