using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Controllers.Abstractions;

namespace Ds.Base.Domain.Controllers;

public class Controller(IBusiness business) : IController
{

    protected IBusiness _business = business;

}
