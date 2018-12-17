<template>
  <nav class="panel">
    <p class="panel-heading has-text-centered">
      General
    </p>
    <p class="panel-block label is-marginless">
      Show
    </p>

    <!--  HACK: Don't know how to display different computed properties
          in an array to user v-for... Look up later. -->
    <label class="panel-block">
      <input
        v-model="showLinks"
        type="checkbox"
      >
      <div>Links</div>
    </label>
    <label class="panel-block">
      <input
        v-model="showSearch"
        type="checkbox"
      >
      <div>Search</div>
    </label>
    <label class="panel-block">
      <input
        v-model="showWeather"
        type="checkbox"
      >
      <div>Weather</div>
    </label>
    <label class="panel-block">
      <input
        v-model="showFocus"
        type="checkbox"
      >
      <div>Focus</div>
    </label>
    <label class="panel-block">
      <input
        v-model="showQuote"
        type="checkbox"
      >
      <div>Quote</div>
    </label>
    <label class="panel-block">
      <input
        v-model="showTodo"
        type="checkbox"
      >
      <div>Todos</div>
    </label>
  </nav>
</template>

<script>
import { mapActions } from "vuex";
export default {
  data() {
    return {};
  },
  computed: {
    showLinks: {
      get: function() {
        return this.$store.state.link.showLinks;
      },
      set: function(value) {
        this.$store.dispatch("link/setShowLinks", value);
      }
    },
    showBookmarksBar: {
      get: function() {
        return this.$store.state.link.showBookmarksBar;
      },
      set: function(value) {
        this.$store.dispatch("link/setShowBookmarksBar", value);
      }
    },
    showSearch: {
      get: function() {
        return this.$store.state.search.show;
      },
      set: function(value) {
        this.$store.dispatch("search/setShow", value);
      }
    },
    showWeather: {
      get: function() {
        return this.$store.state.weather.show;
      },
      set: function(value) {
        this.$store.dispatch("weather/setShow", value);
      }
    },
    showFocus: {
      get: function() {
        return this.$store.state.focus.show;
      },
      set: function(value) {
        this.$store.dispatch("focus/setShow", value);
      }
    },
    showQuote: {
      get: function() {
        return this.$store.state.quote.show;
      },
      set: function(value) {
        this.$store.dispatch("quote/setShow", value);
      }
    },
    showTodo: {
      get: function() {
        return this.$store.state.todo.show;
      },
      set: function(value) {
        this.$store.dispatch("todo/setShow", value);
      }
    }
  }
};
</script>

<style>
</style>
