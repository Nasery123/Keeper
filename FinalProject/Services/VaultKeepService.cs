namespace FinalProject.Services;

public class VaultKeepService
{
    private readonly VaultKeepRepository _vtrepo;
    private readonly VaultsService _vaultsService;

    public VaultKeepService(VaultKeepRepository vtrepo, VaultsService vaultsService)
    {
        _vtrepo = vtrepo;
        _vaultsService = vaultsService;
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

    internal string DeleteVaultKeep(int vaultkeepId, string userId)
    {
        VaultKeep vaultKeep = GetVaultKeepById(vaultkeepId);

        if (vaultKeep.creatorId != userId) throw new Exception("you are not allowed to delete it");
        int rows = _vtrepo.DeleteVaultKeep(vaultkeepId);
        if (rows > 1) throw new Exception(" please do not delete more than one row");
        return "you deleted the vaultkeep.";

    }

    internal List<KeepsInVault> GetKeepsByVaultId(int vaultId, string userId)
    {
        // TODO Check if vault is private and whether you are owner
        // TODO check if user is null...should throw an error if it is
        Vault vault = _vaultsService.GetVaultById(vaultId, userId);
        if (vault == null) throw new Exception("there is an error");
        if (vault.CreatorId != userId) throw new Exception("something wrong with user");
        List<KeepsInVault> keeps = _vtrepo.GetKeepsByVaultId(vaultId);
        return keeps;
    }
}
