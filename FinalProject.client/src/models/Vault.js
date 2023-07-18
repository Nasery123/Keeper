import { Account } from "./Account.js"

export class Vault {
    constructor(data) {

        this.id = data.id
        this.name = data.name
        this.description = data.description
        this.img = data.img
        this.isPrivate = data.isPrivate
        this.CreatorId = data.CreatorId
        // this.Creator = new Account(data.Creator)
    }
}
