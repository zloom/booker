namespace Api

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

type Startup(configuration: IConfiguration) =
    member _.Configuration = configuration

    member _.ConfigureServices(services: IServiceCollection) =
        services.AddSwaggerGen() |> ignore
        services.AddControllers() |> ignore

    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        app.UseRouting()
           .UseSwagger()
           .UseSwaggerUI()
           .UseAuthorization()
           .UseEndpoints(fun endpoints ->
                 endpoints.MapControllers() |> ignore
             ) |> ignore
