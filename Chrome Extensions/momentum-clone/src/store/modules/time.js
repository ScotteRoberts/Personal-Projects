let moment = require("moment");

const state = {
  clock: {
    local: {
      show: false,
      now: moment().format("LT"),
      type: "" // TEST: Can be ["12", "24", percent]
    },
    world: {
      show: false,
      locations: [],
      type: "" // TEST: Can be ["12", "24"]
    }
  }
};

const mutationTypes = {
  UPDATE_NOW: "UPDATE_NOW"
};

const mutations = {
  [mutationTypes.UPDATE_NOW](state) {
    state.clock.local.now = moment().format("LT");
    // TODO: Create a foreach method for all clocks in the world clock section.
  }
};

const actions = {
  setNow: ({ commit }) => {
    setInterval(() => {
      commit(mutationTypes.UPDATE_NOW);
    }, 1000 * 1);
  }
};

const getters = {
  localNow: state => state.clock.local.now
};

export default {
  state,
  mutations,
  actions,
  getters,
  namespaced: true
};
