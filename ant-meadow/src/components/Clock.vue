<template>
  <div class="clock" v-if="hourtime != ''">
    <h2>Clock</h2>
    <div class="hours">
      <span v-text="hours"></span>
    </div>
    <div class="minutes" v-text="minutes"></div>
    <div class="seconds" v-text="seconds"></div>
  </div>
</template>

<script>
import { SECOND, HOUR, getZeroPad } from "../utilities/clockFilters.ts";

export default {
  data() {
    return {
      hours: 0,
      minutes: 0,
      seconds: 0,
      hourtime: "",
    };
  },
  mounted() {
    this.$options.timer = window.setTimeout(this.updateDateTime, SECOND);
  },
  beforeDestroy() {
    window.clearTimeout(this.$options.timer);
  },
  methods: {
    updateDateTime() {
      const now = new Date();
      this.hours = now.getHours();
      this.minutes = getZeroPad(now.getMinutes());
      this.seconds = getZeroPad(now.getSeconds());
      this.hourtime = this.hours;
      this.hours = this.hours % HOUR || HOUR;
      this.$options.timer = window.setTimeout(this.updateDateTime, SECOND);
    },
  },
};
</script>

<style scoped>
.clock {
  display: inline-block;
  margin-bottom: 1em;
}

.hours,
.minutes,
.seconds {
  display: inline-block;
  font-size: 3rem;
  font-weight: 300;
  padding: 0.5rem;
  text-align: center;
  position: relative;
}

.hours {
}

.minutes {
}

.seconds {
}
</style>