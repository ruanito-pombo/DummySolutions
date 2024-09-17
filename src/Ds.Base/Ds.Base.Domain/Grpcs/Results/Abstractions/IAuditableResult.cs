﻿namespace Ds.Base.Domain.Grpcs.Results.Abstractions;

public interface IAuditableResult<TId> : IResult
    where TId : struct
{

    TId Id { get; set; }
    DateTimeOffset CreateDate { get; set; }
    DateTimeOffset UpdateDate { get; set; }

}
