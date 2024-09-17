using Ds.Simple.Application.Containers;
using Ds.Simple.Application.Contexts;
using Ds.Simple.Application.Contexts.Abstractions;
using Ds.Simple.Application.Tuis.Abstractions;

var container = new DsSimpleContainer();
container.Register();

var databaseContext = container.GetInstance<IDsSimpleDatabaseContext>();
((DsSimpleDatabaseContext)databaseContext).Database.EnsureCreated();

container.GetInstance<IMainTui>()
    ?.Execute([]);

Console.WriteLine("\nNow that I've wasted enough of your time, press any key to exit and have a nice day!");
Console.ReadLine();