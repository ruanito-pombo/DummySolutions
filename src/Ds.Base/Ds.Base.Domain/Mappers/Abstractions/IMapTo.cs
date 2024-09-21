namespace Ds.Base.Domain.Mappers.Abstractions;

public interface IMapTo<out TIn>
    where TIn : class
{

    TIn MapTo();
    TIn MapTo(string[]? except);

}