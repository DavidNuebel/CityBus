using CityBus.Database.Models;
using CityBus.TicketMachine.Libraries.MvvmHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CityBus.TicketMachine.ViewModels.Dashboard
{
    class DashboardProperties : ObservableObject
    {
        public DashboardProperties() { }

        private ObservableCollection<TicketCondition> ticketConditions;
        public ObservableCollection<TicketCondition> TicketConditions
        {
            get 
            {
                if(ticketConditions == null)
                    ticketConditions = new ObservableCollection<TicketCondition>();
                return ticketConditions;
            }
            set
            {
                ticketConditions = value;
                RaisePropertyChanged(nameof(TicketConditions));
            }
        }

        private TicketCondition ticketConditionSelected;
        public TicketCondition TicketConditionSelected
        {
            get { return ticketConditionSelected; }
            set
            {
                ticketConditionSelected = value;

                if (ticketConditionSelected == null)
                    CheckoutEnabled = false;
                else
                    CheckoutEnabled = true;

                RaisePropertyChanged(nameof(TicketConditionSelected));
            }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                RaisePropertyChanged(nameof(Status));
            }
        }

        private ObservableCollection<Ticket> tickets;
        public ObservableCollection<Ticket> Tickets
        { 
            get 
            {
                if (tickets == null)
                    tickets = new ObservableCollection<Ticket>();
                return tickets; 
            }
            set
            {
                tickets = value;
                RaisePropertyChanged(nameof(Tickets));
            }
        }

        private Ticket ticketSelected;
        public Ticket TicketSelected
        {
            get { return ticketSelected; }
            set
            {
                ticketSelected = value;

                if (ticketSelected == null)
                    ViewTicketEnabled = false;
                else
                    ViewTicketEnabled = true;

                RaisePropertyChanged(nameof(TicketSelected));
            }
        }

        private bool checkoutEnabled = false;
        public bool CheckoutEnabled
        {
            get { return checkoutEnabled; }
            set
            {
                checkoutEnabled = value;
                RaisePropertyChanged(nameof(CheckoutEnabled));
            }
        }

        private bool viewTicketEnabled = false;
        public bool ViewTicketEnabled
        {
            get { return viewTicketEnabled; }
            set
            {
                viewTicketEnabled = value;
                RaisePropertyChanged(nameof(ViewTicketEnabled));
            }
        }
    }
}
