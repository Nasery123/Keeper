<template>
    <form @submit.prevent="searchKeep()">
        <input class="w-150px rounded" type="text" v-model="search" placeholder="search here">
        <button class="btn btn-primary rounded" type="submit">Search</button>
    </form>
</template>


<script>
import { keepsService } from '../services/KeepsService.js'
import { logger } from '../utils/Logger.js'
import Pop from '../utils/Pop.js'

export default {
    setup() {
        const ref = ('')
        return {
            ref,
            async searchKeep() {
                try {
                    const searchTerm = search.value
                    await keepsService.searchKeep(searchTerm)
                }
                catch (error) {
                    logger.log(error)
                    Pop.error(error)
                }

            }

        }
    }
}
</script>


<style lang="scss" scoped>
</style>
