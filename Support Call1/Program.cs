using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Support_Call1.Domain.DTOs.Calls;
using Support_Call1.Domain.DTOs.Login;
using Support_Call1.Domain.Entities;
using Support_Call1.Infra.Data.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SupportCall",
        Version = "v1",
        Description = "API para sistema de Chamados"
    });

    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"<b>JWT Autorização</b> <br/> 
                      Digite 'Bearer' [espaço] e em seguida seu token na caixa de texto abaixo.
                      <br/> <br/>
                      <b>Exemplo:</b> 'bearer 123456abcdefg...'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    config.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
});


builder.Services.AddDbContext<SupportCallContext>();
builder.Services.AddCors();

builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "startly",
            ValidAudience = "startly",
            IssuerSigningKey = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes(
                  "{b76ecac1-7f05-455b-a51d-0ef0500c8e4c}"))
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseHttpsRedirection();

#region EndPoint Chamados
app.MapGet("calls/listar", (SupportCallContext context) =>
{
    var CallsGet = context.CallsSet.Select(x => new CallsGetByIdDto
    {
        Id = x.Id,
        Description = x.Description,
        ProblemType = x.ProblemType,
        State = x.State
    }).ToList();

    
    return CallsGet.Count == 0 ? Results.NotFound("Nenhum Chamado Encontrado") : Results.Ok(CallsGet);
}).WithTags("Calls");

app.MapPost("calls/adicionar", (SupportCallContext context, CallsPostDto callAdicionar ) =>
{
    var resultado = new CallsPostDtoValidator().Validate(callAdicionar);

    if (!resultado.IsValid)
    {
        return Results.BadRequest(resultado.Errors.Select(e => e.ErrorMessage));
    }

    var call = new Calls
    {
        Id = Guid.NewGuid(),
        Description = callAdicionar.Description,
        ProblemType = callAdicionar.ProblemType,
        State = callAdicionar.State
        };

    context.CallsSet.Add(call);
    context.SaveChanges();
    return Results.Created("Created", "Chamado Adicionado com Sucesso");
}).WithTags("Calls");

app.MapPut("calls/atualizar", (SupportCallContext context, CallsPostDto callAtualizar) =>
    {
     var resultado = new CallsPostDtoValidator().Validate(callAtualizar);

      if (!resultado.IsValid)
          return Results.BadRequest(resultado.Errors.Select(error => error.ErrorMessage));

      var call = context.CallsSet.Find(callAtualizar.Id);
      if (call == null)
          return Results.NotFound($"Nenhum chamado com Id {call} Encontrado");

      call.Description = callAtualizar.Description;
      call.ProblemType = callAtualizar.ProblemType;
      call.State = callAtualizar.State;

      context.CallsSet.Add(call);
      context.SaveChanges();

      return Results.Ok("Chamado adicionado com sucesso");
   }
 ).WithTags("Calls");

app.MapDelete("calls/remover/{id:guid}", (SupportCallContext context, Guid id) =>
    {
        var call = context.CallsSet.Find(id);
        if (call == null)
            return Results.NotFound($"Nenhum chamado com Id {id} Encontrado");

        context.CallsSet.Remove(call);
        context.SaveChanges();

        return Results.Ok($"Chamado com id: {id} Removido com Sucesso");
    }
).WithTags("Calls");
#endregion

#region EndPoint Autenticar
// PRECISA SER ESTRUTURADO
#endregion
app.Run();
