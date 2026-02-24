namespace BookAuthors.Domain.Primitives;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; private set; }

    public bool Equals(Entity? other)
    {
        return other != null && this.Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        return Equals((Entity)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
