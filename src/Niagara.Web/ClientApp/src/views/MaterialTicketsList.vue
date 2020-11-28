<template>
  <div>
    <v-row>
      <v-col class="pl-6">
        <v-btn
          color="success"
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
              Record ID
            </th>
            <th class="text-left">
              Job Track #
            </th>
            <th class="text-left">
              Ticket #
            </th>
            <th class="text-left">
              Date Created
            </th>
            <th class="text-left">
              Quantity Issued
            </th>
            <th>
            </th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="inventoryMaterialTicket in inventoryMaterialTickets" :key="inventoryMaterialTicket.id">
            <td>
              {{ inventoryMaterialTicket.id }}
            </td>
            <td>
              {{ inventoryMaterialTicket.jobTrackNumber }}
            </td>
            <td>
              {{ inventoryMaterialTicket.ticketNumber }}
            </td>
            <td>
              {{ inventoryMaterialTicket.dateCreated }}
            </td>
            <td>
              {{ inventoryMaterialTicket.quantityIssued }}
            </td>
            <td>
              <v-btn
                color="primary"
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
  name: 'MaterialTicketsList',
  props: ['lotNumber'],
  data: function() {
    return {
      inventoryMaterialTickets: []
    };
  },
  methods: {
    
  },
  mounted: function() {
    const vm = this;

    this.axios.get(`/api/InventoryMaterialTicket/${vm.lotNumber}`).then((response) => {
      this.inventoryMaterialTickets = response.data;
    });
  }
}
</script>