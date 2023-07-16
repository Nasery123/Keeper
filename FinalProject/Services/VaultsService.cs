namespace FinalProject.Services;

public class VaultsService
{
    private readonly VaultRepository _repo;
    public VaultsService(VaultRepository repo)
    {
        _repo = repo;
    }

    internal Vault CreateVault(Vault vaultData)
    {
        Vault vault = _repo.createVault(vaultData);
        return vault;
    }

    // internal List<Keep> GetkeepsByVaultId(int vaultId)
    // {
    //     return _repo.GetKeepsByVaultId(vaultId);
    // }

    internal Vault GetVaultById(int vaultId)
    {
        Vault vault = _repo.GetVaultById(vaultId);
        return vault;
    }

    internal string RemoveVault(int vaultId)
    {
        Vault vault = GetVaultById(vaultId);
        int rows = _repo.RemoveVault(vaultId);
        if (rows > 1) throw new Exception("make sure not to delet more than one row");
        return "you successfully deleted that vault";
    }

    internal Vault UpdateVault(Vault updateData)
    {
        Vault original = GetVaultById(updateData.Id);
        if (original == null) throw new Exception("there is nothing in that id");
        original.Name = updateData.Name != null ? updateData.Name : original.Name;
        original.IsPrivate = updateData.IsPrivate != null ? updateData.IsPrivate : original.IsPrivate;

        _repo.UpdateVault(original);
        return original;


    }
}
