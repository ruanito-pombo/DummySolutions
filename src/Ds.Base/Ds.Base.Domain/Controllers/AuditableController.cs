using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Controllers.Abstractions;

namespace Ds.Base.Domain.Controllers;

public class AuditableController(IBusiness business) : Controller(business), IAuditableController
{



}
