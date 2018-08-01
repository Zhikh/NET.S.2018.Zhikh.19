namespace BLL.Interface
{
    public interface IValidator<TInput, TResult>
    {
        TResult Validate(TInput value);
    }
}
