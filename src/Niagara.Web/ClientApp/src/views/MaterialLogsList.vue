<template>
  <div class="material-logs-list">
    <v-row>
      <v-col class="pl-6">
        <v-btn
          color="success"
          @click="goToMaterialLogForm('new')"
        >
          <v-icon left>
            mdi-pencil-plus
          </v-icon>
          New
        </v-btn>
      </v-col>
    </v-row>
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
              Quantity
            </th>
            <th>
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
              {{ materialLog.quantity }}
            </td>
            <td>
              <v-btn
                color="primary"
                @click="goToMaterialLogForm(materialLog.lotNumber)"
              >
                <v-icon left>
                  mdi-open-in-app
                </v-icon>
                Open
              </v-btn>
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
  methods: {
    goToMaterialLogForm: function(lotNumber) {
      this.$router.push({ name: 'MaterialLog', params: { lotNumber: lotNumber }});
    }
  },
  mounted: function() {
    this.axios.get('/api/MaterialLog/all').then((response) => {
      this.materialLogs = response.data;
    });
  }
}
</script>