using Ds.Base.Core.Contexts.Abstractions;
using Ds.Simple.Application.Containers;
using Ds.Simple.Application.Contexts;
using Ds.Simple.Application.Tuis.Abstractions;

var container = new SimpleContainer();
container.Register();

var databaseContext = container.GetInstance<IDatabaseContext>();
((SimpleDatabaseContext)databaseContext).Database.EnsureCreated();

container.GetInstance<IMainTui>()
    ?.Execute([]);

Console.WriteLine("\nNow that I've wasted enough of your time, press any key to exit and have a nice day!");
Console.ReadLine();