import * as types from "./mutation-types";

export default {
  setFoo: ({ commit }, payload) => {
    commit(types.UPDATE_FOO, payload);
  },
  // Account
  setNickname: ({ commit }, nickname) => {
    commit(types.UPDATE_NICKNAME, nickname);
  },
  setUsername: ({ commit }, username) => {
    commit(types.UPDATE_USERNAME, username);
  },

  // Request

  // Auth

  // Time
  setNow: ({ commit }) => {
    setInterval(() => {
      commit(types.UPDATE_NOW);
    }, 1000 * 1);
  }
};
