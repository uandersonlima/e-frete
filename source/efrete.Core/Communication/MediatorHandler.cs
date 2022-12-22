using efrete.Core.Messages.Common.Notifications;
using MediatR;

namespace efrete.Core.Communication
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishNotificationAsync<T>(T notification) where T : DomainNotification
        {
            await _mediator.Publish(notification);
        }
    }
}