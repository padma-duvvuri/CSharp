﻿//File: CustomerManager.cs
//Created by: Padma Priya Duvvuri
//Created on: 10-Nov-2011

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Customer_Registry.Customer_Files
{
    public class CustomerManager
    {
        //private arraylist to store customer details
        private ArrayList customers;
        //autogenerated id values
        private int m_idCounter;

        /// <summary>
        /// default constructor. It creates a new arraylist object.
        /// and it assigns default value of 101 for starters.
        /// </summary>
        public CustomerManager()
        {
            customers = new ArrayList();
            m_idCounter = 100;
        }

        /// <summary>
        /// It counts the number of customers objects that are 
        /// present in the arraylist.
        /// </summary>
        /// <returns>no.of customers present</returns>
        public int Count
        {
            get { return customers.Count; }
        }

        /// <summary>
        /// It creates a new customer id for every customer 
        /// present in the arraylist.
        /// </summary>
        /// <returns>new id for the new customer</returns>
        public int GetNewID
        {
            get { return m_idCounter++; }
        }

        /// <summary>
        /// It stores the new customer details entered by the user, and returns
        /// true if added.
        /// </summary>
        /// <param name="customerIn">Input - customer details</param>
        /// <returns>True when the new customer is added</returns>
        public bool AddCustomer(Customer customerIn)
        {
            customerIn.ID = GetNewID.ToString();
            customers.Add(customerIn);
                return true;
        }

        /// <summary>
        /// validates the index of the array list.
        /// </summary>
        /// <param name="index">selected index</param>
        /// <returns>true if index is less than the arraysize</returns>
        private bool IsValidIndex(int index)
        {
            if (index >= 0 && index < Count)
                return true;
            else
                return false;
        }

        /// <summary>
        /// If the index is valid then it will allow the updation 
        /// of the fields
        /// </summary>
        /// <param name="contactIn">details of selected customer</param>
        /// <param name="index">selected index</param>
        /// <returns>true if value is changed</returns>
        public bool ChangeCustomer(Contact contactIn, int index)
        {
            if(IsValidIndex(index))
            {

            Customer customer = (Customer)customers[index];
            customer.ContactData = contactIn;        
            customers.RemoveAt(index);
            customers.Insert(index, customer);
            return true;
            }
            else
                return false;
        }

        /// <summary>
        /// If index is valid then it will remove that customer 
        /// from the arraylist.
        /// </summary>
        /// <param name="index">index at which customer need to be deleted</param>
        /// <returns></returns>
        public bool RemoveCustomer(int index)
        {
            if (IsValidIndex(index))
            {
                customers.RemoveAt(index);
                return true;
            }
            else
                return false;
        }

       /// <summary>
       /// returns the customer object at the selected 
       /// index of the customers arraylist
       /// </summary>
       /// <param name="index">selected index by the user</param>
       /// <returns>customer object</returns>
        public Customer GetCustomer(int index)
        {
            return (Customer)customers[index];
        }

        // just to test the values
        /*
        /// <summary>
        /// passing test values to check it.
        /// </summary>
        public void TestValues()
        {
            Address a1 = new Address("Stenbergsgränd 19", "37133", "karlskrona", Countries.Sverige);
            Email email = new Email("nrkkalyan@gmail.com");
            Phone phone = new Phone("123455", "234556");

            Contact contact = new Contact("Kalyan", "Nimmagadda", a1, email, phone);

            Customer customer = new Customer(contact);

            customers.Add(customer);

        }
         */
    }
}