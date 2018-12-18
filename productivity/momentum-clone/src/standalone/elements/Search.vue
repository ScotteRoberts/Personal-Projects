<template>
  <p class="control has-icons-left has-text-white">
    <input
      id="search"
      class="input is-rounded has-text-white"
      type="text"
    >
    <span class="icon is-left">
      <i class="fas fa-search"></i>
    </span>
  </p>
</template>

<script>
export default {
  name: "SearchInput"
};
</script>

<style scoped lang="scss">
input {
  border: 1px solid white;
  background-color: transparent;
}
input::placeholder {
  color: white;
  opacity: 1;
}
</style>
