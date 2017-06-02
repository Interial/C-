using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public interface IEmailSender
    {
        
        void SendMessage(string receiver, string title, string message);
    }
    public class EmailSender : IEmailSender
    {
        public void SendMessage(string receiver, string title, string message)
        {
            throw new NotImplementedException();
        }
    }

    public interface IDatabase
    {
        bool IsConnected { get; }

        void Connect();
        User GetUser(string email);
        Order GetOrder(int id);
        void SaveChanges();
    }

    public class Database : IDatabase
    {
        public bool IsConnected
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }

        public interface IOrderProcessor
        {
            void ProcessOrder(string email, int orderId);

        }
        public class OrderProcessor : IOrderProcessor
    {
        private readonly IDatabase _database;

        private readonly IEmailSender _emailSender;

        public OrderProcessor(IDatabase database, IEmailSender emailSender)
        {
            _database = database;
            _emailSender = emailSender;
        }

        public void ProcessOrder(string email, int orderId)
        {
            User user = _database.GetUser(email);
            
            Order order = _database.GetOrder(orderId);


            user.PurchaseOrder(order);
            _database.SaveChanges();
            _emailSender.SendMessage(email, "Order Purchased", "You've purchased an order.");


        }
       
    }

    public class Shop
    {
        public void CompleteOrder()
        {
            IDatabase database = new Database();
            IEmailSender emailSender = new EmailSender();

            IOrderProcessor OrderProcessor = new OrderProcessor(database, emailSender);
        }
    }
}
