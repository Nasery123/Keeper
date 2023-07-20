import { AppState } from "../AppState.js"
import { KeepInVault } from "../models/Keep.js"
import { VaultKeep } from "../models/VaultKeep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultKeepService {
    async addKeepInVault(vkData) {

        const res = await api.post('api/vaultkeeps', vkData)
        logger.log('you added that keep in your vault', res.data)
        AppState.vaultKeep.push(res.data)
    }
    async getKeepsByVaultId(vaultId) {

        const res = await api.get(`api/vaults/${vaultId}/keeps`)
        logger.log('here are some keeps for that vault', res.data)
        AppState.vaultKeep = res.data.map(vk => new KeepInVault(vk))
    }
    async deleteVaultkeep(vaultkeepId) {
        const res = await api.delete(`api/vaultkeeps/${vaultkeepId}`);
        AppState.vaultKeep = AppState.vaultKeep.filter(v => v.vaultkeepId != vaultkeepId)
    }

}
export const vaultKeepService = new VaultKeepService()
