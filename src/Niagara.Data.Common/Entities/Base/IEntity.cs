namespace Niagara.Data.Common.Entities.Base
{
    public interface IEntity<TEntityKeyType>
    {
        TEntityKeyType Id { get; set; }
    }
}