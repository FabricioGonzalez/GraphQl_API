using GraphQl_API.Mutations;
using GraphQl_API.Queries;
using GraphQl_API.Subscriptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services
    .AddGraphQLServer()
    .AddQueryType<BookQuery>()
    .AddMutationType<BookMutations>()
    .AddSubscriptionType<BookSubscription>()
    .AddInMemorySubscriptions();

var app = builder.Build();

/*// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

/*app.UseHttpsRedirection();*/

app.UseRouting();

app.UseWebSockets();

app.MapGraphQL();

/*app.UseAuthorization();

app.MapControllers();*/

app.Run();
