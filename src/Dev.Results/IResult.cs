using System.Collections.Generic;

namespace Dev.Results
{
    public interface IResult
    {
        IEnumerable<string> Errors { get; }
        List<ValidationError> ValidationErrors { get; }
        bool IsSuccess { get; }
    }
}
