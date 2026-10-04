using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityProject.Services;

internal class ValueValidator
{
    public void AssertStringOnLength(string value, int maxLenght, string propertyName)
    {
        if (value.Length <= maxLenght)
        {
            return;
        }
        else
        {
            throw new Exception(
                $"{propertyName} должен быть не более {maxLenght} символов"
            );
        }
    }

    public void AssertDoubleValue(double value, int maxPrice, string propertyName)
    {
        if (value < 0)
        {
            throw new Exception(
                $"{propertyName} не может быть меньше 0"
            );
        }
        else if (maxPrice < value)
        {
            throw new Exception(
                $"{propertyName} не может быть больше {maxPrice}"
            );
        }
    }
}