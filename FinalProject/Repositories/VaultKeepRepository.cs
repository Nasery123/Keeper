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

    internal int DeleteVaultKeep(int vaultkeepId)
    {
        string sql = @"
       DELETE FROM vaultkeep WHERE id = @vaultkeepId
       LIMIT 1



       ;";
        int rows = _db.Execute(sql, new { vaultkeepId });
        return rows;
    }

    internal List<KeepsInVault> GetKeepsByVaultId(int vaultId)
    {
        string sql = @"
        SELECT k.*,
        vk.*,
        accounts.*

        FROM keep k
        JOIN vaultkeep vk ON vk.keepId = k.id
        JOIN accounts ON k.creatorId = accounts.id
        WHERE vk.vaultId = @vaultId


        ;";
        List<KeepsInVault> keepInVault = _db.Query<KeepsInVault, VaultKeep, Account, KeepsInVault>(sql, (keepInVault, vaultKeep, acc) =>
            {
                keepInVault.VaultKeepId = vaultKeep.Id;
                keepInVault.VaultId = vaultKeep.VaultId;
                keepInVault.Creator = acc;
                return keepInVault;
            }, new { vaultId }).ToList();
        return keepInVault;
    }

    internal VaultKeep GetVaultKeepById(int vaultkeepId)
    {
        // string sql = @"
        // SELECT
        // vaultkeep.*,
        // accounts.*
        // FROM vaultkeep
        // JOIN accounts ON vaultkeep.creatorId = accounts.id
        // WHERE vaultkeep.id = @vaultkeepId
        // ;";

        // VaultKeep vaultKeep = _db.Query<VaultKeep, Account, VaultKeep>(sql, (vaultKeep, creator) =>
        // {
        //     vaultKeep.Creator = creator;
        //     return vaultKeep;
        // }, new { vaultkeepId }).FirstOrDefault();
        // return vaultKeep;

        throw new NotImplementedException("Unimplemented");
    }
}
