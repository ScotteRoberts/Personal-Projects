<template>
  <div>
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  mounted() {
    // DEV: Starts the update timer for the display clock.
    this.$store.dispatch("setNow");
  }
};
</script>

<style>
html,
body {
  height: 100%;
}
</style>
