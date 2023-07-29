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
        // let view = document.getElementById('views').textContent;
        // view++;
        AppState.activeKeep = new Keep(res.data)
    }
    async createKeep(formData) {
        const res = await api.post('api/keeps', formData)
        logger.log('here is your new keep', res.data)

    }
    async editKeep(formData) {
        let activeKeep = AppState.activeKeep
        activeKeep = await api.put(`api/keeps/${activeKeep.id}`, formData)
        AppState.activeKeep = new Keep(activeKeep)
    }

    async deleteKeep(keepId) {
        const res = await api.delete(`api/keeps/${keepId}`)
        logger.log(`you deleted the keep at id ${keepId}`)
        const index = AppState.keeps.findIndex(k => k.id == keepId)
        AppState.keeps.splice(index, 1)
        // AppState.keeps = AppState.keeps.filter(k => k.id != keepId)
    }
    async getProfileKeep(id) {
        const res = await api.get(`api/profiles/${id}/keeps`)
        logger.log("here are some keeps for this profile", res.data)
        AppState.profileKeep = res.data.map(k => new Keep(k))
    }
    async searchKeep(searchTerm) {
        const res = await api.get(`api/keep?query=${searchTerm}`)
        AppState.query = searchTerm
        AppState.keeps = res.data.keeps.map(k => new Keep(k))

    }
}
export const keepsService = new KeepsService();
