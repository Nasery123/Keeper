namespace FinalProject.Repositories;

public class VaultKeepRepository
{
    private readonly IDbConnection _db;

    public VaultKeepRepository(IDbConnection db)
    {
        _db = db;
    }

    internal VaultKeep CreateVK(VaultKeep vkData)
    {
        string sql = @"
        INSERT INTO
        vaultkeep (creatorId, vaultId, keepId)
        VALUES
        (@creatorId, @vaultId, @keepId);


        SELECT LAST_INSERT_ID()


        ;";
        int lastInsertId = _db.ExecuteScalar<int>(sql, vkData);
        vkData.Id = lastInsertId;
        return vkData;
    }

    // internal List<Keep> GetKeepsByvaultId(int vaultId)
    // {
    //    string sql = @"
    // SELECT vk.*,
    // v.*,
    // k.*
    // FROM
    // vaultkeep vk
    // JOIN vaults v ON vk.vaultId = vaults.id
    // JOIN keep k ON vk.keepId = keep.id
    // WHERE vk.Id = LAST_INSERT_ID()
    //    ;";
    // }
    //  List<Keep> keep = _db.Query<Keep, Account, Keep>(sql, (k, a) =>
    //     {
    //         k.Creator = a;
    //         return k;
    //     }, new { vaultId }).ToList();
    //     return keep;


}
