using Confluent.Kafka;
using CQRS.Core.Domain;
using CQRS.Core.Handlers;
using CQRS.Core.Infrastructe;
using CQRS.Core.Producer;
using Post.Cmd.Api.Commands;
using Post.Cmd.Domain.Aggregates;
using Post.Cmd.Infrastructure.Config;
using Post.Cmd.Infrastructure.Dispatchers;
using Post.Cmd.Infrastructure.Handlers;
using Post.Cmd.Infrastructure.Producers;
using Post.Cmd.Infrastructure.Repositories;
using Post.Cmd.Infrastructure.Stores;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection(nameof(MongoDbConfig)));
builder.Services.Configure<ProducerConfig>(builder.Configuration.GetSection(nameof(ProducerConfig)));
builder.Services.AddSingleton<IEventStoreRepository, EventStoreRepository>();
builder.Services.AddScoped<IEventProducer, EventProducer>();
builder.Services.AddScoped<IEventStore, EventStore>();
builder.Services.AddScoped<IEventSourcingHandler<PostAggregate>, EventSourcingHandler>();
builder.Services.AddScoped<ICommandHandler, CommandHandler>();

// register command handler methods
// var commandHandler = builder.Services.BuildServiceProvider().GetRequiredService<ICommandHandler>();
// var dispatcher = new CommandDispatcher();
// dispatcher.RegisterHandler<NewPostCommand>(commandHandler.HandleAsync);
// dispatcher.RegisterHandler<EditCommentCommand>(commandHandler.HandleAsync);
// dispatcher.RegisterHandler<LikePostCommand>(commandHandler.HandleAsync);
// dispatcher.RegisterHandler<AddCommentCommand>(commandHandler.HandleAsync);
// dispatcher.RegisterHandler<EditMessageCommand>(commandHandler.HandleAsync);
// dispatcher.RegisterHandler<RemoveCommentCommand>(commandHandler.HandleAsync);
// dispatcher.RegisterHandler<DeletePostCommand>(commandHandler.HandleAsync);
// builder.Services.AddSingleton<ICommandDispatcher>(_ => dispatcher);

// builder.Services.AddSingleton<ICommandDispatcher>(_ =>
// {
//   var commandHandler = _.GetService<ICommandHandler>();
//   var dispatcher = new CommandDispatcher();
//   dispatcher.RegisterHandler<NewPostCommand>(commandHandler.HandleAsync);
//   dispatcher.RegisterHandler<EditCommentCommand>(commandHandler.HandleAsync);
//   dispatcher.RegisterHandler<LikePostCommand>(commandHandler.HandleAsync);
//   dispatcher.RegisterHandler<AddCommentCommand>(commandHandler.HandleAsync);
//   dispatcher.RegisterHandler<EditMessageCommand>(commandHandler.HandleAsync);
//   dispatcher.RegisterHandler<RemoveCommentCommand>(commandHandler.HandleAsync);
//   dispatcher.RegisterHandler<DeletePostCommand>(commandHandler.HandleAsync);

//   return dispatcher;
// });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
