namespace Ds.Base.Domain.Maping.Abstractions;

public interface IMapTo<out TIn>
    where TIn : class
{

    TIn MapTo();
    TIn MapTo(string[]? except);

}