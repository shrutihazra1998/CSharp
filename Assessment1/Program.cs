using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    public class Customer
    {
        public Customer(int custID, string custname, string custaddress, double custsalary)
        {
            CustomerID = custID;
            Name = custname;
            Address = custaddress;
            Salary = custsalary;
        }

        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
    }
    interface ICustomerManager
    {
        bool AddCustomer(Customer cus);
        bool RemoveCustomer(int id);
        bool UpdateCustomer(int id);
        bool GetCustomer();
    }
    class CustomerManager : ICustomerManager
    {
        HashSet<Customer> customers = new HashSet<Customer>();
        public bool AddCustomer(Customer cus)
        {
            return customers.Add(cus);
        }

        public bool RemoveCustomer(int id)
        {
            foreach (Customer cus in customers)
            {
                if (cus.CustomerID == id)
                {
                    customers.Remove(cus);
                    return true;
                }
            }
            return false;
        }
        public bool UpdateCustomer(int id)
        {
            foreach (Customer cus in customers)
            {
                if (cus.CustomerID == id)
                {
                    Console.Write("Update the Name to: ");
                    string newname = Console.ReadLine();
                    Console.Write("Update the Address to: ");
                    string newaddress = Console.ReadLine();
                    Console.Write("Update the Salary to: ");
                    double newsalary = double.Parse(Console.ReadLine());
                    cus.Name = newname;
                    cus.Address = newaddress;
                    cus.Salary = newsalary;
                    return true;
                }
            }
            return false;
        }
        public bool GetCustomer()
        {
            foreach (var cus in customers)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"ID: {cus.CustomerID}");
                Console.WriteLine($"Name: {cus.Name}");
                Console.WriteLine($"Address: {cus.Address}");
                Console.WriteLine($"Salary: {cus.Salary}");
                Console.WriteLine("-------------------------------");
            }
            return true;
        }
    }

    class CustomerManagerDemo
    {
        static void Main(string[] args)
        {
            Customer cus1 = new Customer(1, "Shruti", "Kolkata", 35000);
            Customer cus2 = new Customer(2, "Rahul", "Goa", 25000);
            Customer cus3 = new Customer(3, "Nupur", "Patna", 65000);
            CustomerManager man = new CustomerManager();
            man.AddCustomer(cus1); //Adding customer's data
            man.AddCustomer(cus2);
            man.AddCustomer(cus3);

            man.GetCustomer(); //Getting all customers
            man.RemoveCustomer(2); //Removing customer by passing id
            man.GetCustomer();
            man.UpdateCustomer(1); //Updating customer 
            man.GetCustomer();

        }

    }
}