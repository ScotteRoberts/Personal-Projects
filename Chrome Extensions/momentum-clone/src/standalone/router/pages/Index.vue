<template>
  <!-- DEV: Full Page Background -->

  <body class="hero is-fullheight has-bg-img">
    <!-- Hero head: will stick at the top -->
    <div class="hero-head">
      <!-- TODO: Popup "Links" menu for savable links -->
      <!-- TODO: Search bar with clickable icon for text input -->
      <div class="level">
        <div class="level-left">
          <div class="field is-grouped">
            <div class="control">
              <div class="dropdown is-hoverable is-left">
                <div class="dropdown-trigger">
                  <button
                    class="button"
                    aria-haspopup="true"
                    aria-controls="dropdown-menu1"
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
                  id="dropdown-menu1"
                  role="menu"
                >
                  <div class="dropdown-content">
                    <todo-list />
                  </div>
                </div>
              </div>
            </div>
            <p class="control has-icons-left">
              <input
                class="input"
                type="text"
                placeholder="Search"
              >
              <span class="icon is-left">
                <i class="fas fa-search"></i>
              </span>
            </p>
          </div>
        </div>
        <!-- TODO: Weather temp with current weather icon. Popup when clicked to change location and degrees -->
        <div class="level-right">
          <button class="button is-info">
            <i class="fas fa-cloud-sun"></i>
          </button>
        </div>
      </div>
    </div>

    <!-- Hero body: will be the center content -->
    <div class="hero-body">
      <div class="container is-fluid">
        <div class="content is-large has-text-centered">
          <h1 class="time has-text-white">
            {{this.now}}
          </h1>
          <h1 class="greeting has-text-white">
            Welcome, {{this.username}}
          </h1>
          <h2 class="subtitle has-text-light">
            What is your main focus for today?
          </h2>
          <!-- TODO: Add focus input for single focus task -->
        </div>

      </div>
    </div>

    <!-- Hero footer: will stick at the bottom -->
    <div class="hero-foot">
      <div class="level">
        <!-- TODO: Settings popup with loads of shit. -->
        <!-- TODO: Location of image with hoverable photographer name and link -->
        <div class="level-left">
          <div class="field is-grouped">
            <p class="control">
              <a class="button is-primary">
                <i class="fas fa-cog"></i>
              </a>
            </p>
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
        <!-- TEST: Has issue of pulling up the other level-items when quote is too large. -->
        <div class="level-item has-text-centered">
          <div class="container">

            <div class="content has-text-white">
              <span>
                "To be, or not to be."
              </span>
              <span> -- Isaac Lidsky
              </span>
            </div>
          </div>
        </div>
        <!-- TODO: Todo list with links for previous todo items sorted by day. -->
        <div class="level-right">
          <div class="dropdown is-hoverable is-up is-right">
            <div class="dropdown-trigger">
              <button
                class="button"
                aria-haspopup="true"
                aria-controls="dropdown-menu4"
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
              id="dropdown-menu4"
              role="menu"
            >
              <div class="dropdown-content">
                <todo-list />
              </div>
            </div>
          </div>

        </div>
      </div>
    </div>
  </body>

</template>

<script>
import { mapActions, mapState } from "vuex";
import TodoList from "@/standalone/components/TodoList";

export default {
  components: {
    TodoList
  },
  computed: {
    ...mapState(["nickname", "username", "now"])
  },
  methods: {
    ...mapActions(["setNickname", "setUsername"]),

    toggleIsActive: function(item) {
      item.isActive = !item.isActive;
    }
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
  },
  mounted() {
    chrome.runtime.sendMessage({});
  }
};
</script>


<style scoped>
/* Work on making background more opaque without affecting the rest of the child elements */
.has-bg-img {
  background: url("https://wallpaperbrowse.com/media/images/background-18.jpg");
  background-position: center center;
  background-repeat: no-repeat;
  background-attachment: fixed;
  background-size: cover;
  background-color: rgba(0, 0, 0, 0.5);
}

.time {
  font-size: 150px;
  margin: 0;
  font-weight: 400;
}
.greeting {
  font-size: 80px;
  font-weight: 400;
  margin: 0;
}

#dropdown-menu1 {
  width: 20vw;
  max-height: 80vh;
  overflow: auto;
}

#dropdown-menu4 {
  width: 20vw;
  max-height: 80vh;
  overflow: auto;
}
</style>
