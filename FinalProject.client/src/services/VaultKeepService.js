import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultKeepService {
    async addKeepInVault(vaultKeepData) {
        const res = await api.post('api/vaultkeeps', vaultKeepData)
        // logger.log('you added that keep in your vault')
        AppState.vaultKeep.push(res.data)
    }

}
export const vaultKeepService = new VaultKeepService()
