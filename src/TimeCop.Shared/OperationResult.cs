namespace TimeCop.Shared;

public class OperationResult<TResult>
{
    public TResult? Response { get; private set; }

    public bool Success { get; private set; }
    public string? ErrorMessage { get; private set; }
    public Exception? Exception { get; private set; }

    public static OperationResult<TResult> BuildSuccess(TResult result)
    {
        return new OperationResult<TResult> { Success = true, Response = result };

    }

    public static OperationResult<TResult> BuildFailure(string errorMessage)
    {
        return new OperationResult<TResult> { Success = false, ErrorMessage = errorMessage };
    }

    public static OperationResult<TResult> BuildFailureWithResult(TResult result, string errorMessage)
    {
        return new OperationResult<TResult> { Success = false, ErrorMessage = errorMessage, Response = result };
    }

    public static OperationResult<TResult> BuildFailure(Exception ex)
    {
        return new OperationResult<TResult> { Success = false, Exception = ex };
    }

    public static OperationResult<TResult> BuildFailure(Exception ex, string errorMessage)
    {
        return new OperationResult<TResult> { Success = false, Exception = ex, ErrorMessage = errorMessage };
    }

}
