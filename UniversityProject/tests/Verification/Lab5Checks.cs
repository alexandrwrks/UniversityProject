using UniversityProject.Model;

internal static partial class Program
{
    private static void VerifyLab5Discounts()
    {
        var goods = new List<Item> { new("Книга", "", 1000, Category.Books), new("Еда", "", 10, Category.Food) };
        var points = new PointsDiscount();
        Check(points.Points == 0 && points.Calculate(goods) == 0, "Initial points");
        points.Update(goods);
        Check(points.Points == 101, "Points round upward");
        Check(points.Calculate(goods) == 101 && points.Points == 101, "Calculate must be pure");
        Check(points.Apply(goods) == 101 && points.Points == 0, "Apply must spend points");
        points.Update(goods);
        var small = new List<Item> { new("Мелочь", "", 9, Category.Food) };
        Check(points.Apply(small) == 2 && points.Points == 99, "Whole points cannot exceed 30 percent");
        points.Update(small);
        Check(points.Points == 100, "Fractional earnings round up");
        var percent = new PercentDiscount(Category.Books);
        Check(percent.Percent == 1 && percent.Calculate(goods) == 10, "Initial category percentage");
        percent.Update(small);
        Check(percent.Percent == 1 && percent.Apply(small) == 0, "Other category ignored");
        percent.Update(goods);
        Check(percent.Percent == 2 && percent.Calculate(goods) == 20, "Thousand threshold");
        for (int i = 0; i < 20; i++) percent.Update(goods);
        Check(percent.Percent == 10 && percent.Apply(goods) == 100, "Maximum percentage");
        Check(points.Calculate(new()) == 0 && percent.Calculate(new()) == 0, "Empty discounts");
        Reject(() => points.Calculate(null!));
        Reject(() => percent.Update(null!));
        Reject(() => new PercentDiscount((Category)99));
    }
}
