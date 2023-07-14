namespace ShopManagementSystem.Common
{
    public class IResult<t>
    {
        public t? Data { get; set; }
        public status ResultStatus { get; set; }
        public string? message { get; set; }
    }
    public enum status
    {
        success,failure
    }
}
