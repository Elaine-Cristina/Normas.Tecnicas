namespace Normas.Tecnicas.Application.Command
{
    using Azure.Messaging.ServiceBus;
    using MediatR;
    using System.Text;
    using System.Text.Json;
    using System.Threading;
    using System.Threading.Tasks;

    public class NormasTecnicasEventHandler : INotificationHandler<NormasTecnicasEvent>
    {
        public async Task Handle(NormasTecnicasEvent notification, CancellationToken cancellationToken)
        {
            await using (ServiceBusClient client = new ServiceBusClient(notification.ConnectionString))
            {
                ServiceBusSender sender = client.CreateSender(notification.QueueName);
                
                string messageBody = JsonSerializer.Serialize(notification.NormasTecnicas);
                ServiceBusMessage message = new ServiceBusMessage(Encoding.UTF8.GetBytes(messageBody));

                await sender.SendMessageAsync(message);
            }
        }
    }
}
