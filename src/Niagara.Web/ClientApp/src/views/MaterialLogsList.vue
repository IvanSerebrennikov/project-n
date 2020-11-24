<template>
  <div class="material-logs-list">
    Material Logs
    <v-simple-table>
      <template v-slot:default>
        <thead>
          <tr>
            <th class="text-left">
              Lot #
            </th>
            <th class="text-left">
              Description
            </th>
            <th class="text-left">
              Date Created
            </th>
            <th class="text-left">
              Date Updated
            </th>
          </tr>
        </thead>
        <tbody>
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
        </tbody>
      </template>
    </v-simple-table>
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