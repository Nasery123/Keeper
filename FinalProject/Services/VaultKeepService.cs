namespace FinalProject.Services;

public class VaultKeepService
{
    private readonly VaultKeepRepository _vtrepo;
    private readonly VaultsService _vaultsService;
    private readonly KeepsService _ks;

    public VaultKeepService(VaultKeepRepository vtrepo, VaultsService vaultsService, KeepsService ks)
    {
        _vtrepo = vtrepo;
        _vaultsService = vaultsService;
        _ks = ks;
    }



    internal VaultKeep CreateVault(VaultKeep vkData)
    {
        _ks.GetKeepById(vkData.KeepId, vkData.CreatorId);
        Vault vault = _vaultsService.GetVaultById(vkData.VaultId, vkData.CreatorId);
        if (vault.CreatorId != vkData.CreatorId) throw new Exception("you can not do that");
        VaultKeep vk = _vtrepo.CreateVK(vkData);
        return vk;










        // if (vault.CreatorId == userId)
        // {
        //     vkData.creatorId = userId;
        //     VaultKeep vaultkeepId = _vtrepo.CreateVK(vkData);

        //     VaultKeep newVk = GetVaultKeepById(vaultkeepId);

        //     return newVk;
        // }
        // else
        // {
        //     throw new Exception("you can not do this")
        // }

    }

    internal VaultKeep GetVaultKeepById(int vaultkeepId)
    {
        VaultKeep vaultKeep = _vtrepo.GetVaultKeepById(vaultkeepId);
        if (vaultKeep == null)
        {
            throw new Exception("no vaultKeep for that id");
        }
        return vaultKeep;
    }

    internal string DeleteVaultKeep(int vaultkeepId, string userId)
    {
        VaultKeep vaultKeep = _vtrepo.GetVaultKeepById(vaultkeepId);

        if (vaultKeep.CreatorId == userId)
        {
            // throw new Exception("you are not allowed to delete it");
            _vtrepo.DeleteVaultKeep(vaultkeepId);
            return "you deleted the vaultkeep.";
        }
        else
        {
            throw new Exception("you can not delete this voult keep");
        }

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
