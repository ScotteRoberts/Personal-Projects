<template>
  <nav class="panel">
    <p class="panel-heading">
      General
    </p>
    <div class="panel-block">
      <p class="control has-icons-left">
        <input
          class="input is-small"
          type="text"
          placeholder="search"
        >
        <span class="icon is-small is-left">
          <i
            class="fas fa-search"
            aria-hidden="true"
          ></i>
        </span>
      </p>
    </div>

    <!--  HACK: Don't know how to display different computed properties
          in an array to user v-for... Look up later. -->
    <label class="panel-block">
      <input
        v-model="showLinks"
        type="checkbox"
      >
      <label>Links</label>
    </label>
    <label class="panel-block">
      <input
        v-model="showSearch"
        type="checkbox"
      >
      <label>Search</label>
    </label>
    <label class="panel-block">
      <input
        v-model="showWeather"
        type="checkbox"
      >
      <label>Weather</label>
    </label>
    <label class="panel-block">
      <input
        v-model="showFocus"
        type="checkbox"
      >
      <label>Focus</label>
    </label>
    <label class="panel-block">
      <input
        v-model="showQuote"
        type="checkbox"
      >
      <label>Quote</label>
    </label>
    <label class="panel-block">
      <input
        v-model="showTodo"
        type="checkbox"
      >
      <label>Todos</label>
    </label>

  </nav>
</template>

<script>
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
  },
  methods: {
    log: function(title, message) {
      console.log(title, message);
    }
  }
};
</script>

<style>
</style>
