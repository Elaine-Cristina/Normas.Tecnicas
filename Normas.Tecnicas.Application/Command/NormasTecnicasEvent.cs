namespace Normas.Tecnicas.Application.Command
{
    using MediatR;
    using Normas.Tecnicas.Application.Domain.NormasTecnicasAggregate;

    public class NormasTecnicasEvent : INotification
    {
        public NormasTecnicas NormasTecnicas { get; set; }
        public string QueueName { get; set; }
        public string ConnectionString { get; set; }

        public NormasTecnicasEvent(NormasTecnicas normasTecnicas, string queueName, string connectionString)
        {
            NormasTecnicas = normasTecnicas;
            QueueName = queueName;
            ConnectionString = connectionString;
        }
    }
}
