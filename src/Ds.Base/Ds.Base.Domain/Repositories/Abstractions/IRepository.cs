namespace Ds.Base.Domain.Repositories.Abstractions;

public interface IRepository
{

    void ClearChangeTracker();
    string TableName { get; }
    int SaveChanges();

}
