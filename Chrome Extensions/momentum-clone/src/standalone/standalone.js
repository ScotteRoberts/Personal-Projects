import Vue from "vue";
import App from "./App";
import store from "../store";
import router from "./router";
import VueSweetalert2 from "vue-sweetalert2";
import "moment";
import "@fortawesome/fontawesome-free/css/all.css"; // Font Awesome Icons Integration

Vue.use(VueSweetalert2);

/* eslint-disable no-new */
new Vue({
  el: "#app",
  store,
  router,
  render: h => h(App)
});
