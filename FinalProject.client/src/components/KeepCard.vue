<template>
    <section class="container-fluid" v-if="keep">
        <!--  v-if="keep" -->
        <div class="">

            <div>
                <img class="keep img-fluid rounded shadow selectable" @click="sectActiveKeep(keep.id)" :src="keep?.img"
                    alt="">
            </div>

            <!--  -->

            <div>
                <p v-if="account.id == keep.creatorId && !keep.vaultKeepId"><i class="mdi mdi-delete text-danger btn"
                        @click="deleteKeep(keep.id)"></i></p>
            </div>
            <!-- TODO separate button for removing vaultkeep -->
            <p v-if="keep.vaultKeepId"><i class="mdi mdi-delete" @click="deleteVaultkeep(keep.vaultKeepId)"></i></p>

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
import { Account } from '../models/Account.js';
import { vaultKeepService } from '../services/VaultKeepService.js';

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
                    // if (props.keep.creatorId != account.userInfo.id) {
                    //     return
                    // }
                    await keepsService.deleteKeep(keepId)
                } catch (error) {
                    Pop.error(error)
                    logger.log(error)
                }
            },
            async deleteVaultkeep(vaultkeepId) {
                try {

                    const yes = await Pop.confirm("do you want to delet the vaultkeep")
                    if (!yes) {
                        return
                    }
                    await vaultKeepService.deleteVaultkeep(vaultkeepId)
                } catch (error) {
                    Pop.error(error)
                }
            },
            account: computed(() => AppState.account),
            user: computed(() => AppState.user)
            // vaultkeep: computed(() => AppState.vaultKeep)

        }
    }
}
</script>


<style lang="scss" scoped>
.delete {
    height: 200px;
    width: 230px;
}
</style>
