using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Runtime.InteropServices;
using System.Text;

//create connection factory
ConnectionFactory factory = new();
factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
factory.ClientProvidedName = "Rabbit Receiver1 App";

//create connection using factory
IConnection cnn = factory.CreateConnection();


//create a channel withing a connection
IModel channel = cnn.CreateModel();

//define the exchange, routing key and queue names
string exchangeName = "DemoExchange";
string routingKey = "demo-routing-key";
string queueName = "DemoQueue";


//declare the exchange type
channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);

//declare the queue
channel.QueueDeclare(queueName, false, false, false, null);

//bind the queue to the exchange using the routing key
channel.QueueBind(queueName, exchangeName, routingKey, null);

//set the basic qos to the exchange using the routing key
channel.BasicQos(0, 1, false);

//create the consumer that handles the recieved messages
var consumer = new EventingBasicConsumer(channel);

//
consumer.Received += (sender, args) =>
{
    //simulate processing time
    Task.Delay(TimeSpan.FromSeconds(5)).Wait();

    //convert message body to string
    var body = args.Body.ToArray();
    string message = Encoding.UTF8.GetString(body);

    //print recieved message and ack delivery
    Console.WriteLine($"Message Recieved: {message}");
    channel.BasicAck(args.DeliveryTag,  false);
};

//start consuming messages from the queue
string consumerTag = channel.BasicConsume(queueName, false, consumer);

//cancel the consumer and close the channel
Console.ReadLine();
channel.BasicCancel(consumerTag);
channel.Close();
//close conn
cnn.Close();