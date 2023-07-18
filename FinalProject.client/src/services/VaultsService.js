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
    }

}
export const vaultsService = new VaultsService()
