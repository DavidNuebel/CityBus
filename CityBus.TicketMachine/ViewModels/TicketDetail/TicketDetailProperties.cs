using CityBus.TicketMachine.Libraries.MvvmHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CityBus.TicketMachine.ViewModels.TicketDetail
{
    class TicketDetailProperties : ObservableObject
    {
        public TicketDetailProperties() { }

        private int ticketID;
        public int TicketID
        {
            get
            {
                return ticketID;
            }
            set
            {
                ticketID = value;
                RaisePropertyChanged(nameof(TicketID));
            }
        }

        private Guid ticketSerial;
        public Guid TicketSerial
        {
            get
            {
                return ticketSerial;
            }
            set
            {
                ticketSerial = value;
                RaisePropertyChanged(nameof(TicketSerial));
            }
        }

        private string ticketCreation;
        public string TicketCreation
        {
            get
            {
                return ticketCreation;
            }
            set
            {
                ticketCreation = value;
                RaisePropertyChanged(nameof(TicketCreation));
            }
        }

        private string ticketExpiry;
        public string TicketExpiry
        {
            get
            {
                return ticketExpiry;
            }
            set
            {
                ticketExpiry = value;
                RaisePropertyChanged(nameof(TicketExpiry));
            }
        }

        private string ticketClass;
        public string TicketClass
        {
            get
            {
                return ticketClass;
            }
            set
            {
                ticketClass = value;
                RaisePropertyChanged(nameof(TicketClass));
            }
        }

        private float ticketPrice;
        public float TicketPrice
        {
            get
            {
                return ticketPrice;
            }
            set
            {
                ticketPrice = value;
                RaisePropertyChanged(nameof(TicketExpiry));
                RaisePropertyChanged(nameof(TicketPriceFormatted));
            }
        }
        public string TicketPriceFormatted
        {
            get
            {
                return ticketPrice.ToString("0.00 €");
            }
        }
    }
}
