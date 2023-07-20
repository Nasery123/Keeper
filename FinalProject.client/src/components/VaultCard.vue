<template>
    <!-- <div class="container-fluid"> -->
    <!-- <div class="row"> -->
    <section>
        <div class="col-md-3 col-12 img-fluid">
            <router-link :to="{ name: 'KeepInVault', params: { vaultId: myVault.id } }">
                <img class="m-2 rounded elevation-4" :src="myVault?.img" alt="">
                <p>{{ myVault.name }}</p>
                <img v-if="myVault.isPrivate" @click="$router.push({ name: 'Home', params: '/' })"
                    src="https://images.unsplash.com/photo-1572670014853-1d3a3f22b40f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8c3RvcHxlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80"
                    alt="">

            </router-link>
            <!-- if router link does not work put use this instead @click="$router.push({ name: 'KeepInVault', params: { vaultId: myVault.id } })" -->

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
