using efrete.Core.Communication;
using efrete.Core.Messages.Common.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace efrete.WebApp.MVC.Controllers
{
    [Route("[controller]")]
    public abstract class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediatorHandler;

        protected BaseController(DomainNotificationHandler notifications, IMediatorHandler mediatorHandler)
        {
            _notifications = notifications;
            _mediatorHandler = mediatorHandler;
        }

        protected bool OperationIsValid()
        {
            return !_notifications.HaveNotifications();
        }

        protected IEnumerable<string> GetErrorMessages()
        {
            return _notifications.GetNotifications().Select(c => c.Value).ToList();
        }

        protected void NotifyError(string code, string message)
        {
            _mediatorHandler.PublishNotificationAsync(new DomainNotification(code, message));
        }
    }
}