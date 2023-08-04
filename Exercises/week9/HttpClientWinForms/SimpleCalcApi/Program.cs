using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using SimpleCalcApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddDbContext<CalcDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.MapPost("/api/calculation", context =>
{
    // Read and deserialize the incoming JSON request
    var request = context.Request.ReadFromJsonAsync<CalculationRequest>().Result;

    // Perform the calculation based on the operation
    double result = PerformCalculation(request.Num1, request.Num2, request.Operation);

    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<CalcDbContext>();

    // Save the calculation result to the database
    dbContext.CalculationResults.Add(new CalculationResult
    {
        Num1 = request.Num1,
        Num2 = request.Num2,
        Operation = request.Operation,
        Result = result
    });

    dbContext.SaveChanges();

    // Return the calculation result as JSON response
    return context.Response.WriteAsJsonAsync(new { Result = result });
});

app.MapGet("/api/calculation", context =>
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<CalcDbContext>();

    // Retrieve calculation history from the database
    var calculations = dbContext.CalculationResults.ToList();

    // Return the calculation history as JSON response
    return context.Response.WriteAsJsonAsync(calculations);
});

app.Run();

// Define the PerformCalculation function
double PerformCalculation(double num1, double num2, string operation)
{
    switch (operation)
    {
        case "Add":
            return num1 + num2;
        case "Subtract":
            return num1 - num2;
        case "Multiply":
            return num1 * num2;
        case "Divide":
            if (num2 != 0)
            {
                return num1 / num2;
            }
            else
            {
                throw new ArgumentException("Cannot divide by zero.");
            }
        default:
            throw new ArgumentException("Invalid operation.");
    }
}

public class CalculationRequest
{
    public double Num1 { get; set; }
    public double Num2 { get; set; }
    public string Operation { get; set; }
}

public class CalculationResult
{
    public int Id { get; set; }
    public double Num1 { get; set; }
    public double Num2 { get; set; }
    public string Operation { get; set; }
    public double Result { get; set; }
}
