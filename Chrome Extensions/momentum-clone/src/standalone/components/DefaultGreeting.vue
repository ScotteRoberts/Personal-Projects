<template>

  <div class="container has-text-centered">
    <div class="time has-text-light">
      {{this.now}}
    </div>
    <div
      v-if="username"
      class="title is-size-1 has-text-light"
    >
      Welcome, {{this.username}}
    </div>
    <div v-else>
      <h1 class="title is-size-1 has-text-light">
        What is your name?
      </h1>
      <input
        v-model="newName"
        @keyup.enter="setUsername(newName)"
      >
    </div>

    <div class="columns is-mobile is-centered">
      <div
        v-if="showFocus"
        class="column is-narrow"
      >
        <h2 class="is-size-2 has-text-white">
          What is your main focus for today?
        </h2>
        <input
          class="input is-rounded has-text-white"
          type="text"
        >
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions, mapState } from "vuex";

export default {
  components: {},
  computed: {
    ...mapState("time", {
      now: state => state.clock.local.now
    }),
    ...mapState("focus", {
      showFocus: state => state.show
    }),
    nickname: {
      get() {
        return this.$store.state.account.nickname;
      },
      set(nickname) {
        this.setUsername(nickname);
      }
    },
    username: {
      get() {
        return this.$store.state.account.username;
      },
      set(username) {
        this.setUsername(username);
      }
    }
  },
  methods: {
    ...mapActions(["setNickname", "setUsername"])
  },
  data() {
    return {
      newName: ""
    };
  },
  mounted() {
    chrome.runtime.sendMessage({});
  }
};
</script>


<style lang="scss" scoped>
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
  font-size: 120px;
  margin: 0;
  padding: 0;
  font-weight: 400;
}
.greeting {
  font-size: 80px;
  font-weight: 400;
  margin: 0;
}
input {
  border: 1px solid white;
  background-color: transparent;
  text-align: center;
}
input::placeholder {
  color: white;
  opacity: 1;
  text-align: center;
}
</style>
