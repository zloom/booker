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
open Microsoft.EntityFrameworkCore
open Microsoft.Extensions.Options

type DataBase = { ConnectionString: string }

[<CLIMutable>]
type Person =
    { PersonId: int
      FirstName: string
      LastName: string
      Address: string
      City: string }

type BookerDataContext(options: IOptions<DataBase>) =
    inherit DbContext()

    [<DefaultValue>]
    val mutable persons: DbSet<Person>

    member this.Persons
        with public get () = this.persons
        and public set p = this.persons <- p

    override _.OnConfiguring(b: DbContextOptionsBuilder) = b.UseNpgsql(options.Value.ConnectionString) |> ignore
