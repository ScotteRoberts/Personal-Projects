<template>
  <div class="card">
    <header class="card-header">
      <div class="card-header-title">
        <p v-if="currentLocation.city">
          {{currentLocation.city}}, {{currentLocation.state}}
        </p>
        <div
          v-else
          class="field has-addons"
        >
          <div class="control">
            <input
              v-model="zipCode"
              class="input"
              type="text"
              placeholder="Zip Code"
            >
          </div>
          <div class="control">
            <button
              @click="setLocation(zipCode)"
              class="button is-info"
            >
              Get Location
            </button>
          </div>
        </div>
      </div>

      <a
        href="https://darksky.net/dev"
        target="_blank"
        class="card-header-icon"
        aria-label="more options"
      >
        <p>
          DarkSkyAPI
        </p>
        <span class="icon">
          <i
            class="fas fa-tint"
            aria-hidden=true
          ></i>
        </span>
      </a>
    </header>

    <div class="card-content">
      <div v-show="this.visibility === 'minutely'">
        <line-graph />
      </div>
      <div v-show="this.visibility === 'hourly'">
        <line-graph />
      </div>
      <div v-show="this.visibility === 'daily'">
        <daily-weather />
      </div>

    </div>
    <footer class="card-footer">
      <a
        @click="resetGeographyModule"
        class="card-footer-item"
      >Reset Geography</a>
      <a
        @click="onFilterChange('hourly')"
        class="card-footer-item"
      >Hourly</a>
      <a
        @click="onFilterChange('daily')"
        class="card-footer-item"
      >Daily</a>
    </footer>
  </div>
</template>

<script>
import { mapState } from "vuex";
import DailyWeather from "@/standalone/components/weather/DailyWeather";
import LineGraph from "@/standalone/components/weather/LineGraph";

export default {
  name: "Weather",
  data() {
    return {
      // TEST: Should be ["minutely", "hourly", "daily"]
      visibility: "daily",
      filters: {
        minutely: "minutely",
        hourly: "hourly",
        daily: "daily"
      }
    };
  },
  computed: {
    ...mapState("geography", {
      currentLocation: state => state.currentLocation
    })
  },
  components: {
    DailyWeather,
    LineGraph
  },
  methods: {
    onFilterChange: function(visibility) {
      if (this.filters[visibility]) {
        this.visibility = visibility;
        console.log(this.visibility);
      } else {
        this.visibility = "daily";
      }
    },
    setLocation: function(zipCode) {
      this.$axios
        .get(
          "https://www.zipcodeapi.com/rest/x3mOJ6Br6V2EKxp4hxY7c4wqRIriVz4NumqCcHJe4kquVE0kmKjFiUUVKDdBbOGC/info.json/" +
            zipCode +
            "/us"
        )
        .then(response => {
          console.log("Location", response);
          this.$store.dispatch("geography/setLocation", response.data);
          this.setWeather(response.data.lat, response.data.lng);
        })
        .catch(err => {
          console.log(err);
        });
    },
    // TEST: Change to mounted section or interval calls.
    setWeather: function(latitude, longitude) {
      this.$axios
        .get(
          "https://api.darksky.net/forecast/acfb84e0d47ca28cd75e2482545230a2/" +
            latitude +
            "," +
            longitude
        )
        .then(response => {
          console.log(response);
          this.$store.dispatch("weather/setWeather", response.data);
        })
        .catch(err => {
          console.log(err);
        });
    },
    resetGeographyModule: function() {
      this.$store.commit("geography/RESET_GEOGRAPHY_MODULE");
    }
  }
};
</script>

<style>
</style>
