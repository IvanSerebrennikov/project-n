<template>
  <div class="material-logs-list">
    Material Logs
    <table>
      <tr>
        <th>
          Lot #
        </th>
        <th>
          Description
        </th>
        <th>
          Date Created
        </th>
        <th>
          Date Updated
        </th>
      </tr>
      <tr v-for="materialLog in materialLogs" :key="materialLog.lotNumber">
        <td>
          {{ materialLog.lotNumber }}
        </td>
        <td>
          {{ materialLog.description }}
        </td>
        <td>
          {{ materialLog.dateCreated }}
        </td>
        <td>
          {{ materialLog.dateUpdated }}
        </td>
      </tr>
    </table>
  </div>
</template>

<script>
export default {
  name: 'MaterialLogsList',
  data: function() {
    return {
      materialLogs: []
    };
  },
  mounted: function() {
    this.axios.get('/api/MaterialLog').then((response) => {
      this.materialLogs = response.data;
    });
  }
}
</script>