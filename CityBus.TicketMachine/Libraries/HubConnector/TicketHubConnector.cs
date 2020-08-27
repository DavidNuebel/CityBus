using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using CityBus.Database.Models;
using CityBus.TicketMachine.ViewModels.Dashboard;
using CityBus.TicketMachine.ViewModels.PaymentDialog;
using Microsoft.AspNetCore.SignalR.Client;

namespace CityBus.TicketMachine.Libraries.HubConnector
{
    public class TicketHubConnector
    {
        private static TicketHubConnector instance;
        public static TicketHubConnector Instance
        {
            get
            {
                if (instance == null)
                    instance = new TicketHubConnector();
                return instance;
            }
            set { instance = value; }
        }

        private static string URL = "http://localhost:58360/ticketHub";

        private HubConnection Connection;

        private TicketHubConnector()
        {
            DashboardViewModel.Instance.Properties.Status = "connectiong...";
            Connection = new HubConnectionBuilder().WithUrl(URL).Build();
            RegisterEvents();
            try
            {
                Connection.StartAsync();
                DashboardViewModel.Instance.Properties.Status = "connected...";
            }
            catch (Exception)
            {
                DashboardViewModel.Instance.Properties.Status = "error...";
                MessageBox.Show("Cant connect to ticketHub", "Error");
            }
        }

        private void RegisterEvents()
        {
            Connection.Closed += async (error) =>
            {
                DashboardViewModel.Instance.Properties.Status = "reconnecting...";
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await Connection.StartAsync();
            };

            Connection.On<List<TicketCondition>>("RespTicketConditions", (list) =>
            {
                DashboardViewModel.Instance.Properties.Status = "fetching...";
                if (list.Count > 0)
                {
                    Dispatcher.CurrentDispatcher.Invoke(() =>
                    {
                        foreach (TicketCondition ticketCondition in list)
                        {
                            DashboardViewModel.Instance.Properties.TicketConditions.Add(ticketCondition);
                        }
                        DashboardViewModel.Instance.Properties.Status = "connected...";
                    });
                }
            });

            Connection.On<Ticket>("RespTicket", (ticket) =>
            {
                DashboardViewModel.Instance.Properties.Status = "fetching...";
                if (ticket != null)
                {
                    Dispatcher.CurrentDispatcher.Invoke(() =>
                    {
                        DashboardViewModel.Instance.Properties.Tickets.Add(ticket);
                        DashboardViewModel.Instance.Properties.Status = "connected...";
                    });
                }
            });

            Connection.On<List<Ticket>>("RespTickets", (tickets) =>
            {
                DashboardViewModel.Instance.Properties.Status = "fetching...";
                if (tickets != null)
                {
                    Dispatcher.CurrentDispatcher.Invoke(() =>
                    {
                        foreach(Ticket ticket in tickets)
                            DashboardViewModel.Instance.Properties.Tickets.Add(ticket);
                        DashboardViewModel.Instance.Properties.Status = "connected...";
                    });
                }
            });
        }

        public async Task RequestTicket(int ticketconditionid)
        {
            DashboardViewModel.Instance.Properties.Status = "requesting...";
            await Connection.InvokeAsync("ReqTicket", ticketconditionid);
        }

        public async Task ReqTicketConditions()
        {
            DashboardViewModel.Instance.Properties.Status = "requesting...";
            await Connection.SendAsync("ReqTicketConditions");
        }

        public async Task ReqTickets()
        {
            DashboardViewModel.Instance.Properties.Status = "requesting...";
            await Connection.SendAsync("ReqTickets");
        }

    }
}