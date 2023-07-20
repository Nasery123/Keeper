<template>
    <!-- <div class="container-fluid"> -->
    <!-- <div class="row"> -->
    <section>
        <div class="col-md-3 col-12 img-fluid">
            <!-- <router-link :to="{ name: 'KeepInVault', params: { vaultId: myVault.id } }"> -->
            <img @click="$router.push({ name: 'KeepInVault', params: { vaultId: myVault.id } })"
                class="m-2 rounded elevation-4" :src="myVault?.img" alt="">
            <p>{{ myVault.name }}</p>
            <!-- </router-link> -->
            <!-- <p v-if="myVault?.isPrivate" class="text-danger">THIS VAULT IS NOT OPEN TO PUBLIC</p> -->
            <p v-show="account.id == myVault.creatorId"><i class="mdi mdi-delete text-danger btn"
                    @click="deleteVault(myVault.id)"></i></p>
        </div>
    </section>
    <section class="container-fluid">

    </section>



    <!-- </div> -->
    <!-- </div> -->
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
