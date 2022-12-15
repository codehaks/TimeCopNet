namespace TimeCop.Shared;

public class OperationResult<TResult>
{
    public TResult? Response { get; private set; }

    public bool Success { get; private set; }
    public IList<string>? ErrorMessages { get; private set; }
    public Exception? Exception { get; private set; }
  
    public static OperationResult<TResult> BuildSuccess(TResult result)
    {
        return new OperationResult<TResult> { Success = true, Response = result };

    }

    public static OperationResult<TResult> BuildFailure(IList<string> errorMessage)
    {
        return new OperationResult<TResult> { Success = false, ErrorMessages = errorMessage };
    }

    public static OperationResult<TResult> BuildFailureWithResult(TResult result, IList<string> errorMessage)
    {
        return new OperationResult<TResult> { Success = false, ErrorMessages = errorMessage, Response = result };
    }

    public static OperationResult<TResult> BuildFailure(Exception ex)
    {
        return new OperationResult<TResult> { Success = false, Exception = ex };
    }

    public static OperationResult<TResult> BuildFailure(Exception ex, IList<string> errorMessages)
    {
        return new OperationResult<TResult> { Success = false, Exception = ex, ErrorMessages = errorMessages };
    }

}
