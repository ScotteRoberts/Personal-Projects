<template>
  <div class="columns is-gapless">
    <div class="column is-left is-3">
      <aside class="menu">
        <p class="menu-label">
          Settings
        </p>
        <ul class="menu-list">
          <li><a>General</a></li>
          <li><a>Todo</a></li>
          <li><a>Mantras</a></li>
          <li><a>Photos</a></li>
          <li><a>Quotes</a></li>
          <li><a>Links</a></li>
          <li><a>Balance</a></li>
        </ul>
        <p class="menu-label">
          Documentation
        </p>
        <ul class="menu-list">
          <li><a>About</a></li>
          <li><a>Help</a></li>
          <li><a>Github</a></li>
          <li><a>LinkedIn</a></li>
        </ul>
      </aside>
    </div>
    <div class="is-divider-vertical"></div>
    <div class="column is-right">
      <general-settings />
    </div>
    <!-- HACK: Added extra padding to the end to make the settings panels centered -->
    <div class="column is-1"></div>
  </div>

</template>

<script>
import GeneralSettings from "@/standalone/components/SettingsPanels/General";
export default {
  components: {
    GeneralSettings
  },
  data() {
    return {
      links: {},
      bookmarksBar: {},
      search: {
        provider: {}
      },
      weather: {},
      focus: {},
      quote: {},
      todo: {
        isActive: false
      },
      countdown: {},
      notes: {},
      worldClocks: {},
      mantras: {},
      time: {
        clockFormat: {
          is12Hour: true
        },
        percentClock: {}
      }
    };
  }
};
</script>

<style lang="scss">
</style>
