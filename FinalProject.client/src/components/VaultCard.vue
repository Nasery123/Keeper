<template>
    <section>
        <div class=" img-fluid">
            <router-link :to="{ name: 'KeepInVault', params: { vaultId: myVault.id } }">
                <img class="m-2 rounded elevation-4 img-fluid" :src="myVault?.img" alt="">
                <p>{{ myVault.name }}</p>


            </router-link>
            <!-- if router link does not work put use this instead @click="$router.push({ name: 'KeepInVault', params: { vaultId: myVault.id } })" -->
            <!-- v -show="account.id == myVault.creatorId" -->
            <p>
                <i class="mdi mdi-delete text-danger btn" @click="deleteVault(myVault.id)"></i>
            </p>
        </div>
    </section>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';
import { Vault } from '../models/Vault.js';
import Pop from '../utils/Pop.js';
import { vaultsService } from '../services/VaultsService.js';

export default {
    props: {
        myVault: { type: Vault, required: true }
    },
    setup(props) {
        return {
            async deleteVault(vaultId) {
                try {

                    const yes = await Pop.confirm("do you want to delete the vault")
                    if (!yes) {
                        return
                    }
                    await vaultsService.deleteVault(vaultId)
                } catch (error) {
                    Pop.error(error)
                }
            },
            account: computed(() => AppState.account)

        }
    }
}
</script>


<style lang="scss" scoped>
</style>
