﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class User   
    {
        private ISet<Order> _orders = new HashSet<Order>();
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime UpdateAt { get; private set; }

        public decimal Funds { get; private set; }

        public IEnumerable<Order> Orders { get { return _orders; } }
        

        public User(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);

        }

        public void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email is incorrect");
            }
            if(Email == email)
            {
                return;
            }

            Email = email;
            Update();
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("password is incorrect");
            }
            if (Password == password)
            {
                return;
            }

            Password = password;
            Update();
        }

        public void SetAge(int age)
        {
            if(age < 13)
            {
                throw new Exception("Age must be greater than 13");
            }
            if(Age == age)
            {
                return;
            }
            Age = age;
            Update();
        }

        public void Active(bool isActive)
        {
            if(IsActive)
            {
                return;
            }
            IsActive = true;
            Update();
        }
        public void Deactive(bool isActive)
        {
            if(IsActive == false)
            {
                return;
            }
            IsActive = false;
            Update();
        }

        public void IncreaseFunds(decimal funds)
        {
            if(funds <= 0)
            {
                throw new Exception("Funds must be greater than 0.");
            }

            Funds += funds;
            Update();
        }

        public void PurchaseOrder(Order order)
        {
            if(!IsActive)
            {
                throw new Exception("Only Active users can purchase an order.");
            }
            decimal orderPrice = order.TotalPrice;
            if(Funds - orderPrice < 0)
            {
                throw new Exception("you dont have enough money.");
            }

            order.Purchase();
            Funds -= orderPrice;
            _orders.Add(order);
            Update();


        }
        private void Update()
        {
            UpdateAt = DateTime.UtcNow;
        }
    }
}
