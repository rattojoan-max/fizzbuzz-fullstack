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

app.MapGet("/fizzbuzz", (int start, int end) =>
{
    var fizzbuzz =  Enumerable.Range(start, end - start + 1).Select(index =>
        new FizzBuzz
        (
            index,
            index % 3 == 0  && index % 5 == 0 ? "fizzbuzz" : index % 3 == 0 ? "fizz" : index % 5 == 0 ? "buzz" : index.ToString()
        ))
        .ToArray();
    return fizzbuzz;
})
.WithName("GetFizzBuzz");

app.Run();

record FizzBuzz(int Numero, string? Resultado){}
