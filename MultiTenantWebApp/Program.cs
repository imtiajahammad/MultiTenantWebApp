﻿using Microsoft.EntityFrameworkCore;
using MultiTenantWebApp.DbContexts;
using MultiTenantWebApp.Implementations;
using MultiTenantWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Multitenancy
builder.Services.AddMultitenancy<Tenants, TenantResolver>();

// Sql Server TenantDb Connection
builder.Services.AddDbContextPool<TenantDbContext>(options => options.
        UseSqlServer(builder.Configuration.GetConnectionString("TenantConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Middleware Setup for Multitenancy
app.UseMultitenancy<Tenants>();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

