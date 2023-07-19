import { Account } from "./Account.js"

export class Keep {
    constructor(data) {
        this.id = data.id
        this.name = data.name
        this.description = data.description
        this.img = data.img
        this.views = data.views
        this.kept = data.kept
        this.creatorId = data.creatorId
        this.creator = new Account(data.creator)
    }
}

export class KeepInVault extends Keep {
    constructor(data) {
        super(data)
        this.vaultKeepId = data.vaultKeepId
    }
}
