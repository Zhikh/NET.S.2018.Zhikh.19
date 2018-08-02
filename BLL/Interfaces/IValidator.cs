namespace BLL.Interface
{
    public interface IValidator<in TInput>
    {
        bool IsValid(TInput value);
    }
}
