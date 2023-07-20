<template>
  <div class="modal-content">
    <div class="modal-header">
      <h1 class="modal-title fs-5" id="exampleModalLabel"> Edit your Account</h1>
      <button data-bs-toggle="modal" data-bs-target="#editAccount">Edit Account</button>
    </div>
    <!-- <form @submit.prevent="handleChanges()">
import KeepCard from '../components/KeepCard.vue.js';

      <div class="modal-body">
        <div class="form-floating mb-3">
          <input name="name" class="form-control" placeholder="Name" type="text" required v-model="editable.name">
          <label for="name">Name:</label>
        </div>
        <div class="form-floating mb-3">
          <input name="picture" class="form-control" placeholder="Profile Picture" type="url" required
            v-model="editable.picture">
          <label for="picture">Picture:</label>
        </div>

      </div>
      <div class="card-footer text-end">
        <button class="btn btn-outline-primary" type="submit">Save Account</button>
      </div>


    </form> -->
  </div>





  <div class="container-fluid">
    <div class="about text-center">
      <h1>Welcome {{ account?.name }}</h1>
      <img class="img-fluid" :src="account?.coverImg" alt="">
      <img class="rounded" :src="account?.picture" alt="" />
      <p>{{ account.email }}</p>
    </div>
  </div>
  <p>Available Vaults: {{ myVault.length }}</p>


  <section class="container-fluid" v-if="myVault">
    <div class="row">
      <div class="col-4" v-for="v in myVault" :key="v.id">
        <VaultCard :myVault="v" />

      </div>

    </div>

  </section> Available Keeps: {{ profileKeep.length }}
  <section class="container-fluid" v-if="profileKeep">
    <div class="row">
      <div class="col-3" v-for="k in profileKeep" :key="k.id">
        <KeepCard :keep="k" />
      </div>

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
    // async function getVault() {
    //   try {
    //     await vaultsService.getVault()
    //   } catch (error) {
    //     Pop.error(error)
    //     logger.log(error)
    //   }
    // }
    // onMounted(() => {
    //   getVault()
    // })
    return {
      account: computed(() => AppState.account),
      // vaults: computed(() => AppState.vaults),
      myVault: computed(() => AppState.myVault),
      profileKeep: computed(() => AppState.profileKeep),
      // keep: computed(() => AppState.keeps)
    };
  },

}
</script>

<style scoped>
.rounded {
  max-width: 100px;
}
</style>
