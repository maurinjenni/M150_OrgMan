namespace OrgMan.Common.DynamicValidationService
{
    public interface IDynamicValidationService<T>
    {
        bool Validate(T obj);
    }
}
