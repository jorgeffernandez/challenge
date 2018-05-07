namespace Challenge.Domain.Entities
{
    public interface ITransformDto<T>
    {
        T GetDto();
    }
}
