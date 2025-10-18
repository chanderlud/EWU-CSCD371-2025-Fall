using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record class Book : EntityBase
{
    private readonly string _Title;
    public override string Name => _Title;
    public Book(string title)
    {
        _Title = title;
    }
}
