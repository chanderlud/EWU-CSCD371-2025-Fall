using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public record class Person : EntityBase
{
    protected FullName _FullName;

    public Person(FullName name)
    {
        ArgumentNullException.ThrowIfNull(name);
        _FullName = name;
    }

    public override string Name => _FullName.ToString();
}
