using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection.Emit;
using UniversityProject.Services;

namespace UniversityProject.Model;

internal class Customers
{
    private readonly ValueValidator valueValidator = new ValueValidator();
    private readonly IdGenerator generator = new IdGenerator();
    private readonly int _id;
    public int ID
    {
        get
        {
            return _id;
        }
    }
    private string _fullname = string.Empty;
    public string Fullname
    {
        get
        {
            return _fullname;
        }
        set
        {
            valueValidator.AssertStringOnLength(value, 200, "Fullname");
            _fullname = value;
        }
    }
    private string _address = string.Empty;
    public string Address
    {
        get
        {
            return _address;
        }
        set
        {
            valueValidator.AssertStringOnLength(value, 500, "Address");
            _address = value;
        }
    }

    public Customers(string fullname, string address)
    {
        _id = generator.GetNextId();
        Fullname = fullname;
        Address = address;
    }

    public override string ToString()
    {
        return $"ID: {ID} Fullanme: {Fullname} Address: {Address}";
    }
}