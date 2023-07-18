import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class ProfileService {

    async getProfileById(profileId) {
        const res = await api.get(`api/profiles/${profileId}`)
        logger.log('here is the profile', res.data)
        AppState.profile = res.data
    }

}
export const profileService = new ProfileService();
