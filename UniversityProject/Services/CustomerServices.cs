using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.Model;

namespace UniversityProject.Services;

internal class CustomerServices
{
    private readonly List<Customers> _customers = new();

    public void AddItem(Customers customer)
    {
        _customers.Add(customer);
    }

    public void DeleteItem(Customers customer)
    {
        _customers.Remove(customer);
    }

    public Customers GetById(int customer_id)
    {
        Customers? customer = _customers.FirstOrDefault(v => v.ID == customer_id);

        if (customer == null)
        {
            throw new Exception("Item not found");
        }

        return customer;
    }

    public List<Customers> GetAll()
    {
        return new List<Customers>(_customers);
    }

    public void UpdateItem(Customers customer)
    {
        Customers? existsItem = GetById(customer.ID);

        if (existsItem == null)
        {
            throw new Exception("Item not found");
        }

        existsItem.Fullname = customer.Fullname;
        existsItem.Address = customer.Address;
    }
}