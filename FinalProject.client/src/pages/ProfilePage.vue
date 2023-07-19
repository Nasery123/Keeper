<template>
    <div class="contianer-fluid" v-if="profile">
        <div class="row">
            <div class="col-12">
                <img class="rounded elevation-3" :src="profile.picture" alt="">
            </div>
        </div>
        <div class="row">

        </div>
    </div>
    <!-- NOTE profile Vault Section -->

    <!-- NOTE profile keep section -->
    Keep Section
    <div class="container-fluid">
        <div class="row">
            <div v-for="k in profileKeep">
                <KeepCard :keep="k" />
            </div>
        </div>
    </div>
</template>


<script>
import { useRoute } from 'vue-router';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { computed, onMounted } from 'vue';
import { router } from '../router.js';
import { profileService } from '../services/ProfileService.js'
import { AppState } from '../AppState.js';
import { keepsService } from '../services/KeepsService.js';
import { vaultsService } from '../services/VaultsService.js';

export default {
    setup() {
        const route = useRoute()
        async function getProfileById() {
            try {
                await profileService.getProfileById(route.params.profileId)
            } catch (error) {
                Pop.error(error)
                logger.log(error)
                router.push({ name: "Home" })
            }
        }
        async function getProfileKeep() {
            try {
                await keepsService.getProfileKeep(route.params.profileId)
            } catch (error) {
                Pop.error(error)
            }
        }
        async function getProfileVault() {
            try {
                await vaultsService.getProfileVault(route.params.profileId)
            } catch (error) {
                Pop.error(error)

            }
        }
        onMounted(() => {
            getProfileById()
            getProfileKeep()
            getProfileVault()
        })
        return {
            profile: computed(() => AppState.profile),
            profileKeep: computed(() => AppState.profileKeep)
        }
    }
}
</script>


<style lang="scss" scoped>
</style>
