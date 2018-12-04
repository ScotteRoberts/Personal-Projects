let moment = require("moment");

export default {
  state: {
    foo: "bar",

    // Account
    nickname: "",
    username: "",

    // Request

    // Auth

    // Time
    now: moment().format("LT")
  }
};
