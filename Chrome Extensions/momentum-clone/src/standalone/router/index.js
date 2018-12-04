import Vue from "vue";
import VueRouter from "vue-router";
import routes from "./routes";
import Bulma from "bulma";

Vue.use(VueRouter);

export default new VueRouter({
  routes,
  Bulma
});
