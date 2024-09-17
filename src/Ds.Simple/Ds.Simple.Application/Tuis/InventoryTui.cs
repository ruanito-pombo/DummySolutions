using System.Text.Json;
using Ds.Base.Core.Tuis;
using Ds.Base.Core.Tuis.Abstractions;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Models;
using static Ds.Simple.Application.Constants.DsSimpleConstant;

namespace Ds.Simple.Application.Tuis;

public class InventoryTui(IInventoryBusiness inventoryBusiness) : Tui, ITui
{

    private readonly IInventoryBusiness _inventoryBusiness = inventoryBusiness;

    public override void Execute(string[] args)
    {
        var option = "string.Empty";
        while (!string.IsNullOrEmpty(option) && option != "E")
        {
            Cls();
            Console.WriteLine($"\n\nMain > {args[0]} > Inventory");
            Console.WriteLine("\nPlease select an option below to proceed:");

            option = args[0] switch
            {
                "Create" => ExecuteCreate(args),
                "Read" => ExecuteRead(args),
                "Update" => ExecuteUpdate(args),
                "Delete" => ExecuteDelete(args),
                _ => string.Empty,
            };
        }
    }

    public string ExecuteCreate(string[] args)
    {
        Console.WriteLine($"\n\nMain > {args[0]} > Inventory > Create");
        Console.WriteLine("\nPlease input the Inventory data as a json format like below");
        Console.WriteLine("""{ "TitleId": 1, "SupplierId": 1, "AcquisitionDate": "2000-01-01" }""");
        Console.WriteLine("*Optional Fields: SellingDate, SellingValue\n");
        var rawInput = Console.ReadLine();
        var inventoryData = !string.IsNullOrEmpty(rawInput)
            ? JsonSerializer.Deserialize<Inventory>(rawInput, _jsonDeserializerOptions) : null;
        Console.WriteLine("... Validating input ...");
        if (inventoryData != null && (inventoryData?.TitleId ?? 0) > 0 && (inventoryData?.SupplierId ?? 0) > 0)
        {
            Console.WriteLine("... Saving the new inventory ...");
            _inventoryBusiness.Save(inventoryData!);
            Console.WriteLine("Success, press any key to continue");
            Console.ReadLine();
            Cls();

            return "E";
        }
        else
        {
            Cls();
            return FailedValidation() ? "Y" : "E";
        }
    }

    public string ExecuteRead(string[] args)
    {
        var option = "string.Empty";
        while (!string.IsNullOrEmpty(option) && option != "E")
        {
            Cls();
            Console.WriteLine($"\n\nMain > {args[0]} > Inventory");
            Console.WriteLine("\nPlease select an option below to proceed:");
            Console.WriteLine("    [1]Get Inventory By Id");
            Console.WriteLine("    [2]Filter Inventory");
            Console.WriteLine("    [3]List Inventory");
            Console.WriteLine("\n    [E]xit");
            option = (Console.ReadLine()?.Trim().ToUpper() ?? string.Empty)
                is string inventoryInput && inventoryInput.Length > 0
                ? inventoryInput[0..1] : string.Empty;

            option = option switch
            {
                "1" => ExecuteReadGet(args),
                "2" => ExecuteReadFilter(args),
                "3" => ExecuteReadList(args),
                _ => string.Empty,
            };
        }

        Cls();
        return "E";
    }

    public string ExecuteReadGet(string[] args)
    {

        Cls();
        Console.WriteLine($"\n\nMain > {args[0]} > Inventory > Get");
        Console.WriteLine("Type the Inventory Id");
        if (int.TryParse(Console.ReadLine(), out int inventoryId) && inventoryId > 0)
        {
            var inventory = _inventoryBusiness.Get(inventoryId);
            Console.WriteLine("Fetching Inventory >>>");
            if (inventory != null)
            {
                Console.WriteLine($"InventoryId: {inventory.Id}  TitleId: {inventory.TitleId}  SupplierId: {inventory.SupplierId}");

                Console.WriteLine("\n\nDone, press any key to exit");
                Console.ReadLine();

                Cls();
                return "E";
            }
        }

        Console.WriteLine("\nNo inventory was found, press any key to exit");
        Console.ReadLine();

        Cls();
        return "E";
    }

