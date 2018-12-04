import * as types from "./mutation-types";

let moment = require("moment");

export default {
  [types.UPDATE_FOO](state, payload) {
    state.foo = payload;
  },
  // Account
  [types.UPDATE_NICKNAME](state, nickname) {
    state.nickname = nickname;
  },
  [types.UPDATE_USERNAME](state, username) {
    state.username = username;
  },

  // Request

  // Auth

  // Time
  [types.UPDATE_NOW](state) {
    state.now = moment().format("LT");
  }
};
