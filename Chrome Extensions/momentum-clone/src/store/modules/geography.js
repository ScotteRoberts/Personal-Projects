const state = {
  currentLocation: {
    zipCode: "",
    latitude: null,
    longitude: null,
    city: "",
    state: "",
    timezone: {
      timezoneIdentifier: "",
      timezoneAbbreviation: "",
      utcOffsetSec: null,
      isDst: ""
    },
    acceptableCityNames: []
    // {
    //   city: "",
    //   state: ""
    // }
  }
};

const zipCodeApiTransformer = function(location) {
  return {
    zipCode: location.zip_code,
    latitude: location.lat,
    longitude: location.lng,
    city: location.city,
    state: location.state,
    timezone: {
      timezoneIdentifier: location.timezone_identifier,
      timezoneAbbreviation: location.timezone_abbr,
      utcOffsetSec: location.utc_offset_sec,
      isDst: location.is_dst
    },
    acceptableCityNames: location.acceptable_city_names
  };
};

const mutationTypes = {
  SET_ZIP_CODE: "SET_ZIP_CODE",
  SET_LOCATION: "SET_LOCATION"
};

const mutations = {
  [mutationTypes.SET_ZIP_CODE](state, zipCode) {
    state.currentLocation.zipCode = zipCode;
  },
  [mutationTypes.SET_LOCATION](state, location) {
    state.currentLocation = location;
  }
};

const actions = {
  setZipCode: ({ commit }, zipCode) => {
    commit(mutationTypes.SET_ZIP_CODE, zipCode);
    // Make an API call to Zip Code API with "zipCode"
    let transformedLocation = zipCodeApiTransformer(location);
    commit(mutationTypes.SET_LOCATION, transformedLocation);
  }
};

const getters = {};

export default {
  state,
  mutations,
  actions,
  getters,
  namespaced: true
};
