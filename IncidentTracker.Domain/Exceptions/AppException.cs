namespace IncidentTracker.Domain.Exceptions;
public class AppException : Exception {
    public int StatusCode { get; set; }
    private readonly List<int> SupportedStatusCode = [100, 200, 400, 404, 401, 403, 500];
    public AppException(string message, int statusCode = 500) : base(message) {
        if (!SupportedStatusCode.Contains(statusCode)) {
            StatusCode = 500;
        }

        StatusCode = statusCode;
    }
}
