using CityBus.Database.Models;
using CityBus.TicketMachine.ViewModels.TicketDetail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CityBus.TicketMachine.Views
{
    /// <summary>
    /// Interaction logic for TicketDetail.xaml
    /// </summary>
    public partial class TicketDetail : Window
    {
        public TicketDetail(Ticket ticket)
        {
            InitializeComponent();
            DataContext = TicketDetailViewModel.Instance;
            TicketDetailViewModel.Instance.Properties.TicketID = ticket.ID;
            TicketDetailViewModel.Instance.Properties.TicketSerial = ticket.Serial;
            TicketDetailViewModel.Instance.Properties.TicketCreation = ticket.CreationTime.ToString("dd.MM.yyyy HH:mm.ss");
            TicketDetailViewModel.Instance.Properties.TicketExpiry = ticket.ExpiryTime.ToString("dd.MM.yyyy HH:mm.ss");
            TicketDetailViewModel.Instance.Properties.TicketClass = ticket.TicketCondition.Short;
            TicketDetailViewModel.Instance.Properties.TicketPrice = ticket.TicketCondition.Amount;
        }
    }
}
