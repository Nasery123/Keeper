namespace FinalProject.Services;

public class VaultKeepService
{
    private readonly VaultKeepRepository _vtrepo;

    public VaultKeepService(VaultKeepRepository vtrepo)
    {
        _vtrepo = vtrepo;
    }

    internal VaultKeep CreateVault(VaultKeep vkData)
    {
        VaultKeep newVk = _vtrepo.CreateVK(vkData);

        return newVk;

    }

    internal VaultKeep GetVaultKeepById(int vaultkeepId)
    {
        VaultKeep vaultKeep = _vtrepo.GetVaultKeepById(vaultkeepId);
        return vaultKeep;
    }

    internal string DeleteVaultKeep(int vaultkeepId)
    {
        VaultKeep vaultKeep = GetVaultKeepById(vaultkeepId);
        int rows = _vtrepo.DeleteVaultKeep(vaultkeepId);
        if (rows > 1) throw new Exception(" please do not delete more than one row");
        return "you deleted the vaultkeep.";

    }

    internal List<KeepsInVault> GetKeepsByVaultId(int vaultId)
    {
        List<KeepsInVault> keeps = _vtrepo.GetKeepsByVaultId(vaultId);
        return keeps;
    }
}
