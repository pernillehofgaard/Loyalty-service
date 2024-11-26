using System;
using System.Collections.Generic;
using LoyaltyService.Application.GetFamily;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => 
{
    c.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
    {
        Description = "Basic auth added to authorization header",
        Name = "Autorization",
        In = ParameterLocation.Header,
        Scheme = "basic",
        Type = SecuritySchemeType.Http
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Basic" }
            },
            new List<string>()
        }
    });
});

builder.Services.AddCors(options =>  
{  
    options.AddPolicy("AllowFrontend", policy =>  
    {  
        policy.WithOrigins("http://localhost:8100") // Replace with your frontend's origin  
            .AllowAnyHeader()  
            .AllowAnyMethod();  
    });  
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/families/{id}", async ([FromRoute] string id, IMediator mediator)  =>
    {
        var getFamily = new GetFamily
        {
            Id = id
        };
        var response = await mediator.Send(getFamily);
        return Results.Ok(response);
    })
    .WithName("GetFamilyById")
    .WithOpenApi();


app.MapGet("/Rewards/{familyId}", async ([FromRoute] string familyId, IMediator mediator) =>
    {
        var getFamily = new GetFamily
        {
            Id = familyId
        };
        var response = await mediator.Send(getFamily);
        var awards = response.Rewards;
        return Results.Ok(awards);
    })
    .WithName("GetActiveRewardByFamilyId")
    .WithOpenApi();

app.MapGet("/IceCash/{familyId}", async ([FromRoute] string familyId, IMediator mediator) =>
    {
        var getFamily = new GetFamily
        {
            Id = familyId
        };
        var response = await mediator.Send(getFamily);
        var iceCash = response.Rewards.IceCash;
        return Results.Ok(iceCash);
    })
    .WithName("GetIceCash")
    .WithOpenApi();

app.MapGet("/FamilyMembers/{familyId}", async ([FromRoute] string familyId, IMediator mediator) =>
    {
        var getFamily = new GetFamily
        {
            Id = familyId
        };
        var response = await mediator.Send(getFamily);
        var familyMembers = response.Members;
        return Results.Ok(familyMembers);
    })
    .WithName("GetFamilyMembers")
    .WithOpenApi();

app.Run();