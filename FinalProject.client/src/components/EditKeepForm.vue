<template>
    <div class="modal-content">
        <div class="modal-header">
            <h1 class="modal-title fs-5" id="exampleModalLabel">Edit KEEP</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>


        <form @submit.prevent="ditKeep()">
            <div class="modal-body">
                <!-- <div class="form-floating mb-3">
                    <input type="text" class="form-control" id="floatingInput" placeholder="Category"
                        v-model="editable.Category">
                    <label for="floatingInput">Recipe Category</label>
                </div> -->
                <!-- select category
                <select type="name" class="form-floating" v-model="editable.Category">

                    <option value="mexican">Mexican</option>
                    <option value="burger">Burger</option>
                    <option value="soup">Soup</option>
                    <option value="specialCoffee">Special Coffee</option>
                    <option value="cheese">Cheese</option>
                    <option value="italian">Italian</option>
                </select> -->
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
                <div class="form-floating">
                    <input type="text" class="form-control" id="floatingPassword" placeholder="location"
                        v-model="editable.title">
                    <label for="floatingPassword">title</label>
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                <button type="submit" class="btn btn-primary">Create Recipe</button>
            </div>
        </form>
    </div>
</template>


<script>
import { ref } from 'vue';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { keepsService } from '../services/KeepsService.js';
import { Modal } from 'bootstrap';

export default {
    setup() {
        const editable = ref({})
        return {
            editable,
            async editKeep() {
                try {
                    const keepData = editable.value
                    await keepsService.editKeep(keepData)
                    editable.value = {}
                    Modal.getOrCreateInstance('#editKeep').hide()
                } catch (error) {
                    Pop.error(error)
                    logger.log(error)
                }
            }
        }
    }
}
</script>


<style lang="scss" scoped>
</style>
