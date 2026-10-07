using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

using UniversityProject.Services;

namespace UniversityProject.Model;

internal class Items
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
    private string _name = string.Empty; // max 200
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            valueValidator.AssertStringOnLength(value, 200, "Name");
            _name = value;
        }
    }
    private string _info = string.Empty; // max 1000
    public string Info
    {
        get
        {
            return _info;
        }
        set
        {
            valueValidator.AssertStringOnLength(value, 1000, "Info");
            _info = value;
        }
    }
    private double _cost; // 0 - 100_000
    public double Cost
    {
        get
        {
            return _cost;
        }
        set
        {
            valueValidator.AssertDoubleValue(value, 100_000, "Cost");
            _cost = value;
        }
    }
    public Items(string name, string info, double cost)
    {
        _id = generator.GetNextId();
        Name = name;
        Info = info;
        Cost = cost;
    }

    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, Info: {Info}, Cost: {Cost}";
    }

}