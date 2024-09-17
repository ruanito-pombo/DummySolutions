namespace Ds.Base.Domain.Maping.Abstractions;

public interface IMap<out TOut, TIn> : IMapFrom<TOut, TIn>, IMapTo<TIn>
    where TOut : class
    where TIn : class
{



}