using System.Text.Json;
using Ds.Base.Core.Tuis;
using Ds.Base.Core.Tuis.Abstractions;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Models;
using static Ds.Simple.Application.Constants.DsSimpleConstant;

namespace Ds.Simple.Application.Tuis;

public class PaymentTui(IPaymentBusiness paymentBusiness) : Tui, ITui
{

    private readonly IPaymentBusiness _paymentBusiness = paymentBusiness;

    public override void Execute(string[] args)
    {
        var option = "string.Empty";
        while (!string.IsNullOrEmpty(option) && option != "E")
        {
            Cls();
            Console.WriteLine($"\n\nMain > {args[0]} > Payment");
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
        Console.WriteLine($"\n\nMain > {args[0]} > Payment > Create");
        Console.WriteLine("\nPlease input the Payment data as a json format like below");
        Console.WriteLine("""{ "RentalId": 1, "CustomerId": 1, "CustomerName": "Some CustName" }""");
        Console.WriteLine("*Optional Fields: RentalId\n");
        var rawInput = Console.ReadLine();
        var paymentData = !string.IsNullOrEmpty(rawInput)
            ? JsonSerializer.Deserialize<Payment>(rawInput, _jsonDeserializerOptions) : null;
        Console.WriteLine("... Validating input ...");
        if (paymentData != null && (paymentData?.RentalId ?? 0) > 0 && (paymentData?.CustomerId ?? 0) > 0)
        {
            Console.WriteLine("... Saving the new payment ...");
            _paymentBusiness.Save(paymentData!);
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
            Console.WriteLine($"\n\nMain > {args[0]} > Payment");
            Console.WriteLine("\nPlease select an option below to proceed:");
            Console.WriteLine("    [1]Get Payment By Id");
            Console.WriteLine("    [2]Filter Payments");
            Console.WriteLine("    [3]List Payments");
            Console.WriteLine("\n    [E]xit");
            option = (Console.ReadLine()?.Trim().ToUpper() ?? string.Empty)
                is string paymentInput && paymentInput.Length > 0
                ? paymentInput[0..1] : string.Empty;

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
        Console.WriteLine($"\n\nMain > {args[0]} > Payment > Get");
        Console.WriteLine("Type the Payment Id");
        if (int.TryParse(Console.ReadLine(), out int paymentId) && paymentId > 0)
        {
            var payment = _paymentBusiness.Get(paymentId);
            Console.WriteLine("Fetching Payment >>>");
            if (payment != null)
            {
                Console.WriteLine($"PaymentId: {payment.Id}  PaymentName: {payment.CustomerId}  CustomerName: {payment.Customer?.FullName ?? string.Empty}");

                Console.WriteLine("\n\nDone, press any key to exit");
                Console.ReadLine();

                Cls();
                return "E";
            }
        }

        Console.WriteLine("\nNo payment was found, press any key to exit");
        Console.ReadLine();

        Cls();
        return "E";
    }

    public string ExecuteReadFilter(string[] args)
    {

        Cls();
        Console.WriteLine($"\n\nMain > {args[0]} > Payment > Filter");
        Console.WriteLine("Type the Customer Id you wish to filter");
        var customerId = Console.ReadLine();
        var results = _paymentBusiness.Filter(new() { CustomerId = long.Parse(customerId!) });
        Console.WriteLine("Fetching Payment List >>>");
        if (results != null && results.Count > 0)
        {
            foreach (var payment in results)
            {
                Console.WriteLine($"RentalId: {payment.RentalId}  CustomerId: {payment.CustomerId}  CustomerName: {payment.Customer?.FullName ?? string.Empty}");
            }

            Console.WriteLine("\n\nDone, press any key to exit");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("\nNo payment was found, press any key to exit");
            Console.ReadLine();
        }

        Cls();
        return "E";
    }

    public string ExecuteReadList(string[] args)
    {

        Cls();
        Console.WriteLine($"\n\nMain > {args[0]} > Payment > List");
        var results = _paymentBusiness.List(new());
        Console.WriteLine("Fetching Payment List >>>");
        if (results != null && (results.Results?.Count ?? 0) > 0)
        {
            foreach (var payment in results.Results!)
            {
                Console.WriteLine($"RentalId: {payment.RentalId}  CustomerId: {payment.CustomerId}  CustomerName: {payment.Customer?.FullName ?? string.Empty}");
            }

            Console.WriteLine("\n\nDone, press any key to exit");
            Console.ReadLine();
        }

        Cls();
        return "E";
    }

    public string ExecuteUpdate(string[] args)
    {
        Console.WriteLine($"\n\nMain > {args[0]} > Payment > Update");
        Console.WriteLine("\nType the Payment Id");
        if (int.TryParse(Console.ReadLine(), out int paymentId) && paymentId > 0)
        {
            var payment = _paymentBusiness.Get(paymentId);
            Console.WriteLine("Fetching Payment >>>");
            if (payment != null)
            {
                Console.WriteLine($"RentalId: {payment.RentalId}  CustomerId: {payment.CustomerId}  CustomerName: {payment.Customer?.FullName ?? string.Empty}");

                Console.WriteLine("\n\nPlease input the Payment data as a json format like below changing whatever you may need");
                Console.WriteLine("""{ "Id": 3, "ProfileId": 2, "PaymentId": 3, "PaymentName": "Some3 CustomerId3", "IsActive": true }""");
                Console.WriteLine("*Optional Fields: PaymentId\n");
                var rawInput = Console.ReadLine();
                var paymentData = !string.IsNullOrEmpty(rawInput)
                    ? JsonSerializer.Deserialize<Payment>(rawInput, _jsonDeserializerOptions) : null;
                Console.WriteLine("... Validating input ...");
                if (paymentData != null && (paymentData?.RentalId ?? 0) > 0 && !string.IsNullOrEmpty(paymentData?.Customer?.FullName ?? string.Empty))
                {
                    Console.WriteLine("... Updating the existing payment ...");
                    _paymentBusiness.Save(paymentData!);
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

        Console.WriteLine("\nNo payment was found, press any key to exit");
        Console.ReadLine();

        Cls();
        return "E";
    }

    public string ExecuteDelete(string[] args)
    {
        Console.WriteLine($"\n\nMain > {args[0]} > Payment > Delete");
        Console.WriteLine("\nType the Payment Id");
        if (int.TryParse(Console.ReadLine(), out int paymentId) && paymentId > 0)
        {
            var payment = _paymentBusiness.Get(paymentId);
            Console.WriteLine("Fetching Payment >>>");
            if (payment != null)
            {
                Console.WriteLine($"RentalId: {payment.RentalId}  CustomerId: {payment.CustomerId}  CustomerName: {payment.Customer!.FullName}");

                Console.WriteLine("\n\nPlease confirm if you really want to delete? [Y]es [N]o");
                var rawInput = Console.ReadLine()?.Trim()?.ToUpper() ?? string.Empty;
                if (rawInput == "Y")
                {
                    _paymentBusiness.Delete(paymentId);

                    Console.WriteLine("\nPayment successfully removed!");
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

        Console.WriteLine("\nNo payment was found, press any key to exit");
        Console.ReadLine();

        Cls();
        return "E";
    }

}
