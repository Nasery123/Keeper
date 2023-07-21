<template>
    <div class="modal-content" v-if="activeKeep">
        <div class="modal-header">
            <h1 class="modal-title fs-5" id="staticBackdropLabel"> keep details</h1>
        </div>
        <div>
            <div class="row">
                <div class="col-6">
                    <div class="row">
                        <div class="col-12">
                            <!-- <button class="btn btn-primary m-1" data-bs-toggle="modal" data-bs-target="#keepDetails">Edit
                        RECIPE</button> -->
                            <div class="">
                                <img class="img-fluid" :src="activeKeep.img" alt="">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-6">
                    <div class="row">
                    </div>
                    <div class="row">
                        <!-- <p class="text-light">here is your active keep</p> -->
                        <div class="col-12">
                            <p><b>{{ activeKeep.name }}</b></p>
                            <p><i class="mdi mdi-eye ">:<span id="views">
                                        {{ activeKeep.views }}
                                    </span></i></p>
                            <p><i class="mdi mdi-alpha-k-box ">:<span id="kept">
                                        {{ activeKeep.kept }}
                                    </span></i></p>
                            {{ activeKeep.description }}
                            <!-- {{ active.category }} -->

                            <b>{{ activeKeep.creator?.name }}</b>
                            <router-link :to="{ name: 'Profile', params: { profileId: activeKeep?.creatorId } }">
                                <img class="elevation-4 profile" :src="activeKeep.creator?.picture" alt="">
                            </router-link>
                        </div>


                    </div>
                </div>
            </div>
            <!-- <div class="form-group">
                <label for="Vault"> Select Vault</label>
                <select name="Vault" class="form-control" v-model="editable.vaultId">

                    <option value="">Save to your Vault</option>
                    <option v-for="v in myVault" :key="v.id" :value="v.id"> {{ v.name }}</option>
                </select>
            </div> -->
            <p class="text-center mt-4"><b>Choose the vault to save the keep</b></p>
            <div class="modal-footer">

                <!-- <div v-for="vt in myVault">
                    <li class="btn btn-primary" @click="addKeepInVault(vt.id)">save</li>
                </div> -->

                <button v-for="vt in myVault" class="btn btn-primary" @click="addKeepInVault(vt.id)">{{ vt.name
                }}</button>
                <button type="button" class="btn btn-danger" data-bs-dismiss="modal">close</button>


                <!-- </div> -->


            </div>
        </div>
    </div>
</template>


<script>
import { computed, onMounted, ref } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { vaultKeepService } from '../services/VaultKeepService.js';


export default {
    setup() {
        const editable = ref({ vaultId: '' })

        return {
            editable,
            async addKeepInVault(vaultId) {
                try {
                    // NOTE NEED TO GET FIXED AS SOON AS POSSIBLE
                    // keepId = keepDetails.activeKeep.id
                    // let keepId = this.activeKeep.id
                    // logger.log(keepId)
                    // logger.log('here is your ', vaultKeep)
                    // await vaultKeepService.addKeepInVault(editable.value)
                    // editable.value = { vaultId: '' }

                    // logger.log('[HERE IS YOUR KEEP ID]', keepId)
                    // logger.log('[here is your vaultId]', vaultId)
                    // Pop.toast("you added that keep in your vault");
                    const vkData = {
                        vaultId,
                        keepId: AppState.activeKeep.id
                    };
                    debugger
                    await vaultKeepService.addKeepInVault(vkData)
                    Pop.toast('you successfully added that keep in your vault')



                }
                catch (error) {
                    // Pop.error('something went wrong while adding this keep in your vault')
                    // logger.log(error)
                    Pop.error(error)
                }

            },





            activeKeep: computed(() => AppState.activeKeep),
            // myVaults: computed(() => AppState.myVault)
            vaults: computed(() => AppState.vaults),
            myVault: computed(() => AppState.myVault),
            vaultKeep: computed(() => AppState.vaultKeep)
        }
    }
}
</script>


<style lang="scss" scoped>
.profile {
    height: 100px;
    width: 100px;
    border-radius: 50%;
}
</style>
