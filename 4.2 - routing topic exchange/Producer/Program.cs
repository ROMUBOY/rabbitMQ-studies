using System;
using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory{ HostName = "localhost"};

using var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "mytopicexchange", ExchangeType.Topic);

var userPaymentMessage = "A european user paid something";

var userPaymentenCodedMessage = Encoding.UTF8.GetBytes(userPaymentMessage);

channel.BasicPublish("mytopicexchange", "user.europe.payments", null, userPaymentenCodedMessage);

Console.WriteLine($"Send message: {userPaymentMessage}");

var businessOrderMessage = "A european business ordered something";

var businessOrderCodedMessage = Encoding.UTF8.GetBytes(businessOrderMessage);

channel.BasicPublish("mytopicexchange", "business.europe.order", null, businessOrderCodedMessage);

Console.WriteLine($"Send message: {businessOrderMessage}");