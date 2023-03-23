using API;
using API.Context;
using API.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.MapPost("/products", (ProductRequest productRequest, AppDbContext context) =>
{
    var category = context.Categories.Where(c => c.Id == productRequest.CategoryId).First();
    var product = new Product
    {
        Code = productRequest.Code,
        Name = productRequest.Name,
        Description = productRequest.Description,
        Category = category

    };

    if (productRequest.Tags != null)
    {
        product.Tags = new List<Tag>();
        foreach (var item in productRequest.Tags)
        {
            product.Tags.Add(new Tag { Name = item });
        }
    }
    context.Products.Add(product);
    context.SaveChanges();
    return Results.Created($"/products{product.Id}", product.Id);

});

app.MapGet("/products/{id}", ([FromRoute] int id, AppDbContext db) =>
{
    var product = db.Products
    .Include(c => c.Category)
    .Include(c => c.Tags)
    .Where(p => p.Id == id).FirstOrDefault();


    if (product != null) return Results.Ok(product);
    return Results.NotFound();

});

app.MapPut("/products/{id}", ([FromRoute] int id, ProductRequest product, AppDbContext context) =>
{
    var productSaved = context.Products

    .Include(o => o.Tags)
    .Where(w => w.Id == id).First();

    var category = context.Categories.Where(c => c.Id == product.CategoryId).First();
    productSaved.Code = product.Code;
    productSaved.Name = product.Name;
    productSaved.Description = product.Description;
    productSaved.Category = category;

    if (product.Tags != null)
    {
        productSaved.Tags = new List<Tag>();
        foreach (var item in product.Tags)
        {
            productSaved.Tags.Add(new Tag { Name = item });
        }
    }
    context.SaveChanges();

    return Results.Ok(productSaved);

});

app.MapDelete("/products/{id}", ([FromRoute] int id, AppDbContext context) =>
{
    if (id != null)
    {
        var product = context.Products.Where(p => p.Id == id).FirstOrDefault();
        context.Remove(product);
        context.SaveChanges();
        return Results.Ok();

    }
    return Results.NotFound(id);

});



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


