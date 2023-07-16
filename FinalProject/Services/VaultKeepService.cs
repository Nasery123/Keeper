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

    // internal List<Keep> GetkeepsByVaultId(int vaultId)
    // {
    //     List<Keep> keeps = _vtrepo.GetKeepsByvaultId(vaultId);
    //     return keeps;
    // }
}
