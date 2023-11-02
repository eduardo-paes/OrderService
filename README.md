# Order Service

This repository demonstrates the use of MassTransit and RabbitMQ to build a Producer-Consumer routine for receiving and processing booking tickets. The project is divided into two main components:

1. **OrderConsumer**: This component acts as the consumer, responsible for processing incoming booking tickets.

2. **OrderProducer**: This component serves as the producer, responsible for sending booking tickets to be processed.

The project consists of two main components, `OrderConsumer` and `OrderProducer`, each containing its respective C# project files, source code, and configuration files.

## Getting Started

To run the Order Service project, follow these steps:

1. Clone the repository to your local machine.
2. Ensure you have Docker installed.
3. Start RabbitMQ by running the provided Docker command.
4. Build and run the `OrderConsumer` and `OrderProducer` components.
5. Send booking tickets through the `OrderProducer`.

## Dependencies

- [MassTransit](https://masstransit-project.com/): A popular library for building message-based applications in .NET.
- [RabbitMQ](https://www.rabbitmq.com/): A message broker that enables communication between applications.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

Feel free to explore the code and use it as a reference for your own MassTransit and RabbitMQ projects. If you have any questions or need further assistance, please don't hesitate to reach out.
