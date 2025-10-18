using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public abstract record class EntityBase : IEntity
{
    //This is Explicit as its implementation is not required.
    public abstract string Name { get; }

    public Guid Id { get; init; } = Guid.NewGuid();
}
