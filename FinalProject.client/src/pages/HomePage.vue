<template>
  <div class="row">
    <div class="col-md-4 col-8 d-flex justify-content-between">
      <!-- <div class="dropdown-content"> -->

      <button v-if="account.id" class="btn btn-primary m-1" data-bs-toggle="modal" data-bs-target="#createKeep">CREATE
        KEEP</button>
      <button v-if="account.id" class="btn btn-primary m-1" data-bs-toggle="modal" data-bs-target="#createVault">CREATE
        VAULT</button>
    </div>
  </div>
  <!-- </div> -->
  <section class="container-fluid">
    <div class="row">


      <div class="my-2 col-md-3 col-6" v-for="k in keeps" :key="k.id">
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
      keeps: computed(() => AppState.keeps),
      account: computed(() => AppState.account)

    };
  },

}
</script>

<style scoped lang="scss">
.keep {
  height: 200px;
}
</style>
