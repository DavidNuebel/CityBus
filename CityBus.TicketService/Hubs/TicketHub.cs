using CityBus.Database.Contexts;
using CityBus.Database.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityBus.TicketService.Hubs
{
    public class TicketHub : Hub
    {
        public TicketServiceContext DbContext { get; set; }

        public TicketHub(TicketServiceContext dbcontext)
        {
            DbContext = dbcontext;

            if (!DbContext.TicketConditions.Any())
            {
                DbContext.TicketConditions.Add(new TicketCondition()
                {
                    Short = "C1",
                    Description = "Ticket Class 1",
                    ExpiryOffset = 2,
                    Amount = 1f
                });
                DbContext.TicketConditions.Add(new TicketCondition()
                {
                    Short = "C2",
                    Description = "Ticket Class 2",
                    ExpiryOffset = 2,
                    Amount = 1.5f
                });
                DbContext.TicketConditions.Add(new TicketCondition()
                {
                    Short = "C3",
                    Description = "Ticket Class 3",
                    ExpiryOffset = 2,
                    Amount = 2f
                });
                DbContext.TicketConditions.Add(new TicketCondition()
                {
                    Short = "DT",
                    Description = "Day Ticket",
                    ExpiryOffset = 24,
                    Amount = 4f
                });
                DbContext.TicketConditions.Add(new TicketCondition()
                {
                    Short = "MT",
                    Description = "Month Ticket",
                    ExpiryOffset = 720,
                    Amount = 18f
                });
                DbContext.SaveChanges();
            }
        }

        public async Task ReqTicket(int ticketconditionid)
        {
            Console.WriteLine($"{Context.ConnectionId}-(CLIENT) REQ [Ticket] ");

            TicketCondition ticketCondition = DbContext.TicketConditions.Where(tc => tc.ID == ticketconditionid).First();
            if (ticketCondition != null)
            {
                Ticket ticket = new Ticket()
                {
                    Serial = Guid.NewGuid(),
                    CreationTime = DateTime.Now,
                    ExpiryTime = DateTime.Now.AddHours(ticketCondition.ExpiryOffset),
                    TicketCondition = ticketCondition
                };
                await DbContext.Tickets.AddAsync(ticket);
                await DbContext.SaveChangesAsync();
                await Clients.All.SendAsync("RespTicket", ticket);
            }
            else
            {
                await Clients.Caller.SendAsync("RespTicket", null);
            }
        }

        public async Task ReqTickets()
        {
            Console.WriteLine($"{Context.ConnectionId}-(CLIENT) REQ [Tickets] ");
            List<Ticket> tickets = DbContext.Tickets.ToList();
            foreach (Ticket ticket in tickets)
                ticket.TicketCondition = DbContext.TicketConditions.Where(tc => tc.ID == DbContext.Tickets.Where(t => t.ID == ticket.ID).First().TicketCondition.ID).First();
            await Clients.Caller.SendAsync("RespTickets", tickets);

        }

        public async Task ReqTicketConditions()
        {
            Console.WriteLine($"{Context.ConnectionId}-(CLIENT) REQ [TicketConditions] ");
            await Clients.Caller.SendAsync("RespTicketConditions", DbContext.TicketConditions.ToList()); ;
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId}-(CLIENT) connected ");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine($"{Context.ConnectionId}-(CLIENT) disconnected ");
            return base.OnDisconnectedAsync(exception);
        }
    }
}
