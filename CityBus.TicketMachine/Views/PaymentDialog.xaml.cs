using CityBus.Database.Models;
using CityBus.TicketMachine.ViewModels.PaymentDialog;
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
    /// Interaction logic for PaymentDialog.xaml
    /// </summary>
    public partial class PaymentDialog : Window
    {

        public PaymentDialog(TicketCondition ticketCondition)
        {
            InitializeComponent();
            DataContext = PaymentDialogViewModel.Instance;
            PaymentDialogViewModel.Instance.Properties.TicketCondition = ticketCondition;
        }
    }
}
