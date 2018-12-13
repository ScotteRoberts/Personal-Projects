<template>
  <section class="panel">
    <!-- DEV: Link items -->
    <label
      v-for="link in filteredLinks"
      class="panel-block"
      :key="link.id"
    >
      <a
        :href="link.url"
        class="control"
      >
        {{ link.title }}
      </a>
      <button
        class="delete"
        @click="removeLink(link)"
      >
        <!-- <span class="icon is-small">
          <i class="fas fa-cross"></i>
        </span> -->
        <!-- Open up the menu for delete, edit -->
      </button>
    </label>

    <!-- DEV: Add new link -->
    <div class="panel-block">
      <button
        class="button is-fullwidth has-icon-left"
        @click="newLink.showForm = !newLink.showForm"
      >
        <p class="icon is-small is-left">
          <i class="fas fa-plus"></i>
        </p>
        <p>
          Add link
        </p>
      </button>
    </div>

    <!-- DEV: New link form fields -->
    <!-- TEST: Add input validation for name and url -->
    <div v-show="newLink.showForm">
      <div class="field is-horizontal">
        <div class="field-body">
          <div class="field">
            <p class="control is-expanded has-icons-left">
              <input
                class="input"
                type="text"
                autofocus
                autocomplete="off"
                placeholder="Title"
                v-model="newLink.title"
                @keyup.enter="newLink.addLink"
              >
              <span class="icon is-small is-left">
                <i class="fas fa-file-signature"></i>
              </span>
            </p>
          </div>
        </div>
      </div>

      <div class="field is-horizontal">
        <div class="field-body">
          <div class="field is-expanded">
            <div class="field has-addons">
              <p class="control">
                <a class="button is-static">
                  <span class="icon is-small">
                    <i class="fas fa-globe"></i>
                  </span>
                  <span>
                    https://
                  </span>
                </a>
              </p>
              <p class="control is-expanded">
                <input
                  class="input"
                  type="text"
                  autocomplete="off"
                  placeholder="URL"
                  v-model="newLink.url"
                  @keyup.enter="addLink(newLink)"
                >
              </p>
            </div>
            <p class="help">This is help text...</p>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import { mapState, mapGetters, mapActions } from "vuex";
// Full spec-compliant TodoMVC with localStorage persistence
// and hash-based routing in ~120 effective lines of JavaScript.

// vue component instance
export default {
  // app initial state
  data() {
    return {
      newLink: {
        showForm: false,
        title: "",
        url: "",
        category: "all"
      },
      editedLink: null
    };
  },

  // computed properties
  // http://vuejs.org/guide/computed.html
  computed: {
    ...mapState("link", ["links", "visibility"]),
    ...mapGetters("link", ["filteredLinks"])
  },

  // methods that implement data logic.
  // note there's no DOM manipulation here at all.
  methods: {
    ...mapActions("link", ["removeLink", "onFilterChange"]),
    addLink: function(newLink) {
      this.$store.dispatch("link/addLink", newLink);
      this.newLink.title = "";
      this.newLink.url = "";
    },

    // TEST: Not functional yet...
    editLink: function(link) {
      this.beforeEditCache = link.title;
      this.editedLink = link;
    },

    // TEST: Not functional yet...
    doneEdit: function(link) {
      if (!this.editedLink) {
        return;
      }
      this.editedLink = null;
      link.title = link.title.trim();
      if (!link.title) {
        this.removeLink(link);
      }
    },

    // TEST: Not functional yet...
    cancelEdit: function(link) {
      this.editedLink = null;
      link.title = this.beforeEditCache;
    }
  }
};
</script>

<style scoped>
[v-cloak] {
  display: none;
}
</style>
