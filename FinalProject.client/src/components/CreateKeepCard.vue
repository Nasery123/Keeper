<template>
    <div class="modal-content">
        <div class="modal-header">
            <h1 class="modal-title fs-5" id="exampleModalLabel">Create KEEP</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>


        <form @submit.prevent="createKeep()">
            <div class="modal-body">

                <div class="form-floating">
                    <input type="text" class="form-control" id="floatingPassword" placeholder="name"
                        v-model="editable.name">
                    <label for="floatingPassword">Name</label>
                </div>
                <div class="form-floating">
                    <input type="text" class="form-control" id="floatingPassword" placeholder="Cover Image"
                        v-model="editable.img">
                    <label for="floatingPassword">Cover img</label>
                </div>
                <div class="form-floating">
                    <input type="text" class="form-control" id="floatingPassword" placeholder="description"
                        v-model="editable.description">
                    <label for="floatingPassword">descrioption</label>
                </div>

            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                <button type="submit" class="btn btn-primary">Create</button>
            </div>
        </form>
    </div>
</template>


<script>
import { ref } from 'vue';
import { keepsService } from '../services/KeepsService.js';
import Pop from '../utils/Pop.js';
import { Modal } from 'bootstrap';

export default {
    setup() {
        const editable = ref({})
        return {
            editable,
            async createKeep() {
                try {
                    const formData = editable.value
                    const newKeep = await keepsService.createKeep(formData)
                    Modal.getOrCreateInstance("#createKeep").hide()
                    Pop.toast("your new keep successfully added to the collection")
                    return newKeep;

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
