using BLL.Errors;

namespace BLL.Features
{
    public class ServiceResult<TResult>
    {
        public ServiceResult()
        {
        }

        private ServiceResult(bool isSuccess, TResult? value, BaseError? error)
        {
            IsSuccess = isSuccess;
            Value = value;
            Error = error;
        }

        public BaseError? Error { get; }
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public TResult? Value { get; }

        public static ServiceResult<TResult> Failure(BaseError error) => new(false, default, error);
        public static ServiceResult<TResult> Failure(BaseError error, TResult value) => new(false, value, error);
        public static ServiceResult<TResult> Success(TResult value) => new(true, value, null);

        public static implicit operator ServiceResult<TResult>(TResult? value) => new(true, value, null);
        public static implicit operator ServiceResult<TResult>(BaseError? error) => new(false, default, error);
    }
}
