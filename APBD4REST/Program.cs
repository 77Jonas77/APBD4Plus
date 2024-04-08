using APBD4REST;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddControllers();

builder.Services.AddSingleton<IMockDb, MockDb>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/animals", (IMockDb mockDb) => Results.Ok(mockDb.GetAll()));

app.MapGet("/animals/{id}", (IMockDb mockDb, int id) =>
{
    var animal = mockDb.GetById(id);
    return animal is null ? Results.NotFound() : Results.Ok(animal);
});

app.MapPost("/animals", (IMockDb mockDb, Animal animal) =>
{
    mockDb.Add(animal);
    return Results.Created($"/animals/{animal.Id}", animal);
});

app.MapPut("/animals/{id}", (IMockDb mockDb, int id, Animal animal) =>
{
    if (mockDb.GetById(id) is null)
        return Results.NotFound();

    mockDb.Edit(animal, id);
    return Results.Ok();
});

app.MapDelete("/animals/{id}", (IMockDb mockDb, int id) =>
{
    if (mockDb.GetById(id) is null)
        return Results.NotFound();

    mockDb.Delete(id);
    return Results.Ok();
});

app.MapGet("/visits", (IMockDb mockDb) => Results.Ok(mockDb.GettAllVisits()));

app.MapPost("/visits", (IMockDb mockDb, Visit visit) =>
{
    mockDb.AddVisit(visit);
    return Results.Created();
});

// app.MapControllers();
app.Run();