<template>
  <v-container>
    <v-row>
      <v-col>
        <v-btn
          color="secondary"
          class="mr-3"
          @click="goBackToMaterialLog"
        >
          <v-icon left>
            mdi-keyboard-backspace
          </v-icon>
          Back to {{ lotNumber }}
        </v-btn>
        <v-btn
          color="success"
          @click="goToInventoryTicketForm('new')"
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
                @click="goToInventoryTicketForm(inventoryMaterialTicket.id)"
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
  </v-container>
</template>

<script>
import materialLogService from '@/services/api/materialLogService';

export default {
  name: 'InventoryTicketsList',
  props: ['lotNumber'],
  data() {
    return {
      inventoryMaterialTickets: []
    };
  },
  methods: {
    goBackToMaterialLog() {
      this.$router.push({ name: 'MaterialLog', params: { lotNumber: this.lotNumber }});
    },
    goToInventoryTicketForm(ticketId) {
      this.$router.push({ name: 'InventoryTicket', params: { lotNumber: this.lotNumber, ticketId: ticketId }});
    }
  },
  async mounted() {
    const vm = this;

    const inventoryMaterialTickets = await materialLogService.getInventoryMaterialTickets(vm.lotNumber);
    vm.inventoryMaterialTickets = inventoryMaterialTickets;
  }
}
</script>