import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultKeepService {
    async addKeepInVault(vkData) {
        const res = await api.post('api/vaultkeeps', vkData)
        // logger.log('you added that keep in your vault')
        AppState.vaultKeep.push(res.data)
    }
    async getKeepsByVaultId(vaultId) {
        debugger
        const res = await api.get(`api/vaults/${vaultId}/keeps`)
        logger.log('here are some keeps for that vault', res.data)
        AppState.vaultKeep = res.data
    }

}
export const vaultKeepService = new VaultKeepService()
