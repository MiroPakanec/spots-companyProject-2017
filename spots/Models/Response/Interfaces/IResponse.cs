namespace spots.Models.Response.Interfaces
{
    public interface IResponse
    {
        string ResponseText { get; set; }
        bool Success { get; set; }
        void HasFailed(string message);
        string StyleClass { get; }
        string GetResponseDescription();
        void HasSucceeded(string message);
    }
}
