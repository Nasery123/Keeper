import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class KeepsService {
    async getKeep() {
        logger.log("this sentence is before the res.data")
        const res = await api.get('api/keeps')
        logger.log("here are some keeps", res.data)
        AppState.keeps = res.data.map(k => new Keep(k))
    }
    async setActiveKeep(keepId) {
        const res = await api.get('api/keeps/' + keepId)
        logger.log('here is your active keep', res.data)
        AppState.activeKeep = new Keep(res.data)
    }
}
export const keepsService = new KeepsService();
