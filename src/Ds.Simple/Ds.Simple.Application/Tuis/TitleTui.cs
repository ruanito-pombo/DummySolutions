using System.Text.Json;
using Ds.Base.Console.Tuis;
using Ds.Base.Console.Tuis.Abstractions;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Models;
using static Ds.Simple.Application.Constants.DsSimpleConstant;

namespace Ds.Simple.Application.Tuis;

public class TitleTui(ITitleBusiness titleBusiness) : Tui, ITui
{

    private readonly ITitleBusiness _titleBusiness = titleBusiness;

    public override void Execute(string[] args)
    {
        var option = "string.Empty";
        while (!string.IsNullOrEmpty(option) && option != "E")
        {
            Cls();
            Console.WriteLine($"\n\nMain > {args[0]} > Title");
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
        Console.WriteLine($"\n\nMain > {args[0]} > Title > Create");
        Console.WriteLine("\nPlease input the Title data as a json format like below");
        Console.WriteLine("""{ "AuthorId": 1, "FullName": "Some FullName", "ReleaseDate": "2000-01-01" }""");
        Console.WriteLine("*Optional Fields: AuthorId\n");
        var rawInput = Console.ReadLine();
        var titleData = !string.IsNullOrEmpty(rawInput)
            ? JsonSerializer.Deserialize<Title>(rawInput, _jsonDeserializerOptions) : null;
        Console.WriteLine("... Validating input ...");
        if (titleData != null && (titleData?.AuthorId ?? 0) > 0 && !string.IsNullOrEmpty(titleData?.FullName ?? string.Empty))
        {
            Console.WriteLine("... Saving the new title ...");
            _titleBusiness.Save(titleData!);
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
            Console.WriteLine($"\n\nMain > {args[0]} > Title");
            Console.WriteLine("\nPlease select an option below to proceed:");
            Console.WriteLine("    [1]Get Title By Id");
            Console.WriteLine("    [2]Filter Titles");
            Console.WriteLine("    [3]List Titles");
            Console.WriteLine("\n    [E]xit");
            option = (Console.ReadLine()?.Trim().ToUpper() ?? string.Empty)
                is string titleInput && titleInput.Length > 0
                ? titleInput[0..1] : string.Empty;

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
        Console.WriteLine($"\n\nMain > {args[0]} > Title > Get");
        Console.WriteLine("Type the Title Id");
        if (int.TryParse(Console.ReadLine(), out int titleId) && titleId > 0)
        {
            var title = _titleBusiness.Get(titleId);
            Console.WriteLine("Fetching Title >>>");
            if (title != null)
            {
                Console.WriteLine($"TitleId: {title.Id}  TitleName: {title.FullName}  AuthorName: {title.Author?.FullName ?? string.Empty}");

                Console.WriteLine("\n\nDone, press any key to exit");
                Console.ReadLine();

                Cls();
                return "E";
            }
        }

        Console.WriteLine("\nNo title was found, press any key to exit");
        Console.ReadLine();

        Cls();
        return "E";
    }

    public string ExecuteReadFilter(string[] args)
    {

        Cls();
        Console.WriteLine($"\n\nMain > {args[0]} > Title > Filter");
        Console.WriteLine("Type the AuthorName you wish to filter");
        var authorName = Console.ReadLine();
        var results = _titleBusiness.Filter(new() { AuthorName = authorName });
        Console.WriteLine("Fetching Title List >>>");
        if (results != null && results.Count > 0)
        {
            foreach (var title in results)
            {
                Console.WriteLine($"AuthorId: {title.AuthorId}  FullName: {title.FullName}  AuthorName: {title.Author?.FullName ?? string.Empty}");
            }

            Console.WriteLine("\n\nDone, press any key to exit");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("\nNo title was found, press any key to exit");
            Console.ReadLine();
        }

        Cls();
        return "E";
    }

    public string ExecuteReadList(string[] args)
    {

        Cls();
        Console.WriteLine($"\n\nMain > {args[0]} > Title > List");
        var results = _titleBusiness.List(new());
        Console.WriteLine("Fetching Title List >>>");
        if (results != null && (results.Results?.Count ?? 0) > 0)
        {
            foreach (var title in results.Results!)
            {
                Console.WriteLine($"AuthorId: {title.AuthorId}  FullName: {title.FullName}  AuthorName: {title.Author?.FullName ?? string.Empty}");
            }

            Console.WriteLine("\n\nDone, press any key to exit");
            Console.ReadLine();
        }

        Cls();
        return "E";
    }

    public string ExecuteUpdate(string[] args)
    {
        Console.WriteLine($"\n\nMain > {args[0]} > Title > Update");
        Console.WriteLine("\nType the Title Id");
        if (int.TryParse(Console.ReadLine(), out int titleId) && titleId > 0)
        {
            var title = _titleBusiness.Get(titleId);
            Console.WriteLine("Fetching Title >>>");
            if (title != null)
            {
                Console.WriteLine($"AuthorId: {title.AuthorId}  FullName: {title.FullName}  AuthorName: {title.Author?.FullName ?? string.Empty}");

                Console.WriteLine("\n\nPlease input the Title data as a json format like below changing whatever you may need");
                Console.WriteLine("""{ "Id": 3, "ProfileId": 2, "TitleId": 3, "TitleName": "Some3 FullName3", "IsActive": true }""");
                Console.WriteLine("*Optional Fields: TitleId\n");
                var rawInput = Console.ReadLine();
                var titleData = !string.IsNullOrEmpty(rawInput)
                    ? JsonSerializer.Deserialize<Title>(rawInput, _jsonDeserializerOptions) : null;
                Console.WriteLine("... Validating input ...");
                if (titleData != null && (titleData?.AuthorId ?? 0) > 0 && !string.IsNullOrEmpty(titleData?.FullName ?? string.Empty))
                {
                    Console.WriteLine("... Updating the existing title ...");
                    _titleBusiness.Save(titleData!);
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

        Console.WriteLine("\nNo title was found, press any key to exit");
        Console.ReadLine();

        Cls();
        return "E";
    }

    public string ExecuteDelete(string[] args)
    {
        Console.WriteLine($"\n\nMain > {args[0]} > Title > Delete");
        Console.WriteLine("\nType the Title Id");
        if (int.TryParse(Console.ReadLine(), out int titleId) && titleId > 0)
        {
            var title = _titleBusiness.Get(titleId);
            Console.WriteLine("Fetching Title >>>");
            if (title != null)
            {
                Console.WriteLine($"AuthorId: {title.AuthorId}  FullName: {title.FullName}  AuthorName: {title.Author!.FullName}");

                Console.WriteLine("\n\nPlease confirm if you really want to delete? [Y]es [N]o");
                var rawInput = Console.ReadLine()?.Trim()?.ToUpper() ?? string.Empty;
                if (rawInput == "Y")
                {
                    _titleBusiness.Delete(titleId);

                    Console.WriteLine("\nTitle successfully removed!");
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

        Console.WriteLine("\nNo title was found, press any key to exit");
        Console.ReadLine();

        Cls();
        return "E";
    }

}
