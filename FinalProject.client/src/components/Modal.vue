<template>
    <div class="modal" tabindex="-1">
        <div class="modal-dialog">
            <slot>

            </slot>

            <!-- NOTE: this is the 'modal-guts' and we need to include it on any component we are trying to insert into the slot (insert into the box) -->


        </div>
    </div>
</template>


<script>
export default {
    setup() {
        return {}
    }
}
</script>


<style lang="scss" scoped>
</style>
