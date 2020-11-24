namespace Niagara.Data.Common.Entities.Base
{
    public interface IEntity<out TEntityKeyType>
    {
        TEntityKeyType Id { get; }
    }
}