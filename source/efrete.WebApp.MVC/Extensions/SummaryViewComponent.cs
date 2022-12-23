
using efrete.Core.Messages.Common.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace efrete.WebApp.MVC.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly DomainNotificationHandler _notifications;

        public SummaryViewComponent(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifications = await Task.FromResult(_notifications.GetNotifications());
            notifications.ForEach(c => ViewData.ModelState.AddModelError("", c.Value));
                

            return View("Default");
        }
    }
}