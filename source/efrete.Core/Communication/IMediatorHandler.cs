using efrete.Core.Messages.Common.Notifications;

namespace efrete.Core.Communication
{
    public interface IMediatorHandler
    {
        Task PublishNotificationAsync<T>(T notification) where T : DomainNotification;
    }
}