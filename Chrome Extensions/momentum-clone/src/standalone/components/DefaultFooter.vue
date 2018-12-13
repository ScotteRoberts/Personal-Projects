<template>
  <div class="columns is-centered no-padding no-gap">
    <div class="column has-text-centered is-bottom">
      <div class="field is-centered is-grouped">
        <div class="control">
          <div class="dropdown is-hoverable is-up is-left">
            <div class="dropdown-trigger">
              <button
                class="button is-info"
                aria-haspopup="true"
                aria-controls="dropdown-menu-settings"
              >
                <i class="fas fa-cog"></i>
              </button>
            </div>
            <div
              class="dropdown-menu"
              id="dropdown-menu-settings"
              role="menu"
            >
              <div class="dropdown-content">
                <settings-menu />
              </div>
            </div>
          </div>
        </div>
        <p class="control">
          <a
            class="button is-light"
            href="https://unsplash.com/@nbb_photos?utm_medium=referral&amp;utm_campaign=photographer-credit&amp;utm_content=creditBadge"
            target="_blank"
            rel="noopener noreferrer"
            title="Download free do whatever you want high-resolution photos from Lacie Slezak"
          >
            <span class="icon">
              <i class="fas fa-camera"></i>
            </span>
            <span>Lacie Slezak</span>
          </a>
        </p>
      </div>

    </div>
    <div class="column has-text-centered">
      <div
        v-if="showQuote"
        class="content has-text-white"
      >
        <div>
          "Appreciation is a wonderful thing: It makes what is excellent in others belong to us as well."
        </div>
        <div>
          -- Voltaire
        </div>
      </div>
    </div>
    <div class="column is-bottom">
      <div
        v-if="showTodos"
        class="dropdown is-hoverable is-up is-right"
      >
        <div class="dropdown-trigger">
          <button
            class="button is-primary"
            aria-haspopup="true"
            aria-controls="dropdown-menu-todos"
          >
            <span>TODO</span>
            <span class="icon is-small">
              <i
                class="fas fa-angle-up"
                aria-hidden="true"
              ></i>
            </span>
          </button>
        </div>
        <div
          class="dropdown-menu"
          id="dropdown-menu-todos"
          role="menu"
        >
          <div class="dropdown-content">
            <todo-list />
          </div>
        </div>
      </div>
    </div>
  </div>

</template>

<script>
import { mapActions, mapState } from "vuex";
import SettingsMenu from "@/standalone/components/SettingsMenu";
import TodoList from "@/standalone/components/TodoList";

export default {
  components: {
    SettingsMenu,
    TodoList
  },
  data() {
    return {
      quote: {},
      todo: {},
      notes: {},
      mantras: {}
    };
  },
  computed: {
    ...mapState("todo", {
      showTodos: state => state.show
    }),
    ...mapState("quote", {
      showQuote: state => state.show
    })
  },
  methods: {},

  mounted() {
    chrome.runtime.sendMessage({});
  }
};
</script>


<style lang="scss" scoped>
#dropdown-menu-todos {
  width: 20vw;
  max-height: 80vh;
  overflow-y: auto;
}
#dropdown-menu-settings {
  width: 50vw;
  height: 60vh;
  overflow-y: auto;
}
.no-padding {
  padding: 0 !important;
  margin: 0 !important;
}
.is-bottom {
  margin-top: auto;
}
.is-right {
  float: right;
}
</style>