    public string ExecuteReadFilter(string[] args)
    {

        Cls();
        Console.WriteLine($"\n\nMain > {args[0]} > Inventory > Filter");
        Console.WriteLine("Type the Inventory AcquisitionDate you wish to filter");
        var inventoryAcquisitionDate = Console.ReadLine();
        var results = _inventoryBusiness.Filter(new() { AcquisitionDate = DateTime.Parse(inventoryAcquisitionDate!) });
        Console.WriteLine("Fetching Inventory List >>>");
        if (results != null && results.Count > 0)
        {
            foreach (var inventory in results)
            {
                Console.WriteLine($"TitleId: {inventory.TitleId}  SupplierId: {inventory.SupplierId}  AcquisitionDate: {inventory.AcquisitionDate}");
            }

            Console.WriteLine("\n\nDone, press any key to exit");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("\nNo inventory was found, press any key to exit");
            Console.ReadLine();
        }

        Cls();
        return "E";
    }

    public string ExecuteReadList(string[] args)
    {

        Cls();
        Console.WriteLine($"\n\nMain > {args[0]} > Inventory > List");
        var results = _inventoryBusiness.List(new());
        Console.WriteLine("Fetching Inventory List >>>");
        if (results != null && (results.Results?.Count ?? 0) > 0)
        {
            foreach (var inventory in results.Results!)
            {
                Console.WriteLine($"TileId: {inventory.TitleId}  SupplierId: {inventory.SupplierId}  UserName: {inventory.AcquisitionDate}");
            }

            Console.WriteLine("\n\nDone, press any key to exit");
            Console.ReadLine();
        }

        Cls();
        return "E";
    }

    public string ExecuteUpdate(string[] args)
    {
        Console.WriteLine($"\n\nMain > {args[0]} > Inventory > Update");
        Console.WriteLine("\nType the Inventory Id");
        if (int.TryParse(Console.ReadLine(), out int inventoryId) && inventoryId > 0)
        {
            var inventory = _inventoryBusiness.Get(inventoryId);
            Console.WriteLine("Fetching Inventory >>>");
            if (inventory != null)
            {
                Console.WriteLine($"TitleId: {inventory.TitleId}  SupplierId: {inventory.SupplierId}  AcquisitionDate: {inventory.AcquisitionDate}");

                Console.WriteLine("\n\nPlease input the Inventory data as a json format like below changing whatever you may need");
                Console.WriteLine("""{ "Id": 3, "TitleId": 2, "SupplierId": 3, "AcquisitionDate": "2001-01-01" }""");
                Console.WriteLine("*Optional Fields: InventoryId\n");
                var rawInput = Console.ReadLine();
                var inventoryData = !string.IsNullOrEmpty(rawInput)
                    ? JsonSerializer.Deserialize<Inventory>(rawInput, _jsonDeserializerOptions) : null;
                Console.WriteLine("... Validating input ...");
                if (inventoryData != null && (inventoryData?.AcquisitionDate ?? DateTime.MinValue) > DateTime.MinValue)
                {
                    Console.WriteLine("... Updating the existing inventory ...");
                    _inventoryBusiness.Save(inventoryData!);
                    Console.WriteLine("Success, press any key to continue");
                    Console.ReadLine();
                    Cls();
                    return "E";
                }
                else
                {
                    Cls();
                    return FailedValidation() ? "Y" : "E";
                }
            }
        }

        Console.WriteLine("\nNo inventory was found, press any key to exit");
        Console.ReadLine();

        Cls();
        return "E";
    }

    public string ExecuteDelete(string[] args)
    {
        Console.WriteLine($"\n\nMain > {args[0]} > Inventory > Delete");
        Console.WriteLine("\nType the Inventory Id");
        if (int.TryParse(Console.ReadLine(), out int inventoryId) && inventoryId > 0)
        {
            var inventory = _inventoryBusiness.Get(inventoryId);
            Console.WriteLine("Fetching Inventory >>>");
            if (inventory != null)
            {
                Console.WriteLine($"TitleId: {inventory.TitleId}  SupplierId: {inventory.SupplierId}  AcquisitionDate: {inventory.AcquisitionDate}");

                Console.WriteLine("\n\nPlease confirm if you really want to delete? [Y]es [N]o");
                var rawInput = Console.ReadLine()?.Trim()?.ToUpper() ?? string.Empty;
                if (rawInput == "Y")
                {
                    _inventoryBusiness.Delete(inventoryId);

                    Console.WriteLine("\nInventory successfully removed!");
                    Console.ReadLine();

                    Cls();
                    return "E";
                }

                Console.WriteLine("\nDeletion aborted");
                Console.ReadLine();

                Cls();
                return "E";
            }
        }

        Console.WriteLine("\nNo inventory was found, press any key to exit");
        Console.ReadLine();

        Cls();
        return "E";
    }

}
