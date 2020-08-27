using CityBus.Database.Models;
using CityBus.TicketMachine.Libraries.MvvmHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityBus.TicketMachine.ViewModels.PaymentDialog
{
    class PaymentDialogProperties : ObservableObject
    {
        public PaymentDialogProperties() {}

        private int fiftyEuro;   
        public int FiftyEuro
        {
            get { return fiftyEuro; }
            set 
            {
                fiftyEuro = value;
                RaisePropertyChanged(nameof(FiftyEuro));
            }
        }

        private int twentyEuro;
        public int TwentyEuro
        {
            get { return twentyEuro; }
            set 
            {
                twentyEuro = value;
                RaisePropertyChanged(nameof(TwentyEuro));
            }
        }

        private int tenEuro;
        public int TenEuro
        {
            get { return tenEuro; }
            set
            { 
                tenEuro = value;
                RaisePropertyChanged(nameof(TenEuro));
            }
        }


        private int fiveEuro;
        public int FiveEuro
        {
            get { return fiveEuro; }
            set
            { 
                fiveEuro = value;
                RaisePropertyChanged(nameof(FiveEuro));
            }
        }


        private int twoEuro;
        public int TwoEuro
        {
            get { return twoEuro; }
            set 
            { 
                twoEuro = value;
                RaisePropertyChanged(nameof(TwoEuro));
            }
        }


        private int oneEuro;
        public int OneEuro
        {
            get { return oneEuro; }
            set 
            {
                oneEuro = value;
                RaisePropertyChanged(nameof(OneEuro));
            }
        }


        private int fiftyCent;
        public int FiftyCent
        {
            get { return fiftyCent; }
            set
            { 
                fiftyCent = value;
                RaisePropertyChanged(nameof(FiftyCent));
            }
        }

        private int twentyCent;
        public int TwentyCent
        {
            get { return twentyCent; }
            set 
            { 
                twentyCent = value;
                RaisePropertyChanged(nameof(TwentyCent));
            }
        }

        private int tenCent;
        public int TenCent
        {
            get { return tenCent; }
            set 
            { 
                tenCent = value;
                RaisePropertyChanged(nameof(TenCent));
            }
        }

        private int fiveCent;
        public int FiveCent
        {
            get { return fiveCent; }
            set
            {
                fiveCent = value;
                RaisePropertyChanged(nameof(FiveCent));
            }
        }

        private int twoCent;
        public int TwoCent
        {
            get { return twoCent; }
            set
            { 
                twoCent = value;
                RaisePropertyChanged(nameof(TwoCent));
            }
        }

        private int oneCent;
        public int OneCent
        {
            get { return oneCent; }
            set 
            { 
                oneCent = value;
                RaisePropertyChanged(nameof(OneCent));
            }
        }

        private float cashInserted;
        public float CashInserted
        {
            get { return cashInserted; }
            set 
            { 
                cashInserted = value;
                if (ticketCondition.Amount <= cashInserted)
                    CashBack = cashInserted - ticketCondition.Amount;
                RaisePropertyChanged(nameof(CashInserted));
                RaisePropertyChanged(nameof(CashInsertedFormatted));
                RaisePropertyChanged(nameof(CashBack));
            }
        }

        private float cashBack;
        public float CashBack
        {
            get { return cashBack; }
            set 
            {
                cashBack = value;
                RaisePropertyChanged(nameof(CashBack));
                RaisePropertyChanged(nameof(CashBackFormatted));
            }
        }

        private TicketCondition ticketCondition;
        public TicketCondition TicketCondition
        {
            get { return ticketCondition; }
            set { ticketCondition = value; }
        }

        public string CashInsertedFormatted
        {
            get 
            { 
                return cashInserted.ToString("0.00 €"); 
            }
        }

        public string CashBackFormatted
        {
            get
            {
                return cashBack.ToString("0.00 €");
            }
        }

        public string PriceFormatted
        {
            get 
            {
                return ticketCondition.Amount.ToString("0.00 €"); 
            }
        }
    }
}
