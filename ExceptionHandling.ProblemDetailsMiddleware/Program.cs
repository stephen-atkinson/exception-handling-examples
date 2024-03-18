// ReSharper disable UnusedVariable

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(c => c.AddConsole());
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.MapGet("/orders", IResult () => throw new Exception("Failed"));

app.Run();