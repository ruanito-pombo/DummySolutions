namespace Ds.Base.Domain.Mappers.Abstractions;

public interface IMapFrom<out TOut, in TIn>
    where TOut : class
    where TIn : class
{

    static abstract TOut MapFrom(TIn? input);
    static abstract TOut MapFrom(TIn? input, string[]? include);

}
