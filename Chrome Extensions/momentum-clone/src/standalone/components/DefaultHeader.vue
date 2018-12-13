<template>
  <!-- TODO: Popup "Links" menu for savable links -->
  <!-- TODO: Search bar with clickable icon for text input -->
  <div class="columns no-gap no-padding">
    <div class="column">
      <div class="field is-grouped">
        <div class="control">
          <div
            v-if="showLinks"
            class="dropdown is-hoverable is-left"
          >
            <div class="dropdown-trigger">
              <button
                class="button is-primary"
                aria-haspopup="true"
                aria-controls="dropdown-menu-bookmarks"
              >
                <span>Links</span>
                <span class="icon is-small">
                  <i
                    class="fas fa-angle-down"
                    aria-hidden="true"
                  ></i>
                </span>
              </button>
            </div>
            <div
              class="dropdown-menu"
              id="dropdown-menu-bookmarks"
              role="menu"
            >
              <div class="dropdown-content">
                <links-panel />
              </div>
            </div>
          </div>
        </div>
        <search v-if="showSearch" />
      </div>
    </div>
    <!-- TODO: Weather temp with current weather icon. Popup when clicked to change location and degrees -->
    <div class="column">
      <button class="button is-info is-right">
        <i class="fas fa-cloud-sun"></i>
      </button>
    </div>
  </div>

</template>

<script>
import { mapActions, mapState } from "vuex";
import Search from "@/standalone/elements/Search";
import LinksPanel from "@/standalone/components/LinksPanel";

export default {
  components: {
    Search,
    LinksPanel
  },
  data() {
    return {};
  },
  computed: {
    ...mapState("link", {
      showLinks: state => state.showLinks
    }),
    ...mapState("search", {
      showSearch: state => state.show
    })
  },
  methods: {},
  mounted() {
    chrome.runtime.sendMessage({});
  }
};
</script>


<style lang="scss" scoped>
#dropdown-menu-bookmarks {
  width: 20vw;
  max-height: 80vh;
  overflow: auto;
}
.no-padding {
  padding: 0 !important;
  margin: 0 !important;
}
.is-right {
  float: right;
}
</style>
