<template>
    <section class="container-fluid">
        <div class="row">
            <div class="col-4" v-for="p in vaultKeep" :key="p.id">

                <KeepCard :vaultkeep="p" />
                <p>here comes some keeps that you can not do it buddy try and try again</p>
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
                Pop.error(error)

            }
        }
        watchEffect(() => {
            if (route.params.vaultId) {
                // getVaultKeeps()
                getKeepsByVaultId()
            }
            // else {
            //     router.push('/')
            // }
        })

        return {












            vaultKeep: computed(() => AppState.vaultKeep)
        };
    },

}
</script>


<style lang="scss" scoped>
</style>
