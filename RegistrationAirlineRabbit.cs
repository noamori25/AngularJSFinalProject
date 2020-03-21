using Newtonsoft.Json;
using ProjectManagmentSystem.POCO;
using RabbitMQ.Client;
using System.Text;

namespace ProjectManagmentSystem.BLL
{
   public static class RegistrationAirlineRabbit
    {
        public static void SendToRabbitAirline (AirlineCompany airline)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("Register airline", false, false, false, null);
                byte[] body = Encoding.Default.GetBytes(JsonConvert.SerializeObject(airline));
                channel.BasicPublish("", "Register airline", null, body);
            }

        }
    }
}
