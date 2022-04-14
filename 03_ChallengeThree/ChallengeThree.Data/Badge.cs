using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Badge
{
    public Badge() { }

    public Badge(List<string> doors)
    {
        Doors = doors;
    }
    public int ID { get; set; }
    public List<string> Doors { get; set; }
}
