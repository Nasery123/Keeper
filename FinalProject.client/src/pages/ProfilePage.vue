<template>
    <div class="contianer-fluid">
        <div class="row">
            <div class="col-12">
                {{ profile.picture }}
            </div>
        </div>
        <div class="row">

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
        onMounted(() => {
            getProfileById()
        })
        return {
            profile: computed(() => AppState.profile)
        }
    }
}
</script>


<style lang="scss" scoped>
</style>
