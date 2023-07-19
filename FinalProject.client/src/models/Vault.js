import { Account } from "./Account.js"

export class Vault {
    constructor(data) {

        this.id = data.id
        this.name = data.name
        this.description = data.description
        this.img = data.img
        this.isPrivate = data.isPrivate
        this.creatorId = data.creatorId
        // this.Creator = new Account(data.Creator)
    }
}
