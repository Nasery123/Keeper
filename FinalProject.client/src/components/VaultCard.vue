<template>
    <!-- <div class="container-fluid"> -->
    <!-- <div class="row"> -->
    <div class="col-md-3 col-12 img-fluid">
        <router-link :to="{ name: 'KeepInVault', params: { vaultId: myVault.id } }">
            <img class="m-2 rounded elevation-4" :src="myVault.img" alt="">
        </router-link>
    </div>



    <!-- </div> -->
    <!-- </div> -->
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';
import { Vault } from '../models/Vault.js';

export default {
    props: {
        myVault: { type: Vault, required: true }
    },
    setup() {
        return {

        }
    }
}
</script>


<style lang="scss" scoped>
</style>
