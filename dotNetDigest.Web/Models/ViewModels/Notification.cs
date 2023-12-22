using dotNetDigest.Web.Enums;

namespace dotNetDigest.Web.Models.ViewModels
{
    public class Notification
    {
        public string Message { get; set; }

        public NotificationType Type { get; set; }
    }
}
