namespace FinalProject.Services;

public class KeepsService
{
    private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
        _repo = repo;
    }

    internal object CreateKeep(Keep keepData)
    {
        Keep keep = _repo.CreateKeep(keepData);
        return keep;
    }

    internal List<Keep> GetAllKeep()
    {
        List<Keep> keep = _repo.GetAllKeep();
        return keep;
    }

    internal Keep GetKeepById(int keepId)
    {
        Keep keep = _repo.GetKeepById(keepId);
        return keep;
    }

    internal List<Keep> GetUsersKeep(string profileId)
    {
        List<Keep> usersKeep = _repo.GetUsersKeep(profileId);
        return usersKeep;
    }

    internal string RemoveKeep(int keepId)
    {
        GetKeepById(keepId);

        int rows = _repo.RemoveKeep(keepId);
        if (rows > 1) throw new Exception("please make sure you do not remove more than one");
        return "you sucessfully removed a row in your keep table";
    }

    internal Keep UpdateKeep(Keep updateData)
    {

        Keep original = GetKeepById(updateData.Id);
        original.Name = updateData.Name != null ? updateData.Name : original.Name;
        original.Description = updateData.Description != null ? updateData.Description : original.Description;

        _repo.UpdateKeep(original);
        return original;
    }
}
