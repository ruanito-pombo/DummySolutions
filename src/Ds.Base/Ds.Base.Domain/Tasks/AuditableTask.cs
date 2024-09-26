using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Tasks.Abstractions;

namespace Ds.Base.Domain.Tasks;

public class AuditableTask(IBusiness business) : Task(business), IAuditableTask
{



}
