<template>
  <div>
    <h2>Weather</h2>
    <h4>
      Approved Time: {{ weatherApprovedTime[0] | moment(dateTimeFormat) }}
    </h4>
    <h4>Reference Time: {{ weatherReference[0] | moment(dateTimeFormat) }}</h4>
    <ul class="forecast">
      <li
        v-for="item in weatherData"
        :key="item.validTime"
        class="forecast-item"
      >
        <h5>{{ [item.validTime] | moment(dateTimeFormat) }}</h5>
        <table>
          <tr v-for="param in item.parameters" :key="param.name" class="param">
            <td :class="param.name" class="param-name">{{ param.name }}</td>
            <td>{{ myTestThing(param.name) }}</td>
            <td class="param-value">{{ param.values[0] }}</td>
            <td class="param-unit">{{ param.unit }}</td>
          </tr>
        </table>
      </li>
    </ul>
  </div>
</template>

<script>
import ApiParamNameConverter from "../utilities/ApiParamNameConverter.ts";
const DateTimeFormat = "ddd, MMM Do YYYY, hh:mm";
const weatherEndpoint =
  "https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/18/lat/59/data.json";

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
    myTestThing: function (param) {
      return new ApiParamNameConverter(param);
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
    .param-name {
      text-align: right;
    }
    .param-unit {
      text-align: left;
    }
  }
  // .spp,
  // .pcat,
  // .pmin,
  // .pmean,
  // .pmax,
  // .pmedian,
  // .tcc_mean,
  // .lcc_mean,
  // .mcc_mean,
  // .hcc_mean,
  // .msl,
  // .t,
  // .vis,
  // .wd,
  // .ws,
  // .r,
  // .tstm,
  // .gust,
  // .Wsymb2 {
  // }
  // .spp {
  //   &:after {
  //     content: "Percent of precipitation in frozen form";
  //   }
  // }
  // .pcat {
  //   &:after {
  //     content: "Precipitation category";
  //   }
  // }
  // .pmin {
  //   &:after {
  //     content: "Minimum precipitation intensity";
  //   }
  // }
  // .pmean {
  //   &:after {
  //     content: "Mean precipitation intensity";
  //   }
  // }
  // .pmax {
  //   &:after {
  //     content: "Maximum precipitation intensity";
  //   }
  // }
  // .pmedian {
  //   &:after {
  //     content: "Median precipitation intensity";
  //   }
  // }
  // .tcc_mean {
  //   &:after {
  //     content: "Mean value of total cloud cover";
  //   }
  // }
  // .lcc_mean {
  //   &:after {
  //     content: "Mean value of low level cloud cover";
  //   }
  // }
  // .mcc_mean {
  //   &:after {
  //     content: "Mean value of medium level cloud cover";
  //   }
  // }
  // .hcc_mean {
  //   &:after {
  //     content: "Mean value of high level cloud cover";
  //   }
  // }
  // .msl {
  //   &:after {
  //     content: "Air pressure";
  //   }
  // }
  // .t {
  //   &:after {
  //     content: "Air temperature";
  //   }
  // }
  // .vis {
  //   &:after {
  //     content: "Horizontal visibility";
  //   }
  // }
  // .wd {
  //   &:after {
  //     content: "Wind direction";
  //   }
  // }
  // .ws {
  //   &:after {
  //     content: "Wind speed";
  //   }
  // }
  // .r {
  //   &:after {
  //     content: "Relative humidity";
  //   }
  // }
  // .tstm {
  //   &:after {
  //     content: "Thunder probability";
  //   }
  // }
  // .gust {
  //   &:after {
  //     content: "Wind gust speed";
  //   }
  // }
  // .Wsymb2 {
  //   &:after {
  //     content: "Weather symbol";
  //   }
  // }
}
</style>