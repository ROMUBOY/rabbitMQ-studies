using System;
using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory{ HostName = "localhost"};

using var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "myroutingexchange", ExchangeType.Direct);

var message = "this message needs to be routed";

var encodedMessage = Encoding.UTF8.GetBytes(message);

channel.BasicPublish("myroutingexchange", "both", null, encodedMessage);

Console.WriteLine($"Send message: {message}");