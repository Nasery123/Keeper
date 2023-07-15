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
}
export const keepsService = new KeepsService();
