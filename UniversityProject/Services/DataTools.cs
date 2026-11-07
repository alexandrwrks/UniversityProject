using UniversityProject.Model;
using UniversityProject.Model.Enums;

namespace UniversityProject.Services;

/// <summary>Учебные алгоритмы обработки товаров с внешними критериями без LINQ.</summary>
public static class DataTools
{
    /// <summary>Возвращает новый список ссылок на товары, удовлетворяющие критерию.</summary>
    public static List<Item> Filter(List<Item> items, Func<Item, bool> criterion)
    {
        ArgumentNullException.ThrowIfNull(items);
        ArgumentNullException.ThrowIfNull(criterion);
        var result = new List<Item>();
        foreach (Item item in items)
            if (criterion(item)) result.Add(item);
        return result;
    }

    /// <summary>Учебный критерий: стоимость строго больше 5000.</summary>
    public static bool CostAbove5000(Item item) => item.Cost > 5000;

    /// <summary>Учебный критерий: первая категория перечисления.</summary>
    public static bool IsElectronics(Item item) => item.Category == Category.Electronics;

    /// <summary>Стабильно сортирует копию списка по внешнему критерию «стоит раньше».</summary>
    public static List<Item> Sort(List<Item> items, Func<Item, Item, bool> compare)
    {
        ArgumentNullException.ThrowIfNull(items);
        ArgumentNullException.ThrowIfNull(compare);
        var result = new List<Item>(items);
        // Сортировка вставками сохраняет порядок равных элементов и не меняет Store.
        for (int i = 1; i < result.Count; i++)
        {
            Item item = result[i];
            int j = i - 1;
            while (j >= 0 && compare(item, result[j]))
            {
                result[j + 1] = result[j];
                j--;
            }
            result[j + 1] = item;
        }
        return result;
    }

    /// <summary>Сравнивает названия с учётом текущей культуры без учёта регистра.</summary>
    public static bool NameAscending(Item x, Item y) => StringComparer.CurrentCultureIgnoreCase.Compare(x.Name, y.Name) < 0;

    /// <summary>Сравнивает цены по возрастанию.</summary>
    public static bool CostAscending(Item x, Item y) => x.Cost < y.Cost;

    /// <summary>Сравнивает цены по убыванию.</summary>
    public static bool CostDescending(Item x, Item y) => x.Cost > y.Cost;
}
