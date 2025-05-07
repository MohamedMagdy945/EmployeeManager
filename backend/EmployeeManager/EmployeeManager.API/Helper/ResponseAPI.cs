
namespace EmployeeManager.API.Helper
{
    public class ResponseAPI 
    {
        public ResponseAPI(int statusCode , string message = null)
        {
            this.StatusCode = statusCode;
            this.Message = message ?? GetMessageFormStatusCode(statusCode);
        }
        private string GetMessageFormStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Success",
                201 => "Created",
                204 => "No Content",
                400 => "Bad Request",
                401 => "Unauthorized",
                403 => "Forbidden",
                404 => "Not Found Resources",
                500 => "Internal Server Error",
                _ => "Unknown Status Code"
            };
        }
        public int StatusCode { get; set; }
        public string? Message { get; set; }

    }
}
