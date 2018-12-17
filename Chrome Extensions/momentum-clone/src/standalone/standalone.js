import Vue from "vue"; // Vue.js framework
import App from "./App"; // Main entry point for template
import store from "../store"; // Client-side Storage
import router from "./router"; // Client-side Routing
import "../plugins/axios"; // HTTP Client Integration
import "../plugins/bulma"; // Style Framework Integration
import "../plugins/vueSweetAlert2"; // Styled Popups Integration
import "moment"; // Global Clock Integration
import "@fortawesome/fontawesome-free/css/all.css"; // Font Awesome Icons Integration

/* eslint-disable no-new */
new Vue({
  el: "#app",
  store,
  router,
  render: h => h(App)
});
