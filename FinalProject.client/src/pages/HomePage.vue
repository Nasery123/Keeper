<template>
  <div class="row">
    <div class="col-md-4 col-8 d-flex justify-content-between">
      <button class="btn btn-primary m-1" data-bs-toggle="modal" data-bs-target="#createKeep">CREATE
        KEEP</button>
      <button class="btn btn-primary m-1" data-bs-toggle="modal" data-bs-target="#createVault">CREATE VAULT</button>
    </div>
  </div>
  <section class="container-fluid">
    <div class="row">


      <div class="my-2" v-for="k in keeps" :key="k.id">
        <KeepCard :keep="k" />


      </div>
    </div>
  </section>
</template>


<script>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { keepsService } from '../services/KeepsService.js'
import { AppState } from '../AppState.js';

export default {
  setup() {
    async function getKeep() {
      try {
        await keepsService.getKeep();
      }
      catch (error) {
        Pop.error(error);
      }
    }
    onMounted(() => {
      getKeep();
    });
    return {
      keeps: computed(() => AppState.keeps)
    };
  },

}
</script>

<style scoped lang="scss">
.keep {
  height: 200px;
}
</style>
