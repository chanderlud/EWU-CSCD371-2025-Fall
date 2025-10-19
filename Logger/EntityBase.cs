namespace Logger;

/// <summary>
/// EntityBase implicitly implements IEntity
/// </summary>
public abstract record class EntityBase : IEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public abstract string Name { get; }
}
