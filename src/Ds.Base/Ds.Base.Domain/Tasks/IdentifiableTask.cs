using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Tasks.Abstractions;

namespace Ds.Base.Domain.Tasks;

public class IdentifiableTask(IBusiness business) : Task(business), IIdentifiableTask
{



}
