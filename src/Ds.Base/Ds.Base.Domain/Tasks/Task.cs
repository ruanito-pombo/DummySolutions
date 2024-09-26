using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Tasks.Abstractions;

namespace Ds.Base.Domain.Tasks;

public class Task(IBusiness business) : ITask
{

    protected readonly IBusiness _business = business;

}
