using System.Text.Json;
using Ds.Base.Console.Tuis;
using Ds.Base.Console.Tuis.Abstractions;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Models;
using static Ds.Simple.Application.Constants.DsSimpleConstant;

namespace Ds.Simple.Application.Tuis;

public class RentalTui(IRentalBusiness rentalBusiness) : Tui, ITui
{

    private readonly IRentalBusiness _rentalBusiness = rentalBusiness;

    public override void Execute(string[] args)
    {
        var option = "string.Empty";
        while (!string.IsNullOrEmpty(option) && option != "E")
        {
            Cls();
            Console.WriteLine($"\n\nMain > {args[0]} > Rental");
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
        Console.WriteLine($"\n\nMain > {args[0]} > Rental > Create");
        Console.WriteLine("\nPlease input the Rental data as a json format like below");
        Console.WriteLine("""{ "UserId": 1, "CustomerId": 1, "CustomerName": "Some CustName" }""");
        Console.WriteLine("*Optional Fields: UserId\n");
        var rawInput = Console.ReadLine();
        var rentalData = !string.IsNullOrEmpty(rawInput)
            ? JsonSerializer.Deserialize<Rental>(rawInput, _jsonDeserializerOptions) : null;
        Console.WriteLine("... Validating input ...");
        if (rentalData != null && (rentalData?.UserId ?? 0) > 0 && (rentalData?.CustomerId ?? 0) > 0)
        {
            Console.WriteLine("... Saving the new rental ...");
            _rentalBusiness.Save(rentalData!);
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
            Console.WriteLine($"\n\nMain > {args[0]} > Rental");
            Console.WriteLine("\nPlease select an option below to proceed:");
            Console.WriteLine("    [1]Get Rental By Id");
            Console.WriteLine("    [2]Filter Rentals");
            Console.WriteLine("    [3]List Rentals");
            Console.WriteLine("\n    [E]xit");
            option = (Console.ReadLine()?.Trim().ToUpper() ?? string.Empty)
                is string rentalInput && rentalInput.Length > 0
                ? rentalInput[0..1] : string.Empty;

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
        Console.WriteLine($"\n\nMain > {args[0]} > Rental > Get");
        Console.WriteLine("Type the Rental Id");
        if (int.TryParse(Console.ReadLine(), out int rentalId) && rentalId > 0)
        {
            var rental = _rentalBusiness.Get(rentalId);
            Console.WriteLine("Fetching Rental >>>");
            if (rental != null)
            {
                Console.WriteLine($"UserId: {rental.Id}  RentalName: {rental.CustomerId}  CustomerName: {rental.Customer?.FullName ?? string.Empty}");

                Console.WriteLine("\n\nDone, press any key to exit");
                Console.ReadLine();

                Cls();
                return "E";
            }
        }

        Console.WriteLine("\nNo rental was found, press any key to exit");
        Console.ReadLine();

        Cls();
        return "E";
    }

    public string ExecuteReadFilter(string[] args)
    {

        Cls();
        Console.WriteLine($"\n\nMain > {args[0]} > Rental > Filter");
        Console.WriteLine("Type the Customer Id you wish to filter");
        var userId = Console.ReadLine();
        var results = _rentalBusiness.Filter(new() { UserId = int.Parse(userId!) });
        Console.WriteLine("Fetching Rental List >>>");
        if (results != null && results.Count > 0)
        {
            foreach (var rental in results)
            {
                Console.WriteLine($"UserId: {rental.UserId}  CustomerId: {rental.CustomerId}  CustomerName: {rental.Customer?.FullName ?? string.Empty}");
            }

            Console.WriteLine("\n\nDone, press any key to exit");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("\nNo rental was found, press any key to exit");
            Console.ReadLine();
        }

        Cls();
        return "E";
    }

    public string ExecuteReadList(string[] args)
    {

        Cls();
        Console.WriteLine($"\n\nMain > {args[0]} > Rental > List");
        var results = _rentalBusiness.List(new());
        Console.WriteLine("Fetching Rental List >>>");
        if (results != null && (results.Results?.Count ?? 0) > 0)
        {
            foreach (var rental in results.Results!)
            {
                Console.WriteLine($"UserId: {rental.UserId}  CustomerId: {rental.CustomerId}  CustomerName: {rental.Customer?.FullName ?? string.Empty}");
            }

            Console.WriteLine("\n\nDone, press any key to exit");
            Console.ReadLine();
        }

        Cls();
        return "E";
    }

    public string ExecuteUpdate(string[] args)
    {
        Console.WriteLine($"\n\nMain > {args[0]} > Rental > Update");
        Console.WriteLine("\nType the Rental Id");
        if (int.TryParse(Console.ReadLine(), out int rentalId) && rentalId > 0)
        {
            var rental = _rentalBusiness.Get(rentalId);
            Console.WriteLine("Fetching Rental >>>");
            if (rental != null)
            {
                Console.WriteLine($"UserId: {rental.UserId}  CustomerId: {rental.CustomerId}  CustomerName: {rental.Customer?.FullName ?? string.Empty}");

                Console.WriteLine("\n\nPlease input the Rental data as a json format like below changing whatever you may need");
                Console.WriteLine("""{ "Id": 3, "ProfileId": 2, "UserId": 3, "RentalName": "Some3 CustomerId3", "IsActive": true }""");
                Console.WriteLine("*Optional Fields: UserId\n");
                var rawInput = Console.ReadLine();
                var rentalData = !string.IsNullOrEmpty(rawInput)
                    ? JsonSerializer.Deserialize<Rental>(rawInput, _jsonDeserializerOptions) : null;
                Console.WriteLine("... Validating input ...");
                if (rentalData != null && (rentalData?.UserId ?? 0) > 0 && !string.IsNullOrEmpty(rentalData?.Customer?.FullName ?? string.Empty))
                {
                    Console.WriteLine("... Updating the existing rental ...");
                    _rentalBusiness.Save(rentalData!);
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

        Console.WriteLine("\nNo rental was found, press any key to exit");
        Console.ReadLine();

        Cls();
        return "E";
    }

    public string ExecuteDelete(string[] args)
    {
        Console.WriteLine($"\n\nMain > {args[0]} > Rental > Delete");
        Console.WriteLine("\nType the Rental Id");
        if (int.TryParse(Console.ReadLine(), out int rentalId) && rentalId > 0)
        {
            var rental = _rentalBusiness.Get(rentalId);
            Console.WriteLine("Fetching Rental >>>");
            if (rental != null)
            {
                Console.WriteLine($"UserId: {rental.UserId}  CustomerId: {rental.CustomerId}  CustomerName: {rental.Customer!.FullName}");

                Console.WriteLine("\n\nPlease confirm if you really want to delete? [Y]es [N]o");
                var rawInput = Console.ReadLine()?.Trim()?.ToUpper() ?? string.Empty;
                if (rawInput == "Y")
                {
                    _rentalBusiness.Delete(rentalId);

                    Console.WriteLine("\nRental successfully removed!");
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

        Console.WriteLine("\nNo rental was found, press any key to exit");
        Console.ReadLine();

        Cls();
        return "E";
    }

}
