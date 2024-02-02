namespace Structure.Domain.Abstractions.Entities
{
    public abstract class DomainEntity<Key>
    {
        public virtual Key Id { get; set; }
    }
}