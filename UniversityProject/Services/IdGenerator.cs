using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityProject.Services;

internal class IdGenerator
{
    static int ID = 1;

    public int GetNextId()
    {
        return ID++;
    }
}