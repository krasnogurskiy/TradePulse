namespace BLL.Errors
{
    public abstract class BaseError
    {
        protected BaseError(string message)
        {
            Message = message;
        }
        public string Message { get; private set; }
    }
}
