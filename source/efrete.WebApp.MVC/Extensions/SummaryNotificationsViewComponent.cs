
using efrete.Core.Messages.Common.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace efrete.WebApp.MVC.Extensions
{
    public class SummaryNotificationsViewComponent : ViewComponent
    {
        private readonly DomainNotificationHandler _notifications;

        public SummaryNotificationsViewComponent(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifications = await Task.FromResult(_notifications.GetNotifications());
            notifications.ForEach(c => ViewData.ModelState.AddModelError(c.Key, c.Value));

            return View();
        }
    }
}