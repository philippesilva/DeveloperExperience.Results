using System.Collections.Generic;
using System.Linq;

namespace Dev.Results
{
    public class Result<T> : IResult
    {
        public T Data { get; }
        public IEnumerable<string> Errors { get; private init; } = new List<string>();
        public List<ValidationError> ValidationErrors { get; private init; } = new();
        public bool IsSuccess => !(Errors.Any() || ValidationErrors.Any());

        public Result(T data)
        {
            Data = data;
        }

        private Result()
        {
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(value);
        }

        public static Result<T> Invalid(ValidationError validationError)
        {
            return new Result<T>
            {
                ValidationErrors = new List<ValidationError>
                {
                    validationError
                }
            };
        }

        public static Result<T> Invalid(IEnumerable<ValidationError> validationErrors)
        {
            return new Result<T>
            {
                ValidationErrors = validationErrors.ToList()
            };
        }

        public static Result<T> Error(IEnumerable<string> errorMessages)
        {
            return new Result<T>
            {
                Errors = errorMessages
            };
        }

        public static Result<T> Error(params string[] errorMessages)
        {
            return new Result<T> { Errors = errorMessages };
        }
    }
}
