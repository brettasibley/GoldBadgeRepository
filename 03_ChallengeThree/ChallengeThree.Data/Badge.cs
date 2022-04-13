using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Badge
{
    public Badge() { }

    public Badge(int id, List<string> door)
    {
        ID = id;
    }
public int ID { get; set; }
public string Door { get; set; }
}
