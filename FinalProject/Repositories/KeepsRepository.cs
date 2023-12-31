namespace FinalProject.Repositories;


public class KeepsRepository
{
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Keep CreateKeep(Keep keepData)
    {
        string sql = @"
        INSERT INTO
        keep (name, description, img, views, creatorId)
        VALUES
        (@name, @description, @img, @views, @creatorId);

        SELECT * FROM  keep WHERE Id = LAST_INSERT_ID()


        ;";


        Keep keep = _db.Query<Keep>(sql, keepData).FirstOrDefault();

        return keep;


    }

    internal List<Keep> GetAllKeep()
    {
        string sql = @"
        SELECT
        keep.*,
        accounts.*
        FROM keep
        JOIN accounts ON keep.creatorId = accounts.id

        ;";


        List<Keep> keeps = _db.Query<Keep, Account, Keep>(sql, (keep, creator) =>
        {
            keep.Creator = creator;
            return keep;
        }).ToList();
        return keeps;
    }

    internal Keep GetKeepById(int keepId)
    {
        string sql = @"
        SELECT keep.*,
        COUNT(vk.id) As kept,
        accounts.*
        FROM keep
        LEFT JOIN vaultkeep vk ON vk.keepId = keep.id
        JOIN accounts ON keep.creatorId = accounts.id
        WHERE keep.id = @keepId
        GROUP BY keep.id;


        ;";

        Keep keep = _db.Query<Keep, Account, Keep>(sql, (keep, creator) =>
        {
            keep.Creator = creator;
            return keep;
        }, new { keepId }).FirstOrDefault();
        return keep;
    }

    internal List<Keep> GetUsersKeep(string profileId)
    {
        string sql = @"
        SELECT
        keep.*,
        accounts.*
        FROM keep
        JOIN accounts ON keep.CreatorId = @profileId
        WHERE accounts.id= @profileId


        ;";
        List<Keep> keep = _db.Query<Keep, Account, Keep>(sql, (keep, account) =>
        {
            keep.Creator = account;
            return keep;
        }, new { profileId }).ToList();
        return keep;


    }

    internal int RemoveKeep(int keepId)
    {
        string sql = @"
        DELETE FROM keep WHERE id = @keepId LIMIT 1

        ;";
        int rows = _db.Execute(sql, new { keepId });
        return rows;
    }

    internal void UpdateKeep(Keep original)
    {
        string sql = @"
       UPDATE keep  SET
       name = @name,
       description = @description

       WHERE id = @id


       ;";

        _db.Execute(sql, original);
    }

    internal void UpdateView(Keep keep)
    {
        string sql = @"
    UPDATE keep
    SET
    views = @Views
    WHERE id = @Id



    ;";
        _db.Execute(sql, keep);
    }

}
