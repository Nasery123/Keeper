namespace FinalProject.Repositories;

public class ProfileRepository
{
    private readonly IDbConnection _db;

    public ProfileRepository(IDbConnection db)
    {
        _db = db;
    }

    internal profile GetProfileById(string profileId)
    {
        string sql = @"
        SELECT * FROM
        accounts
        WHERE accounts.id = @profileId
        ;";
        profile pro = _db.Query<profile>(sql, new { profileId }).FirstOrDefault();
        return pro;
    }
}
