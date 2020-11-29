<template>
  <v-container>
    <v-row>
      <v-col>
        <div>
          <v-btn
            color="success"
            @click="goToMaterialLogForm('new')"
          >
            <v-icon left>
              mdi-pencil-plus
            </v-icon>
            New
          </v-btn>
        </div>
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
    <div class="text-center">
      <v-pagination
        v-model="page"
        :length="pagesCount"
        :total-visible="7"
        @input="getMaterialLogs"
      ></v-pagination>
    </div>
  </v-container>
</template>

<script>
export default {
  name: 'MaterialLogsList',
  data: function() {
    return {
      materialLogs: [],
      page: 1,
      pagesCount: 0
    };
  },
  methods: {
    goToMaterialLogForm: function(lotNumber) {
      this.$router.push({ name: 'MaterialLog', params: { lotNumber: lotNumber }});
    },
    getMaterialLogsCount: function() {
      return this.axios.get(`/api/MaterialLog/count`).then((response) => {
        return response.data;
      });
    },
    getMaterialLogs: async function() {
      const vm = this;

      const take = 15;
      const skip = (vm.page - 1) * take;

      const materialLogsCount = await vm.getMaterialLogsCount();

      vm.pagesCount = Math.ceil(materialLogsCount / take);

      return vm.axios.get(`/api/MaterialLog?skip=${skip}&take=${take}`).then((response) => {
        vm.materialLogs = response.data;
      });
    }
  },
  mounted: function() {
    this.getMaterialLogs();
  }
}
</script>