using System.Text.Json;
using Ds.Base.Core.Tuis;
using Ds.Base.Core.Tuis.Abstractions;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Models;
using static Ds.Simple.Application.Constants.DsSimpleConstant;

namespace Ds.Simple.Application.Tuis;

public class UserTui(IUserBusiness userBusiness) : Tui, ITui
{

    private readonly IUserBusiness _userBusiness = userBusiness;

    public override void Execute(string[] args)
    {
        var option = "string.Empty";
        while (!string.IsNullOrEmpty(option) && option != "E")
        {
            Cls();
            Console.WriteLine($"\n\nMain > {args[0]} > User");
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
        Console.WriteLine($"\n\nMain > {args[0]} > User > Create");
        Console.WriteLine("\nPlease input the User data as a json format like below");
        Console.WriteLine("""{ "ProfileId": 1, "PersonId": 1, "UserName": "Some.UserName", "IsActive": true }""");
        Console.WriteLine("*Optional Fields: PersonId\n");
        var rawInput = Console.ReadLine();
        var userData = !string.IsNullOrEmpty(rawInput)
            ? JsonSerializer.Deserialize<User>(rawInput, _jsonDeserializerOptions) : null;
        Console.WriteLine("... Validating input ...");
        if (userData != null && (userData?.ProfileId ?? 0) > 0 && !string.IsNullOrEmpty(userData?.UserName ?? string.Empty))
        {
            Console.WriteLine("... Saving the new user ...");
            _userBusiness.Save(userData!);
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
            Console.WriteLine($"\n\nMain > {args[0]} > User");
            Console.WriteLine("\nPlease select an option below to proceed:");
            Console.WriteLine("    [1]Get User By Id");
            Console.WriteLine("    [2]Filter Users");
            Console.WriteLine("    [3]List Users");
            Console.WriteLine("\n    [E]xit");
            option = (Console.ReadLine()?.Trim().ToUpper() ?? string.Empty)
                is string userInput && userInput.Length > 0
                ? userInput[0..1] : string.Empty;

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
        Console.WriteLine($"\n\nMain > {args[0]} > User > Get");
        Console.WriteLine("Type the User Id");
        if (int.TryParse(Console.ReadLine(), out int userId) && userId > 0)
        {
            var user = _userBusiness.Get(userId);
            Console.WriteLine("Fetching User >>>");
            if (user != null)
            {
                Console.WriteLine($"UserId: {user.Id}  UserName: {user.UserName}  Profile: {user.Profile!.Description}");

                Console.WriteLine("\n\nDone, press any key to exit");
                Console.ReadLine();

                Cls();
                return "E";
            }
        }
            
        Console.WriteLine("\nNo user was found, press any key to exit");
        Console.ReadLine();

        Cls();
        return "E";
    }

    public string ExecuteReadFilter(string[] args)
    {

        Cls();
        Console.WriteLine($"\n\nMain > {args[0]} > User > Filter");
        Console.WriteLine("Type the User Name you wish to filter");
        var userName = Console.ReadLine();
        var results = _userBusiness.Filter(new() { UserName = userName });
        Console.WriteLine("Fetching User List >>>");
        if (results != null && results.Count > 0)
        {
            foreach (var user in results)
            {
                Console.WriteLine($"UserId: {user.Id}  UserName: {user.UserName}  Profile: {user.Profile!.Description}");
            }

            Console.WriteLine("\n\nDone, press any key to exit");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("\nNo user was found, press any key to exit");
            Console.ReadLine();
        }

        Cls();
        return "E";
    }

    public string ExecuteReadList(string[] args)
    {
        
        Cls();
        Console.WriteLine($"\n\nMain > {args[0]} > User > List");
        var results = _userBusiness.List(new());
        Console.WriteLine("Fetching User List >>>");
        if (results != null && (results.Results?.Count ?? 0) > 0)
        {
            foreach (var user in results.Results!)
            {
                Console.WriteLine($"UserId: {user.Id}  UserName: {user.UserName}  Profile: {user.Profile!.Description}");
            }
            
            Console.WriteLine("\n\nDone, press any key to exit");
            Console.ReadLine();
        }

        Cls();
        return "E";
    }

    public string ExecuteUpdate(string[] args)
    {
        Console.WriteLine($"\n\nMain > {args[0]} > User > Update");
        Console.WriteLine("\nType the User Id");
        if (int.TryParse(Console.ReadLine(), out int userId) && userId > 0)
        {
            var user = _userBusiness.Get(userId);
            Console.WriteLine("Fetching User >>>");
            if (user != null)
            {
                Console.WriteLine($"UserId: {user.Id}  UserName: {user.UserName}  Profile: {user.Profile!.Description}");

                Console.WriteLine("\n\nPlease input the User data as a json format like below changing whatever you may need");
                Console.WriteLine("""{ "Id": 3, "ProfileId": 2, "PersonId": 3, "UserName": "Some3.UserName3", "IsActive": true }""");
                Console.WriteLine("*Optional Fields: PersonId\n");
                var rawInput = Console.ReadLine();
                var userData = !string.IsNullOrEmpty(rawInput)
                    ? JsonSerializer.Deserialize<User>(rawInput, _jsonDeserializerOptions) : null;
                Console.WriteLine("... Validating input ...");
                if (userData != null && (userData?.ProfileId ?? 0) > 0 && !string.IsNullOrEmpty(userData?.UserName ?? string.Empty))
                {
                    Console.WriteLine("... Updating the existing user ...");
                    _userBusiness.Save(userData!);
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

        Console.WriteLine("\nNo user was found, press any key to exit");
        Console.ReadLine();

        Cls();
        return "E";
    }

    public string ExecuteDelete(string[] args)
    {
        Console.WriteLine($"\n\nMain > {args[0]} > User > Delete");
        Console.WriteLine("\nType the User Id");
        if (int.TryParse(Console.ReadLine(), out int userId) && userId > 0)
        {
            var user = _userBusiness.Get(userId);
            Console.WriteLine("Fetching User >>>");
            if (user != null)
            {
                Console.WriteLine($"UserId: {user.Id}  UserName: {user.UserName}  Profile: {user.Profile!.Description}");

                Console.WriteLine("\n\nPlease confirm if you really want to delete? [Y]es [N]o");
                var rawInput = Console.ReadLine()?.Trim()?.ToUpper() ?? string.Empty;
                if (rawInput == "Y")
                {
                    _userBusiness.Delete(userId);

                    Console.WriteLine("\nUser successfully removed!");
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

        Console.WriteLine("\nNo user was found, press any key to exit");
        Console.ReadLine();

        Cls();
        return "E";
    }

}