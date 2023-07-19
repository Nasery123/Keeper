<template>
    <div class="contianer-fluid" v-if="profile">
        <div class="row">
            <div class="col-12">
                <img class="rounded elevation-3" :src="profile.picture" alt="">
                <p>{{ profile.name }}</p>
            </div>
        </div>
        <div class="row">

        </div>
    </div>

    <!-- NOTE profile Vault Section -->
    <h3> Vault Section </h3>
    <p class=""><b>{{ profileVault.length }}</b></p>
    <div class="container-fluid">
        <div class="row">
            <div v-for="v in profileVault" v-if="profileVault.isPrivat != false">
                <VaultCard :myVault="v" />
            </div>
        </div>
    </div>

    <!-- NOTE profile keep section -->
    <h3>Keep Section </h3>
    <p><b>{{ profileKeep.length }}</b></p>
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
        const route = useRoute();
        async function getProfileById() {
            try {
                await profileService.getProfileById(route.params.profileId);
            }
            catch (error) {
                Pop.error(error);
                logger.log(error);

            }
        }
        async function getProfileKeep() {
            try {
                await keepsService.getProfileKeep(route.params.profileId);
            }
            catch (error) {
                Pop.error(error);
            }
        }
        async function getProfileVault() {
            try {
                // if (profileVault.isPrivat) {
                //     router.push({ name: "Home" })
                // }
                await vaultsService.getProfileVault(route.params.profileId);
            }
            catch (error) {
                Pop.error(error);
            }
        }
        onMounted(() => {
            getProfileById();
            getProfileKeep();
            getProfileVault();
        });
        return {
            profile: computed(() => AppState.profile),
            profileKeep: computed(() => AppState.profileKeep),
            profileVault: computed(() => AppState.profileVault)
        };
    },

}
</script>


<style lang="scss" scoped>
body {
    margin: 0;
    padding: 0;
}
</style>
