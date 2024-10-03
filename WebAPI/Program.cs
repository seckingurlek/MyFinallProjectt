
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramewok;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Autofac, ninject, CastleWindsor, StructureMap, Light�nject --> IoC Container
            // AOP [LogAspect] tir logla anlam� ta��r
            //IoC a�a��s�              
            //builder.Services.AddSingleton<IProductService, ProductManager>();
            //builder.Services.AddSingleton<IProductDal, EfProductDal>();
            builder.Host.UseServiceProviderFactory(services => new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder => 
                { 
                    builder.RegisterModule(new AutofacBusinessModule()); 
                });
            // .NET Core yerine ba�ka bi ioc i�in yukar�daki hareket yap�l�r.

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
