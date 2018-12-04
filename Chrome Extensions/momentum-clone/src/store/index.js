import Vue from "vue";
import Vuex from "vuex";

// General Store
// TEST: There is a problem with state being in a seperate .js file. The "now" time will not load if it is.
//import state from "./state";
import getters from "./getters";
import mutations from "./mutations";
import actions from "./actions";

// Modules
import account from "./modules/account";
import auth from "./modules/auth";
import request from "./modules/request";
import time from "./modules/time";

Vue.use(Vuex);

let moment = require("moment");

export default new Vuex.Store({
  state: {
    foo: "bar",

    // Account
    nickname: "",
    username: "",

    // Request

    // Auth

    // Time
    now: moment().format("LT")
  },
  getters,
  mutations,
  actions,
  modules: {
    account,
    auth,
    request,
    time
  }
});
