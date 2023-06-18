var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var hotels = new List<Hotel>();

app.MapGet("/hotels", () => hotels);        // на GET запрос
app.MapGet("/hotels/{id}", (int id) => hotels.FirstOrDefault(h => h.Id == id)); // поиск по id
app.MapPost("/hotels", (Hotel hotel) => hotels.Add(hotel));  // добавление через POST
app.MapPut("/hotels", (Hotel hotel) =>
{
    var index = hotels.FindIndex(h => h.Id == hotel.Id);
    if (index < 0)
    {
        throw new Exception("Not Found");
    }
    hotels[index] = hotel;
});                                       // изменение существующей заметки
app.MapDelete("/hotels/{id}", (int id) =>
{
    var index = hotels.FindIndex(h => h.Id == id);
    if (index < 0 )
    {
        throw new Exception("Not Found");
    }
    hotels.RemoveAt(index);
});                                       // удаление заметки


app.Run();



public class Hotel
{
    public int Id { get; set; }

    public string Name { get; set; } = String.Empty;

    public double Latitude { get; set; }

    public double Longitude { get; set; }
}