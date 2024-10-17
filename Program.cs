using Aluno2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>(options =>
    options.UseSqlite("Data Source=Aluno.db"));

var app = builder.Build();


List<Funcionario> funcionarios = new List<Funcionario>
{
    new Funcionario { FuncionarioId = 10, FuncionarioNome = "Pedro Henrique", FuncionarioCPF = "123.456.789-09" },
    new Funcionario { FuncionarioId = 8, FuncionarioNome = "Pedro Henrique", FuncionarioCPF = "123.456.789-09" },
    new Funcionario { FuncionarioId = 1, FuncionarioNome = "Pedro Henrique", FuncionarioCPF = "123.456.789-09" },
    new Funcionario { FuncionarioId = 3, FuncionarioNome = "Pedro Henrique", FuncionarioCPF = "123.456.789-09" },
    new Funcionario { FuncionarioId = 5, FuncionarioNome = "Pedro Henrique", FuncionarioCPF = "123.456.789-09" },
};

List<Folha> folhas = new List<Folha>
{
    new Folha { FolhaId = 10, Valor = 42, Quantidade = 20, Mes = 1, Ano = 2024, SalarioBruto = 3000, ImpostoIrrf = 375, ImpostoInss = 150, ImpostoFgts = 240, SalarioLiquido = 2475, FuncionarioFolha = BuscarPorId(10) },
    new Folha { FolhaId = 8, Valor = 42, Quantidade = 20, Mes = 1, Ano = 2024, SalarioBruto = 3000, ImpostoIrrf = 375, ImpostoInss = 150, ImpostoFgts = 240, SalarioLiquido = 2475, FuncionarioFolha = BuscarPorId(8) },
    new Folha { FolhaId = 1, Valor = 42, Quantidade = 20, Mes = 1, Ano = 2024, SalarioBruto = 3000, ImpostoIrrf = 375, ImpostoInss = 150, ImpostoFgts = 240, SalarioLiquido = 2475, FuncionarioFolha = BuscarPorId(1) },
    new Folha { FolhaId = 3, Valor = 42, Quantidade = 20, Mes = 1, Ano = 2024, SalarioBruto = 3000, ImpostoIrrf = 375, ImpostoInss = 150, ImpostoFgts = 240, SalarioLiquido = 2475, FuncionarioFolha = BuscarPorId(3) },
    new Folha { FolhaId = 5, Valor = 42, Quantidade = 20, Mes = 1, Ano = 2024, SalarioBruto = 3000, ImpostoIrrf = 375, ImpostoInss = 150, ImpostoFgts = 240, SalarioLiquido = 2475, FuncionarioFolha = BuscarPorId(5) },
};

Funcionario? BuscarPorId(int Id)
{
    return funcionarios.FirstOrDefault(x => x.FuncionarioId == Id);
}

// Cadastrar Funcionarios
app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario funcionario, [FromServices] AppDataContext ctx) =>
{
    ctx.funcionarios.Add(funcionario);
    ctx.SaveChanges();
    return Results.Created("", funcionario);
});

// Listar Funcionarios
app.MapGet("/api/funcionario/listar", ([FromServices] AppDataContext ctx) =>
{
    var allFuncionarios = ctx.funcionarios.ToList();
    if (allFuncionarios.Count > 0)
    {
        return Results.Ok(allFuncionarios);
    }
    return Results.NotFound();
});

// Cadastrar folha
app.MapPost("/api/folha/cadastrar", ([FromBody] Folha folha, [FromServices] AppDataContext ctx) =>
{
    ctx.folhas.Add(folha);
    ctx.SaveChanges();
    return Results.Created("", folha);
});

// Listar folha
app.MapGet("/api/folha/listar", ([FromServices] AppDataContext ctx) =>
{
    var allFolhas = ctx.folhas.ToList();
    if (allFolhas.Count > 0)
    {
        return Results.Ok(allFolhas);
    }
    return Results.NotFound();
});

// Buscar folha
app.MapGet("/api/folha/buscar/{id:int}", ([FromRoute] int id, [FromServices] AppDataContext ctx) =>
{
    Folha? folha = ctx.folhas.Find(id);
    if (folha == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(folha);
});

app.Run();
