namespace FinalProject.Services;

public class ProfileService
{
    private readonly ProfileRepository _profileRepository;
    public ProfileService(ProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    internal profile GetProfileById(string profileId)
    {
        profile pro = _profileRepository.GetProfileById(profileId);
        return pro;
    }
}
