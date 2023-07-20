<template>
    <section class="container-fluid" v-if="vaultKeep">
        <div class="row">
            <p>here comes some keeps that you do not see it buddy try and try again</p>

            <div class="col-4" v-for="p in vaultKeep" :key="p.id">
                <!-- <img :src="p.img" alt="p.name"> -->


                <KeepCard :keep="p" />
            </div>
        </div>

    </section>
</template>


<script>
import { AppState } from '../AppState.js';
import { logger } from '../utils/Logger.js';
import { vaultKeepService } from '../services/VaultKeepService.js'
import Pop from '../utils/Pop.js';
import { computed, watchEffect } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import { Keep } from '../models/Keep.js';
import { VaultKeep } from '../models/VaultKeep.js';
import { vaultsService } from '../services/VaultsService.js';

export default {

    setup() {
        const route = useRoute()
        const router = useRouter()

        // async function getVaultKeeps() {
        //     try {
        //         await vaultKeepService.getVaultKeeps(route.params.vaultId)
        //     } catch (error) {
        //         Pop.error(error)
        //     }
        // }
        async function getKeepsByVaultId() {
            try {


                await vaultKeepService.getKeepsByVaultId(route.params.vaultId)
            } catch (error) {
                router.push('/')
                Pop.error(error)


            }
        }
        watchEffect(() => {
            if (route.params.vaultId) {
                // getVaultKeeps()
                getKeepsByVaultId()
            }

        })

        return {












            vaultKeep: computed(() => AppState.vaultKeep),
            keep: computed(() => AppState.keeps),
            vaults: computed(() => AppState.vaults)
        };
    },

}
</script>


<style lang="scss" scoped>
</style>
