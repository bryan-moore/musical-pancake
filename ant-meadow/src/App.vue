<template>
  <div id="app">
    <Header />
    <Clock />
    <Weather />
    <Footer />
  </div>
</template>

<script>
import Header from "./components/Header";
import Footer from "./components/Footer";
import Weather from "./components/Weather";
import Clock from "./components/Clock.vue";

export default {
  name: "App",
  components: {
    Header,
    Footer,
    Clock,
    Weather,
  },
};
</script>

<style>
html {
  background: #1d2636;
}
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #11ece5;
  margin-top: 60px;
}
</style>
