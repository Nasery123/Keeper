<template>
    <section class="container-fluid">
        <!--  v-if="keep" -->
        <div class="row">
            <!-- <div class="">
            <div class=""> -->
            <!-- <div class="" v-for="p in keep" :key="p.id"></div> -->

            <!-- <div class="text-light" :style="{ backgroundImage: `url(${keep.img})` }">
            <p>{{ keep.name }}</p>
        </div> -->
            <div>
                <img class="keep col-md-4 col-12" @click="sectActiveKeep(keep.id)" :src="keep.img" alt="">
            </div>
            <p><i class="mdi mdi-delete text-danger btn" @click="deleteKeep(keep.id)"></i></p>
            <!-- {{ keep }} -->
            <!-- </div>
        </div> -->
        </div>
    </section>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';
import { Keep } from '../models/Keep.js';
import Pop from '../utils/Pop.js';
import { Modal } from 'bootstrap';
import { keepsService } from '../services/KeepsService.js';
import { logger } from '../utils/Logger.js';

export default {
    props: {
        keep: { type: Keep, required: true }
    },
    setup(props) {
        return {
            async sectActiveKeep(keepId) {
                try {
                    Modal.getOrCreateInstance('#keepDetails').show()
                    await keepsService.setActiveKeep(keepId)
                } catch (error) {
                    Pop.error(error)
                    logger.log(error)
                }
            },
            async deleteKeep(keepId) {
                try {
                    const yes = await Pop.confirm("do you want to delete this keep")
                    if (!yes) {
                        return
                    }
                    await keepsService.deleteKeep(keepId)
                } catch (error) {
                    Pop.error(error)
                    logger.log(error)
                }
            }

        }
    }
}
</script>


<style lang="scss" scoped>
</style>
