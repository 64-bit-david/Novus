using RabbitMQ.Client;
using System.Text;

// Create a connection factory
ConnectionFactory factory = new();
factory.Uri = new Uri("amqp://guest:guest@localhost:5672"); // Connection string to RabbitMQ
factory.ClientProvidedName = "Rabbit Sender App"; // Optional client name for identification

// Create a connection using the factory
IConnection cnn = factory.CreateConnection();

// Create a channel within the connection
IModel channel = cnn.CreateModel();

// Define exchange, routing key, and queue names
string exchangeName = "DemoExchange";
string routingKey = "demo-routing-key";
string queueName = "DemoQueue";

// Declare the exchange (Direct type)
channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);

// Declare the queue
channel.QueueDeclare(queueName, false, false, false, null);

// Bind the queue to the exchange using the routing key
channel.QueueBind(queueName, exchangeName, routingKey, null);

// Loop to send messages
for (int i = 0; i < 60; i++)
{
    Console.WriteLine($"Sending Message {i}");

    // Convert message to byte array
    byte[] messageBodyBytes = Encoding.UTF8.GetBytes($"Hello David #{i}");

    // Publish the message to the exchange with the routing key
    channel.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);

    // Pause for a second before sending the next message
    Thread.Sleep(1000);
}

// Close the channel
channel.Close();

// Close the connection
cnn.Close();
