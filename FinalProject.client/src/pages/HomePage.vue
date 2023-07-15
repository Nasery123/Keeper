<template>
  <div class="col-3" v-for="k in keeps" :key="k.id">
    <KeepCard :keep="k" />

  </div>
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
</style>
