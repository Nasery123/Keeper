namespace FinalProject.Repositories;
public class VaultRepository
{
    private readonly IDbConnection _db;
    public VaultRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Vault createVault(Vault vaultData)
    {
        string sql = @"
        INSERT INTO vaults
        (name, description, img, isPrivate, creatorId)
        VALUES
         (@name, @description, @img, @isPrivate, @creatorId);

         SELECT vaults.*,
         accounts.*
         FROM  vaults
         JOIN accounts ON vaults.creatorId = accounts.id
         WHERE vaults.id = LAST_INSERT_ID()

        ;";

        Vault vault = _db.Query<Vault, Account, Vault>(sql, (vault, creator) =>
        {
            vault.Creator = creator;
            return vault;
        }, vaultData).FirstOrDefault();
        return vault;

    }

    // internal List<Vault> GetMyVault(string creatorId)
    // {
    // }

    internal List<Vault> GetUsersVault(string profileId)
    {
        string sql = @"
        SELECT *
        FROM vaults
        JOIN accounts ON vaults.CreatorId = @profileId

        ;";
        List<Vault> usersVault = _db.Query<Vault, Account, Vault>(sql, (vault, account) =>
        {
            vault.Creator = account;
            return vault;
        }, new { profileId }).ToList();
        return usersVault;

    }

    internal Vault GetVaultById(int vaultId)
    {
        string sql = @"
        SELECT
        vaults.*,
        accounts.*
        FROM vaults
        JOIN accounts ON vaults.creatorId = accounts.id
        WHERE vaults.id = @vaultId


        ;";
        Vault vault = _db.Query<Vault, Account, Vault>(sql, (vault, creator) =>
        {
            vault.Creator = creator;
            return vault;

        }, new { vaultId }).FirstOrDefault();
        return vault;




    }

    internal int RemoveVault(int vaultId)
    {
        string sql = @"
        DELETE FROM vaults WHERE id = @vaultId
        LIMIT 1

        ;";
        int rows = _db.Execute(sql, new { vaultId });
        return rows;
    }

    internal void UpdateVault(Vault original)
    {

        string sql = @"
           UPDATE vaults SET
           name = @name,
           isPrivate = @isPrivate
           WHERE id = @id

           ;";
        _db.Execute(sql, original);

    }
    // internal List<Keep> GetKeepsByVaultId(int vaultId)
    // {
    //     string sql = @"
    //     SELECT * FROM vaultkeep vk
    //     JOIN accounts a ON vk.creatorId = a.id
    //     JOIN vaults v ON vk.vaultId = v.id
    //     WHERE k.vaultId = @vaultId

    //     ;";

    // }
}
