using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

// Create a connection factory
ConnectionFactory factory = new();
factory.Uri = new Uri("amqp://guest:guest@localhost:5672"); // Connection string to RabbitMQ
factory.ClientProvidedName = "Rabbit Receiver2 App"; // Optional client name for identification

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

// Set basic QoS to process one message at a time
channel.BasicQos(0, 1, false);

// Create a consumer that handles received messages
var consumer = new EventingBasicConsumer(channel);
consumer.Received += (sender, args) =>
{
    // Simulate processing time (3 seconds)
    Task.Delay(TimeSpan.FromSeconds(3)).Wait();

    // Convert message body to string
    var body = args.Body.ToArray();
    string message = Encoding.UTF8.GetString(body);

    // Print received message and acknowledge delivery
    Console.WriteLine($"Message Received: {message}");
    channel.BasicAck(args.DeliveryTag, false);
};

// Start consuming messages from the queue
string consumerTag = channel.BasicConsume(queueName, false, consumer);

// Wait for user input to stop the consumer
Console.ReadLine();

// Cancel the consumer and close the channel
channel.BasicCancel(consumerTag);
channel.Close();

// Close the connection
cnn.Close();
