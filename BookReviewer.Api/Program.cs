using BookReviewer.Api.Data;
using BookReviewer.Api.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opts =>
{
    opts.UseSqlite(builder.Configuration.GetValue<string>("ConnectionStrings:Sqlite"));
});
builder.Services.AddBookEndpoints()
    .AddAuthorEndpoints();

var app = builder.Build();

app.UseBookEndpoints();
app.UseAuthorEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
