<template>
  <!-- DEV: Full Page Background -->

  <div class="hero is-fullheight has-bg-img">
    <!-- Hero head: will stick at the top -->
    <header class="hero-head">
      <default-header />
    </header>

    <!-- Hero body: will be the center content -->

    <body class="hero-body">
      <default-greeting />
    </body>

    <!-- Hero footer: will stick at the bottom -->
    <footer class="hero-foot">
      <default-footer />
    </footer>
  </div>

</template>

<script>
import { mapActions, mapState } from "vuex";
import DefaultHeader from "@/standalone/components/DefaultHeader";
import DefaultGreeting from "@/standalone/components/DefaultGreeting";
import DefaultFooter from "@/standalone/components/DefaultFooter";

export default {
  components: {
    DefaultHeader,
    DefaultGreeting,
    DefaultFooter
  },
  computed: {
    ...mapState([])
  },
  methods: {
    ...mapActions([])
  },
  data() {
    return {};
  },
  mounted() {
    chrome.runtime.sendMessage({});
  }
};
</script>


<style lang="scss" scoped>
.has-bg-img {
  background-image: linear-gradient(rgba(0, 0, 0, 0.2), rgba(0, 0, 0, 0.2)),
    url("../../../../public/img/unsplash/lacie-slezak-214673-unsplash.jpg");
  background-position: center center;
  background-repeat: no-repeat;
  background-attachment: fixed;
  background-size: cover;
  background-color: rgba(0, 0, 0, 0.5);
}
.is-right {
  float: right;
}
</style>
