<template>
  <nav class="panel">
    <p class="panel-heading has-text-centered">
      Photos
    </p>

    <div class="panel-block">
      <button
        @click="getRandomPhoto"
        class="button"
      >Get Photo</button>
    </div>

  </nav>
</template>

<script>
export default {
  methods: {
    getRandomPhoto: function() {
      this.$store.dispatch("photo/setUnsplashRandomPhoto");
    }
  }
};
</script>

<style>
</style>
