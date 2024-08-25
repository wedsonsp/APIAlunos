using Desafio.Context;
using Desafio.Repositories.Interface;
using Desafio.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura��es de servi�os
builder.Services.AddDbContext<AlunoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoSqlServerAlunos"));
});

builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
      .AddCookie(options =>
      {
          options.LoginPath = "/Autenticacao/Login";
          options.LogoutPath = "/Autenticacao/Logout";
      });
builder.Services.AddControllers(); // Removido AddControllersWithViews e AddMvc
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Configura��o do Swagger para documenta��o da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��es do pipeline de execu��o
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=}/{action=}/{id?}");

    endpoints.MapControllers();
});

app.Run();
