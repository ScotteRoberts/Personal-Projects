<template>
  <div>
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  mounted() {
    // DEV: Starts the update timer for the display clock.
    this.$store.dispatch("time/setNow");
  }
};
</script>

<style lang="scss">
/*  
HACK: This was the only way I could find to import Bulma Extensions!!! 
Look later if you want to import more than just the divider
*/
@import "~bulma-extensions/dist/css/bulma-extensions.min.css";

html,
body {
  height: 100%;
}
</style>
