<template>
    <!-- <div class="modal-content">
        <div class="modal-header">
            <h5 class="modal-title">Modal title</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <p>Modal body text goes here.</p>
        </div>
        <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Save changes</button>
        </div>
    </div> -->



    <div class="modal-content">
        <div class="modal-header">
            <h1 class="modal-title fs-3 " id="edit-account">Edit Account</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>

        <form class="bg-light" @submit.prevent="handleChanges()">

            <div class="modal-body">
                <div class="form-floating mb-3">
                    <input id="floatingPassword" class="form-control" placeholder="Name" type="text" required
                        v-model="editable.name">
                    <label for="floatingPassword">Name:</label>
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


        </form>
    </div>
</template>


<script>
import { ref, watchEffect } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '../utils/Pop.js';
import { accountService } from '../services/AccountService.js';

export default {
    setup() {
        const editable = ref({})
        watchEffect(() => {
            editable.value = { ...AppState.account }
        })
        return {
            editable,
            async handleChanges() {
                try {
                    await accountService.editAccount(editable.value)
                } catch (error) {
                    Pop.error(error)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
</style>
