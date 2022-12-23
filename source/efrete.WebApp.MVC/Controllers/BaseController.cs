using efrete.Core.Communication;
using efrete.Core.Messages.Common.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace efrete.WebApp.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediatorHandler;

        protected BaseController(INotificationHandler<DomainNotification>  notifications, IMediatorHandler mediatorHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
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