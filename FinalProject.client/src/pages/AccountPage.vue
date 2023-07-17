<template>
  <div class="about text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </div>


  <section class="container-fluid">
    <div class="row">
      {{ vaults }}
    </div>

  </section>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { vaultsService } from '../services/VaultsService.js';
export default {
  setup() {
    async function getVault() {
      try {
        await vaultsService.getVault()
      } catch (error) {
        Pop.error(error)
        logger.log(error)
      }
    }
    onMounted(() => {
      getVault()
    })
    return {
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
