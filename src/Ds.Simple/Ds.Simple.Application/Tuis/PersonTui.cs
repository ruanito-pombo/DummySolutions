using System.Text.Json;
using Ds.Base.Core.Tuis;
using Ds.Base.Core.Tuis.Abstractions;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Models;
using static Ds.Simple.Application.Constants.DsSimpleConstant;

namespace Ds.Simple.Application.Tuis;

public class PersonTui(IPersonBusiness personBusiness) : Tui, ITui
{

    private readonly IPersonBusiness _personBusiness = personBusiness;

    public override void Execute(string[] args)
    {
        var option = "string.Empty";
        while (!string.IsNullOrEmpty(option) && option != "E")
        {
            Cls();
            Console.WriteLine($"\n\nMain > {args[0]} > Person");
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
        Console.WriteLine($"\n\nMain > {args[0]} > Person > Create");
        Console.WriteLine("\nPlease input the Person data as a json format like below");
        Console.WriteLine("""{ "UserId": 1, "FullName": "Some FullName", "BirthDate": "2000-01-01" }""");
        Console.WriteLine("*Optional Fields: UserId\n");
        var rawInput = Console.ReadLine();
        var personData = !string.IsNullOrEmpty(rawInput)
            ? JsonSerializer.Deserialize<Person>(rawInput, _jsonDeserializerOptions) : null;
        Console.WriteLine("... Validating input ...");
        if (personData != null && (personData?.UserId ?? 0) > 0 && !string.IsNullOrEmpty(personData?.FullName ?? string.Empty))
        {
            Console.WriteLine("... Saving the new person ...");
            _personBusiness.Save(personData!);
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
            Console.WriteLine($"\n\nMain > {args[0]} > Person");
            Console.WriteLine("\nPlease select an option below to proceed:");
            Console.WriteLine("    [1]Get Person By Id");
            Console.WriteLine("    [2]Filter People");
            Console.WriteLine("    [3]List People");
            Console.WriteLine("\n    [E]xit");
            option = (Console.ReadLine()?.Trim().ToUpper() ?? string.Empty)
                is string personInput && personInput.Length > 0
                ? personInput[0..1] : string.Empty;

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
        Console.WriteLine($"\n\nMain > {args[0]} > Person > Get");
        Console.WriteLine("Type the Person Id");
        if (int.TryParse(Console.ReadLine(), out int personId) && personId > 0)
        {
            var person = _personBusiness.Get(personId);
            Console.WriteLine("Fetching Person >>>");
            if (person != null)
            {
                Console.WriteLine($"PersonId: {person.Id}  PersonName: {person.FullName}  Username: {person.User?.UserName ?? string.Empty}");

                Console.WriteLine("\n\nDone, press any key to exit");
                Console.ReadLine();

                Cls();
                return "E";
            }
        }

        Console.WriteLine("\nNo person was found, press any key to exit");
        Console.ReadLine();

        Cls();
        return "E";
    }

    public string ExecuteReadFilter(string[] args)
    {

        Cls();
        Console.WriteLine($"\n\nMain > {args[0]} > Person > Filter");
        Console.WriteLine("Type the Person Name you wish to filter");
        var personName = Console.ReadLine();
        var results = _personBusiness.Filter(new() { FullName = personName });
        Console.WriteLine("Fetching Person List >>>");
        if (results != null && results.Count > 0)
        {
            foreach (var person in results)
            {
                Console.WriteLine($"UserId: {person.UserId}  FullName: {person.FullName}  UserName: {person.User?.UserName ?? string.Empty}");
            }

            Console.WriteLine("\n\nDone, press any key to exit");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("\nNo person was found, press any key to exit");
            Console.ReadLine();
        }

        Cls();
        return "E";
    }

    public string ExecuteReadList(string[] args)
    {

        Cls();
        Console.WriteLine($"\n\nMain > {args[0]} > Person > List");
        var results = _personBusiness.List(new());
        Console.WriteLine("Fetching Person List >>>");
        if (results != null && (results.Results?.Count ?? 0) > 0)
        {
            foreach (var person in results.Results!)
            {
                Console.WriteLine($"UserId: {person.UserId}  FullName: {person.FullName}  UserName: {person.User?.UserName ?? string.Empty}");
            }

            Console.WriteLine("\n\nDone, press any key to exit");
            Console.ReadLine();
        }

        Cls();
        return "E";
    }

    public string ExecuteUpdate(string[] args)
    {
        Console.WriteLine($"\n\nMain > {args[0]} > Person > Update");
        Console.WriteLine("\nType the Person Id");
        if (int.TryParse(Console.ReadLine(), out int personId) && personId > 0)
        {
            var person = _personBusiness.Get(personId);
            Console.WriteLine("Fetching Person >>>");
            if (person != null)
            {
                Console.WriteLine($"UserId: {person.UserId}  FullName: {person.FullName}  UserName: {person.User?.UserName ?? string.Empty}");

                Console.WriteLine("\n\nPlease input the Person data as a json format like below changing whatever you may need");
                Console.WriteLine("""{ "Id": 3, "ProfileId": 2, "PersonId": 3, "PersonName": "Some3 FullName3", "IsActive": true }""");
                Console.WriteLine("*Optional Fields: PersonId\n");
                var rawInput = Console.ReadLine();
                var personData = !string.IsNullOrEmpty(rawInput)
                    ? JsonSerializer.Deserialize<Person>(rawInput, _jsonDeserializerOptions) : null;
                Console.WriteLine("... Validating input ...");
                if (personData != null && (personData?.UserId ?? 0) > 0 && !string.IsNullOrEmpty(personData?.FullName ?? string.Empty))
                {
                    Console.WriteLine("... Updating the existing person ...");
                    _personBusiness.Save(personData!);
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

        Console.WriteLine("\nNo person was found, press any key to exit");
        Console.ReadLine();

        Cls();
        return "E";
    }

    public string ExecuteDelete(string[] args)
    {
        Console.WriteLine($"\n\nMain > {args[0]} > Person > Delete");
        Console.WriteLine("\nType the Person Id");
        if (int.TryParse(Console.ReadLine(), out int personId) && personId > 0)
        {
            var person = _personBusiness.Get(personId);
            Console.WriteLine("Fetching Person >>>");
            if (person != null)
            {
                Console.WriteLine($"UserId: {person.UserId}  FullName: {person.FullName}  UserName: {person.User!.UserName}");

                Console.WriteLine("\n\nPlease confirm if you really want to delete? [Y]es [N]o");
                var rawInput = Console.ReadLine()?.Trim()?.ToUpper() ?? string.Empty;
                if (rawInput == "Y")
                {
                    _personBusiness.Delete(personId);

                    Console.WriteLine("\nPerson successfully removed!");
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

        Console.WriteLine("\nNo person was found, press any key to exit");
        Console.ReadLine();

        Cls();
        return "E";
    }

}
