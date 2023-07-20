import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService {


    async createVault(formdata) {
        const res = await api.post('api/vaults', formdata)
        logger.log('you created this vault', res.data)
        // AppState.vaults = res.data.map(v => new Vault(v))
    }
    async getVault() {
        const res = await api.get('account/vaults')
        logger.log('here are some vaults in your account page', res.data)
        AppState.myVault = res.data.map(v => new Vault(v))
        logger.log('your Appstate vault', AppState.myVault)
    }
    async getProfileVault(id) {
        const res = await api.get(`api/profiles/${id}/vaults`)
        logger.log('here are profiles vault', res.data)
        AppState.profileVault = res.data.map(v => new Vault(v))
    }
    async deleteVault(vaultId) {

        const res = await api.delete(`api/vaults/${vaultId}`)
        logger.log('you deleted this vault', res.data)
        AppState.myVault = AppState.myVault.filter(v => v.id != vaultId)
    }

}
export const vaultsService = new VaultsService()
