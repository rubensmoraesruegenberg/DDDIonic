using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using YouLearn.Api.Security;
using YouLearn.Domain.Interfaces.Repositories;
using YouLearn.Domain.Interfaces.Services;
using YouLearn.Domain.Services;
using YouLearn.Infra.Persistencia.EF;
using YouLearn.Infra.Persistencia.Repositories;
using YouLearn.Infra.Transactions;

namespace YouLearn.Api
{
    public class Startup
    {
        private readonly string ISSUER = "c1f51f42";
        private readonly string AUDIENCE = "c6bbbb645024";


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Toda vez que receber um request, vou obter uma unica instacia do contexto do entity, para persistencia de dados.
            //Adiciona a injeção de dependência
            services.AddScoped<YouLearnContext, YouLearnContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Service ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Injeção de dependencia para serviço
            services.AddScoped<IServiceUsuario, ServiceUsuario>();
            services.AddScoped<IServiceCanal, ServiceCanal>();
            services.AddScoped<IServicePlayList, ServicePlayList>();
            services.AddScoped<IServiceVideo, ServiceVideo>();

            //Repositorio /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // injeçao de dependência para o repositorio
            services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();
            services.AddScoped<IRepositoryCanal, RepositoryCanal>();
            services.AddScoped<IRepositoryPlayList, RepositoryPlayList>();
            services.AddScoped<IRepositoryVideo, RepositoryVideo>();
            //A interface do repositorio está no projeto de Dominino e a classe que implementa está em outro projeto, no projeto de Infra.
            //Legal que aqui poderia se usar outras interfaces para acessar outros repositorios, como ADo, hibernat, sqlserver, oracle


            //Configuração do Token ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // O código abaixo é uma receita pronta ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var signingConfigurations = new SigningConfigurations();
            //AddSingleton -> quer dizer que só vai haver uma unica instacia.
            services.AddSingleton(signingConfigurations);
            var tokenConfigurations = new TokenConfigurations
            {
                Audience = AUDIENCE,
                Issuer = ISSUER,
                Seconds = int.Parse(TimeSpan.FromDays(1).TotalSeconds.ToString()) //Tempo que o token vai espirar, pode colocar horas, minutos, dias o tempo que quiser.

            };

            services.AddSingleton(tokenConfigurations);

            //Informar a api que os services vão ter autentificação.
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(bearerOptions =>
            {
                var paramasValidations = bearerOptions.TokenValidationParameters;
                paramasValidations.IssuerSigningKey = signingConfigurations.SigningCredentials.Key;
                paramasValidations.ValidAudience = tokenConfigurations.Audience;
                paramasValidations.ValidIssuer = tokenConfigurations.Issuer;

                //Valida a assinatura de um token recebido.
                paramasValidations.ValidateIssuerSigningKey = true;

                //Verifica se um token recebido aida é valido.
                paramasValidations.ValidateLifetime = true;

                // Tempo de tolerância para expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramasValidations.ClockSkew = TimeSpan.Zero;
            });

            // Ativa o uso do token como forma de autorizar o acesso 
            // a recursos dest projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            // Para todas as requisições serem necessaria o token, para um endpoint não exigir o token
            // deve colocar o  [AllowAnonymous]
            // Caso remova essa linha, para todas as requisições que precisar de token, deve colocar
            // o atributo [Authorize("Bearer")]
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser().Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });

            // Para todas as requisições serem necessarias serem necessaria o token, para un endpoint não exisgir o token
            // deve colocar o [AllowAnonimous]
            // Caso remova essa lina, para todas as requisições que precisar de token, deve colocar
            // o atributo [Authorize("Bearer")]

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser().Build();
            });

            services.AddCors();

            //Fim da receita pronta///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 
            //services.AddMvc();

            //Aplicando documentação com swagger
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "YouLearn", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            //Coloca para usar a estrutura mvc.
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stolencar - V1");
            });
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
