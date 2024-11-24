namespace DataAccounting.Domain.Abstractions;

public abstract class Entity<T> : IEntity<T>
{
    public T Id { get; set; }
}

public abstract class Entity : IEntity
{
}