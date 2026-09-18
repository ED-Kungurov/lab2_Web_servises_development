var builder = WebApplication.CreateBuilder(args);

// 1. Добавьте поддержку контроллеров
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    // 2. Подключите SwaggerUI и укажите ему эндпоинт от .NET 9
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();

// 3. Свяжите маршруты ваших контроллеров
app.MapControllers();

app.Run();
