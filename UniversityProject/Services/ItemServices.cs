using System;
using System.Collections.Generic;
using System.Text;
using UniversityProject.Model;

namespace UniversityProject.Services;


internal class ItemServices
{

    private readonly List<Items> _items = new();

    public void AddItem(Items item)
    {
        _items.Add(item);
    }

    public void DeleteItem(Items item)
    {
        _items.Remove(item);
    }

    public Items GetById(int item_id)
    {
        Items? item = _items.FirstOrDefault(v => v.ID == item_id);

        if (item == null)
        {
            throw new Exception("Item not found");
        }

        return item;
    }

    public List<Items> GetAll()
    {
        return new List<Items>(_items);
    }

    public void UpdateItem(Items item)
    {
        Items? existsItem = GetById(item.ID);

        if (existsItem == null)
        {
            throw new Exception("Item not found");
        }

        existsItem.Name = item.Name;
        existsItem.Info = item.Info;
        existsItem.Cost = item.Cost;
    }
}