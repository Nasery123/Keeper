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

    internal List<Vault> GetMyVault(string id)
    {
        List<Vault> myVault = _repo.GetMyVault(id);
        return myVault;
    }

    // internal List<Vault> GetMyVault(string id)
    // {
    //     List<Vault> myVault = _repo.GetMyVault(id);
    //     return myVault;
    // }

    internal List<Vault> GetUsersVault(string profileId)
    {
        List<Vault> vault = _repo.GetUsersVault(profileId);
        return vault;
    }



    internal Vault GetVaultById(int vaultId, string userId)
    {

        Vault vault = _repo.GetVaultById(vaultId);
        if (vault == null)
        {
            throw new Exception("that vault is not exist");
        }
        if (vault.IsPrivate == true && userId != vault.CreatorId)
        {
            throw new Exception("this vault is not open to public");
        }
        return vault;
    }

    internal string RemoveVault(int vaultId, string userId)
    {


        Vault vault = _repo.GetVaultById(vaultId);
        if (vault.CreatorId != userId) throw new Exception("you can not delete this vault");
        _repo.RemoveVault(vaultId);
        return "you successfully deleted the vault";

        // int rows = _repo.RemoveVault(vaultId);
        // // Vault vault = GetVaultById(vaultId);
        // if (vault.CreatorId != userId) throw new Exception("you can not delete this vault");
        // if (rows > 1) throw new Exception("make sure not to delet more than one row");
        // return "you successfully deleted that vault";
    }

    internal Vault UpdateVault(Vault updateData)
    {
        Vault original = GetVaultById(updateData.Id, updateData.CreatorId);
        if (original == null) throw new Exception("there is nothing in that id");
        original.Name = updateData.Name != null ? updateData.Name : original.Name;
        original.IsPrivate = updateData.IsPrivate != null ? updateData.IsPrivate : original.IsPrivate;

        _repo.UpdateVault(original);
        return original;


    }

}
