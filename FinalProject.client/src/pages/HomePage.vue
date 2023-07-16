<template>
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
