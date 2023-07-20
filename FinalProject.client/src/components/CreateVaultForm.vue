<template>
    <div class="modal-content">
        <div class="modal-header">
            <h1 class="modal-title fs-5" id="exampleModalLabel">Create Vault</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>


        <form @submit.prevent="createVault()">
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
                    <label for="floatingPassword">Img</label>
                </div>
                <div class="form-floating">
                    <input type="text" class="form-control" id="floatingPassword" placeholder="description"
                        v-model="editable.description">
                    <label for="floatingPassword">descrioption</label>
                </div>

            </div>
            <div class="form-check">
                <!-- NOTE FIRST, MAKE SURE TO SET UP V-MODEL TO WATCH FOR EDITABLE.ISPRIVATE -->
                <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault" v-model="editable.isPrivat">
                <label class="form-check-label" for="flexCheckDefault">
                    Is Private
                </label>
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
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { vaultsService } from '../services/VaultsService.js'
import { Modal } from 'bootstrap';
export default {
    setup() {
        const editable = ref({})
        return {
            editable,
            async createVault() {
                try {
                    const formdata = editable.value
                    // NOTE SECOND, MAKE SURE TO VERIFY IF THERE IS A EDITABLE.ISPRIVATE ON THE EDITABLE, IF NOT SET IT TO FALSE.
                    formdata.isPrivat = formdata.isPrivat ? formdata.isPrivat : false
                    const newVault = await vaultsService.createVault(formdata)
                    Modal.getOrCreateInstance("#createVault").hide()
                    return newVault;
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
