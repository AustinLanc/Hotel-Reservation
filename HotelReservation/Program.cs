var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var roomTypes = new[]
{
    "Standard", "Deluxe", "Superior", "Suite", "Family", "King"
};

app.MapGet("/prices", () =>
    {
        var price = Enumerable.Range(1, 5).Select(index =>
                new RoomPrice
                (
                    roomTypes[Random.Shared.Next(0, roomTypes.Length)],
                    Random.Shared.Next(100, 400)
                ))
            .ToArray();
        return price;
    })
    .WithName("GetRoomPrice");

app.Run();


record RoomPrice(String roomType, int price)
{
}