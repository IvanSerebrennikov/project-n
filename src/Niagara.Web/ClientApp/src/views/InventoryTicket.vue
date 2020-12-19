<template>
  <v-container>
    <v-row>
      <v-col>
        <v-btn
          color="secondary"
          class="mr-3"
          @click="goBackToInventoryTicketsList"
        >
          <v-icon left>
            mdi-keyboard-backspace
          </v-icon>
          Back
        </v-btn>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <v-form ref="inventoryTicketForm">
          <v-container>
            <v-row>
              <v-col>
                <v-text-field
                  label="Record ID"
                  outlined
                  readonly
                  prepend-icon="mdi-table-key"
                  :hint="isNew ? 'Automatically generated' : ''"
                  persistent-hint
                  v-model="inventoryTicket.id"
                ></v-text-field>
              </v-col>
              <v-col>
                <v-text-field
                  label="Ticket #"
                  outlined
                  :readonly="!isNew"
                  :rules="[validationRules.required]"
                  v-model="inventoryTicket.ticketNumber"
                ></v-text-field>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-text-field
                  label="Job Track #"
                  outlined
                  readonly
                  prepend-icon="mdi-link-variant"
                  :hint="isNew ? 'Automatically generated' : ''"
                  persistent-hint
                  v-model="inventoryTicket.jobTrackNumber"
                ></v-text-field>
              </v-col>
              <v-col>
                <v-text-field
                  label="MCE P/N"
                  outlined
                  :readonly="!isNew"
                  :rules="[validationRules.required]"
                  v-model="inventoryTicket.mce"
                ></v-text-field>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-text-field
                  label="Lot #"
                  readonly
                  outlined
                  :hint="isNew ? 'Can\'t be changed' : ''"
                  persistent-hint
                  v-model="inventoryTicket.materialLogLotNumber"
                ></v-text-field>
              </v-col>
              <v-col>
                <v-text-field
                  label="Qty to be Made"
                  type="number"
                  outlined
                  :readonly="!isNew"
                  :rules="[validationRules.required]"
                  v-model="inventoryTicket.quantityToBeMade"
                ></v-text-field>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-text-field
                  label="Inventory Item"
                  outlined
                  :readonly="!isNew"
                  :rules="[validationRules.required]"
                  v-model="inventoryTicket.inventoryItem"
                ></v-text-field>
              </v-col>
              <v-col>
                <v-text-field
                  label="Qty Issued"
                  type="number"
                  outlined
                  :readonly="!isNew"
                  :rules="[validationRules.required]"
                  v-model="inventoryTicket.quantityIssued"
                ></v-text-field>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-text-field
                  label="Date Created"
                  filled
                  readonly
                  :hint="isNew ? 'Automatically generated' : ''"
                  persistent-hint
                  v-model="inventoryTicket.dateCreated"
                ></v-text-field>
              </v-col>
              <v-col>
                <v-text-field
                  label="Created By"
                  filled
                  readonly
                  :hint="isNew ? 'Automatically generated' : ''"
                  persistent-hint
                  v-model="inventoryTicket.createdBy"
                ></v-text-field>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-textarea
                  label="Notes"
                  outlined
                  :readonly="!isNew"
                  v-model="inventoryTicket.notes"
                ></v-textarea>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-btn
                  class="mr-6"
                  color="primary"
                  v-show="isNew"
                  @click="goBackToInventoryTicketsList"
                >
                  <v-icon left>
                    mdi-close-circle
                  </v-icon>
                  Cancel
                </v-btn>
                <v-btn
                  color="success"
                  v-show="isNew"
                  @click="saveInventoryTicket"
                >
                  <v-icon left>
                    mdi-content-save
                  </v-icon>
                  Save
                </v-btn>
              </v-col>
            </v-row>
          </v-container>
        </v-form>
      </v-col>
    </v-row>
    
  </v-container>
</template>

<script>
import materialLogService from '@/services/api/materialLogService';
import validationRules from '@/services/validation/validationRules';

export default {
  name: 'InventoryTicket',
  props: ['lotNumber', 'ticketId'],
  data() {
    return {
      inventoryTicket: {
        materialLogLotNumber: null
      }
    };
  },
  methods: {
    goBackToInventoryTicketsList() {
      this.$router.push({ name: 'InventoryTicketsList', params: { lotNumber: this.lotNumber }});
    },
    async saveInventoryTicket() {
      var vm = this;

      const isValid = vm.$refs.inventoryTicketForm.validate();

      if (!isValid)
        return;

      const create = async () => {
        const result = await materialLogService.createInventoryMaterialTicket(vm.lotNumber, vm.inventoryTicket);

        if (!result.error) {
          vm.inventoryTicket = result.data;
          vm.$router.replace({ name: 'InventoryTicket', params: { lotNumber: vm.lotNumber, ticketId: vm.inventoryTicket.id }});
          vm.$root.$simpleNotification.showSuccess(`Inventory Material Ticket ${vm.inventoryTicket.id} has been created`);
        } else {
          vm.$root.$simpleDialog.showError(result.error);
        }
      }

      await create();
    }
  },
  async mounted() {
    const vm = this;

    const getInventoryTicket = async () => {
      const inventoryTicket = await materialLogService.getInventoryMaterialTicket(vm.lotNumber, vm.ticketId);
      vm.inventoryTicket = inventoryTicket;
    }

    if (!vm.isNew) {
      await getInventoryTicket();
    } else {
      vm.inventoryTicket.materialLogLotNumber = vm.lotNumber;
    }
  },
  computed: {
    isNew: function() {
      return this.ticketId == 'new';
    },
    validationRules: function() {
      return validationRules;
    }
  }
}
</script>