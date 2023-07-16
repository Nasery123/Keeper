<template>
    <div class="modal-content">
        <div class="modal-header">
            <h1 class="modal-title fs-5" id="staticBackdropLabel"> keep details</h1>
        </div>
        <div>
            <div class="row">
                <div class="col-4">
                    <button class="btn btn-primary m-1" data-bs-toggle="modal" data-bs-target="#keepDetails">Edit
                        RECIPE</button>
                </div>
            </div>
            <div class="row">
                <div class="col-3 modal-body">
                    <img class="img-fluid" :src="activeKeep.img" alt="">
                </div>
                <!-- <p class="text-light">here is your active keep</p> -->
                <div class="col-3">
                    <p>{{ activeKeep.name }}</p>
                    {{ activeKeep.description }}
                    <!-- {{ active.category }} -->
                </div>
                <!-- <p>INGREDIENTS</p>
                <div class="col-3" v-for="i in ingredients" :key="i.id">
                    {{ i.name }}
                    {{ i.quantity }} -->

                <!-- {{ ingredients.Quantity }} -->
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-primary" data-bs-dismiss="modal">close</button>


            </div>


        </div>
    </div>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';

export default {
    setup() {
        return {




            activeKeep: computed(() => AppState.activeKeep)
        }
    }
}
</script>


<style lang="scss" scoped>
</style>
