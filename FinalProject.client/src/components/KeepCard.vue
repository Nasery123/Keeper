<template>
    <section class="container-fluid" v-if="keep">
        <div class="row">
            <div class="col-4">
                <!-- <div class="" v-for="p in keep" :key="p.id"></div> -->
                <div class="text-light" :style="{ backgroundImage: `url(${keep.img})` }">
                    <p>{{ keep.name }}</p>
                </div>
                <!-- {{ keep }} -->
            </div>
        </div>
    </section>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';
import { Keep } from '../models/Keep.js';

export default {
    props: {
        keep: { type: Keep, required: true }
    },
    setup() {
        return {


            // keep: computed(() => AppState.keeps)
        }
    }
}
</script>


<style lang="scss" scoped>
</style>
