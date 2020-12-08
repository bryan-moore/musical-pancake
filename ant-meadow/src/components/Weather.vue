<template>
  <div>
    <h2>Weather</h2>
    <h4>
      Approved Time: {{ weatherApprovedTime[0] | moment(dateTimeFormat) }}
    </h4>
    <h4>Reference Time: {{ weatherReference[0] | moment(dateTimeFormat) }}</h4>
    <h5>Location: Myrängen</h5>
    <ul class="forecast">
      <li
        v-for="item in weatherData.slice(0, 1)"
        :key="item.validTime"
        class="forecast-item"
      >
        <h5>{{ [item.validTime] | moment(dateTimeFormat) }}</h5>
        <table>
          <tr
            v-for="parameterCode in item.parameters"
            :key="parameterCode.name"
            class="parameterCode"
            :class="parameterCode.name"
          >
            <td class="parameterCode-name">
              {{ fetchParameterNames(parameterCode.name) }}
            </td>
            <td class="parameterCode-value">{{ parameterCode.values[0] }}</td>
            <td class="parameterCode-unit">{{ parameterCode.unit }}</td>
          </tr>
        </table>
      </li>
    </ul>
  </div>
</template>

<script>
// import ApiParamNameConverter from "../utilities/ApiParamNameConverter.ts";
const DateTimeFormat = "ddd, MMM Do YYYY, HH:mm";
const weatherEndpoint =
  "https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/18.033046/lat/59.245421/data.json";

export default {
  data() {
    return {
      weatherApprovedTime: [],
      weatherReference: [],
      weatherData: [],
      dateTimeFormat: DateTimeFormat,
    };
  },
  mounted() {
    fetch(weatherEndpoint, {
      headers: {
        Accept: "application/json",
      },
    })
      .then((res) => res.json())
      .then((forcastResp) => {
        this.weatherApprovedTime = [forcastResp.approvedTime];
        this.weatherReference = [forcastResp.referenceTime];
        this.weatherData = [...forcastResp.timeSeries];
      });
  },
  methods: {
    fetchParameterNames: function (parameterCode) {
      if (parameterCode === "msl") {
        return "Air pressure";
      }
      if (parameterCode === "t") {
        return "Air temperture";
      }
      if (parameterCode === "vis") {
        return "Horizontal visibility";
      }
      if (parameterCode === "wd") {
        return "Wind direction";
      }
      if (parameterCode === "ws") {
        return "Wind speed";
      }
      if (parameterCode === "r") {
        return "Relative humidity";
      }
      if (parameterCode === "tstm") {
        return "Thunder probability";
      }
      if (parameterCode === "tcc_mean") {
        return "Mean value of total cloud cover	";
      }
      if (parameterCode === "lcc_mean") {
        return "Mean value of low level cloud cover";
      }
      if (parameterCode === "mcc_mean") {
        return "Mean value of medium level cloud cover";
      }
      if (parameterCode === "hcc_mean") {
        return "Mean value of high level cloud cover";
      }
      if (parameterCode === "gust") {
        return "Wind gust speed";
      }
      if (parameterCode === "pmin") {
        return "Minimum precipitation intensity";
      }
      if (parameterCode === "pmax") {
        return "Maximum precipitation intensity";
      }
      if (parameterCode === "spp") {
        return "Percent of precipitation in frozen form";
      }
      if (parameterCode === "pcat") {
        return "	Precipitation category";
      }
      if (parameterCode === "pmean") {
        return "Mean precipitation intensity";
      }
      if (parameterCode === "pmedian") {
        return "Median precipitation intensity";
      }
      if (parameterCode === "Wsymb2") {
        return "Weather symbol";
      } else {
        return "unknown parameterCode";
      }
    },
    fetchWeatherSymbol: function (symbolCode) {
      if (symbolCode === 1) {
        return "Clear sky";
      } else {
        return "unknown symbol";
      }
    },
  },
};
</script>

<style lang="less" scoped>
ul {
  margin: 0;
  padding-left: 0;
}
li {
  list-style: none;
}
.forecast-item {
  padding: 1rem;
  border-top: 1px solid rgba(255, 255, 255, 0.3);
  text-align: center;
  h5 {
    margin-top: 0;
  }
  table {
    margin: 0 auto;
    td {
      padding: 0 0.5rem;
    }
    .parameterCode-name {
      text-align: right;
    }
    .parameterCode-unit {
      text-align: left;
    }
  }

  // .msl,
  // .t,
  // .vis,
  // .wd,
  // .ws,
  // .r,
  // .tstm,
  // .tcc_mean,
  // .lcc_mean,
  // .mcc_mean,
  // .hcc_mean,
  // .gust,
  // .pmin,
  // .pmax,
  // .spp,
  // .pcat,
  // .pmean,
  // .pmedian,
  // .Wsymb2 {
  //   display: none;
  // }
  .msl,
  .tstm,
  .tcc_mean,
  .lcc_mean,
  .mcc_mean,
  .hcc_mean,
  .pmin,
  .pmax,
  .spp,
  .pcat,
  .pmean,
  .pmedian {
    display: none;
  }
}
</style>