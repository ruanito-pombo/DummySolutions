using Ds.Base.Core.Tuis;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Tuis.Abstractions;
using static Ds.Simple.Application.Constants.DsSimpleConstant;

namespace Ds.Simple.Application.Tuis;

public class MainTui
(
    IInventoryBusiness inventoryBusiness,
    IPaymentBusiness paymentBusiness,
    IPersonBusiness personBusiness,
    IRentalBusiness rentalBusiness,
    ITitleBusiness titleBusiness,
    IUserBusiness userBusiness
) : Tui, IMainTui
{

    private readonly IInventoryBusiness _inventoryBusiness = inventoryBusiness;
    private readonly IPaymentBusiness _paymentBusiness = paymentBusiness;
    private readonly IPersonBusiness _personBusiness = personBusiness;
    private readonly IRentalBusiness _rentalBusiness = rentalBusiness;
    private readonly ITitleBusiness _titleBusiness = titleBusiness;
    private readonly IUserBusiness _userBusiness = userBusiness;

    public override void Execute(string[] args)
    {
        var option = "string.Empty";
        while (!string.IsNullOrEmpty(option) && option != "E")
        {
            Console.WriteLine("\n\nMain");
            Console.WriteLine("\nPlease select an option below to proceed:");
            Console.WriteLine("    [C]reate Data");
            Console.WriteLine("    [R]ead Data");
            Console.WriteLine("    [U]pdate Data");
            Console.WriteLine("    [D]elete Data");
            Console.WriteLine("\n    [E]xit");
            option = (Console.ReadLine()?.Trim().ToUpper() ?? string.Empty)
                is string userInput && userInput.Length > 0
                ? userInput[0..1] : string.Empty;

            switch (option)
            {
                case "C": BuildCrudTui(["Create"]); break;
                case "R": BuildCrudTui(["Read"]); break;
                case "U": BuildCrudTui(["Update"]); break;
                case "D": BuildCrudTui(["Delete"]); break;
            };
        }
    }

    public void BuildCrudTui(string[] args)
    {
        var option = "string.Empty";
        while (!string.IsNullOrEmpty(option) && option != "E")
        {
            Cls();
            Console.WriteLine($"\n\nMain > {args[0]}");
            Console.WriteLine("\nPlease select an option below to proceed:");
            Console.WriteLine("    [1]Inventory Data");
            Console.WriteLine("    [2]Payment Data");
            Console.WriteLine("    [3]Person Data");
            Console.WriteLine("    [4]Rental Data");
            Console.WriteLine("    [5]Title Data");
            Console.WriteLine("    [6]User Data");
            Console.WriteLine("\n    [E]xit");
            option = (Console.ReadLine()?.Trim().ToUpper() ?? string.Empty)
                is string userInput && userInput.Length > 0
                ? userInput[0..1] : string.Empty;

            var tui = option switch
            {
                "1" => new InventoryTui(_inventoryBusiness),
                "2" => new PaymentTui(_paymentBusiness),
                "3" => new PersonTui(_personBusiness),
                "4" => new RentalTui(_rentalBusiness),
                "5" => new TitleTui(_titleBusiness),
                "6" => new UserTui(_userBusiness),
                _ => new Tui(),
            };

            if (tui != null)
            { tui.Execute(args); }
        }
    }

}
