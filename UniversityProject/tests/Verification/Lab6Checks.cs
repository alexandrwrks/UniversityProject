using UniversityProject.Model;
using UniversityProject.Model.Enums;
using UniversityProject.Model.Orders;
using UniversityProject.Model.Discounts;

internal static partial class Program
{
    private static bool TypedEquals<T>(IEquatable<T> left, T? right) => left.Equals(right);

    private static bool ObjectEquals(object left, object? right) => left.Equals(right);

    private static void VerifyLab6()
    {
        var item = new Item("Товар", "Описание", 10, Category.Food);
        var clone = (Item)((ICloneable)item).Clone();
        Check(!ReferenceEquals(item, clone) && item.Id != clone.Id, "Clone new item identity");
        Check(clone.Name == item.Name && clone.Info == item.Info && clone.Cost == item.Cost && clone.Category == item.Category, "Clone item values");
        clone.Name = "Копия";
        Check(item.Name == "Товар", "Independent item clone");
        Check(item.Equals(item) && item.Equals((object)item) && !item.Equals(clone) && !TypedEquals<Item>(item, null) && !ObjectEquals(item, ""), "Item equality");
        var identityHash = item.GetHashCode();
        item.Name = "Изменён";
        item.Cost = 20;
        Check(identityHash == item.GetHashCode() && new HashSet<Item> { item }.Contains(item), "Stable identity hash");
        Check(item.CompareTo(clone) > 0 && clone.CompareTo(item) < 0 && item.CompareTo(item) == 0 && item.CompareTo(null) > 0, "Item comparison");
        var list = new List<Item> { item, clone };
        list.Sort();
        Check(ReferenceEquals(list[0], clone), "Standard list sort");
        var address = new Address(123456, "Россия", "Томск", "Улица", "1", "2");
        var addressCopy = (Address)((ICloneable)address).Clone();
        Check(!ReferenceEquals(address, addressCopy) && address.Equals(addressCopy) && address.Equals((object)addressCopy), "Address value equality");
        Check(address.GetHashCode() == addressCopy.GetHashCode() && new HashSet<Address> { address }.Contains(addressCopy), "Address hash contract");
        Check(!TypedEquals<Address>(address, null) && !ObjectEquals(address, item), "Address other type and null");
        foreach (Action<Address> change in new Action<Address>[]
        {
            a => a.Index++, a => a.Country += "X", a => a.City += "X", a => a.Street += "X", a => a.Building += "X", a => a.Apartment += "X"
        })
        {
            var copy = (Address)address.Clone();
            change(copy);
            Check(!address.Equals(copy), "Address compares all components");
        }
        Check(address.City == "Томск", "Address copy independence");
        var cart = new Cart { Items = new() { item, item, clone } };
        var cartCopy = (Cart)((ICloneable)cart).Clone();
        Check(!ReferenceEquals(cart.Items, cartCopy.Items) && ReferenceEquals(cart.Items[0], cartCopy.Items[0]) && cartCopy.Items.Count == 3, "Cart aggregation clone");
        cartCopy.Items.RemoveAt(0);
        Check(cart.Items.Count == 3 && cartCopy.Items.Count == 2, "Cart clone independent collection");
        item.Cost = 30;
        Check(cartCopy.Amount == 40, "Cart clone shares aggregated items");
        var order = new Order(address, list);
        var otherOrder = new PriorityOrder(address, list, DateTime.Today, PriorityOrder.DeliveryTimes[0]);
        Check(order.Equals(order) && order.Equals((object)order) && !order.Equals(otherOrder) && !TypedEquals<Order>(order, null) && !ObjectEquals(order, item), "Order equality");
        int hash = order.GetHashCode();
        order.Status = OrderStatus.Delivered;
        Check(order.GetHashCode() == hash, "Stable order hash");
        var p1 = new PointsDiscount();
        var p2 = new PointsDiscount();
        Check(p1.CompareTo(p2) == 0 && p1.CompareTo(null) > 0, "Points equal and null");
        p2.Update(list);
        Check(p1.CompareTo(p2) < 0 && p2.CompareTo(p1) > 0, "Points comparison");
        var d1 = new PercentDiscount(Category.Books);
        var d2 = new PercentDiscount(Category.Food);
        Check(d1.CompareTo(d2) == 0 && d1.CompareTo(null) > 0, "Percent comparison independent of category");
        d2.Update(new() { new("", "", 1000, Category.Food) });
        Check(d1.CompareTo(d2) < 0 && d2.CompareTo(d1) > 0, "Percent comparison");
    }
}
