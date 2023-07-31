using ECommerce.API.ServicesExternal.Messages;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace ECommerce.API.ServicesExternal
{
    public class RabbitMqProducerImp
    {
        private readonly IModel _channel;

        public RabbitMqProducerImp(IModel channel)
        {
            _channel = channel;
            _channel.QueueDeclare("checkoutqueue", false, false, false, null);
        }

        public void SendMessage(CheckoutHeader message, string queue)
        {
            var messageJson = GetMessageAsByteArray(message);
            _channel.BasicPublish("checkoutqueue", queue, null, messageJson);
        }

        private byte[] GetMessageAsByteArray(CheckoutHeader message)
        {
            var json = JsonSerializer.Serialize(message, new JsonSerializerOptions
            {
                WriteIndented = true,
            });

            return Encoding.UTF8.GetBytes(json);
        }
    }
}
