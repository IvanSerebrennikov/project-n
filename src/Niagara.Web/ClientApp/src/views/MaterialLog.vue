<template>
  <div>
    <PrintAllPage
      id="printAll"
      class="d-none"
      :materialLogModel="materialLogModel"
    ></PrintAllPage>
    <PrintLabelPage
      id="printLabel"
      class="d-none"
      :materialLogModel="materialLogModel"
    ></PrintLabelPage>
    <v-container>
      <v-row v-if="!materialLogModel.isNew">
        <v-col>
          <v-btn
            color="secondary"
            @click="goToInventoryTicketsList"
          >
            <v-icon left>
              mdi-card-bulleted-outline
            </v-icon>
            Inventory Material tickets
          </v-btn>
        </v-col>
        <v-col>
          <div class="text-right" style="min-width: 305px;">
            <v-btn
              color="info"
              class="mr-3"
              @click="printAll"
            >
              <v-icon left>
                mdi-printer
              </v-icon>
              Print All
            </v-btn>
            <v-btn
              color="info"
              @click="printLabel"
            >
              <v-icon left>
                mdi-printer-pos
              </v-icon>
              Print Label
            </v-btn>
          </div>
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="12" lg="6">
          <DefaultPropertiesForm
            ref="defaultPropertiesForm"
            :materialLogModel="materialLogModel"
            :validationRules="validationRules"
          ></DefaultPropertiesForm>
        </v-col>
        <v-col cols="12" lg="6">
          <v-form>
            <v-container>
              <MagneticProperties
                v-if="materialLogModel.materialLog.isMagnet === true"
                :materialLogModel="materialLogModel"
              ></MagneticProperties>
              <NonMagneticProperties
                v-else-if="materialLogModel.materialLog.isMagnet === false"
                :materialLogModel="materialLogModel"
              ></NonMagneticProperties>
            </v-container>
          </v-form>
        </v-col>
      </v-row>
      <v-row>
        <v-col class="pt-0">
          <MaterialLogNotes
            :materialLogModel="materialLogModel"
            :validationRules="validationRules"
          ></MaterialLogNotes>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <v-btn
            class="mr-6"
            color="primary"
            v-show="!materialLogModel.editMode"
            @click="switchEditMode"
          >
            <v-icon left>
              mdi-pencil
            </v-icon>
            Edit
          </v-btn>
          <v-btn
            class="mr-6"
            color="primary"
            v-show="materialLogModel.editMode"
            @click="switchEditMode"
          >
            <v-icon left>
              mdi-pencil-off
            </v-icon>
            Cancel Edit
          </v-btn>
          <v-btn
            color="success"
            v-show="materialLogModel.editMode"
            @click="saveMaterialLog"
          >
            <v-icon left>
              mdi-content-save
            </v-icon>
            Save
          </v-btn>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
import MaterialLogNotes from '@/components/materialLog/MaterialLogNotes';
import DefaultPropertiesForm from '@/components/materialLog/DefaultPropertiesForm';
import MagneticProperties from '@/components/materialLog/MagneticProperties';
import NonMagneticProperties from '@/components/materialLog/NonMagneticProperties';
import PrintAllPage from '@/components/materialLog/PrintAllPage';
import PrintLabelPage from '@/components/materialLog/PrintLabelPage';

export default {
  name: 'MaterialLog',
  props: ['lotNumber'],
  components: {
    MaterialLogNotes,
    DefaultPropertiesForm,
    MagneticProperties,
    NonMagneticProperties,
    PrintAllPage,
    PrintLabelPage
  },
  data: function() {
    return {
      materialLogModel: {
        editMode: false,
        isNew: false,

        materialLog: {
          defaultProperties: {},
          isMagnet: null,
          magneticProperties: {},
          dimensions: {},
          specifications: {},
          bars: {}
        },

        selectableOptions: {
          unitOfMeasures: [],
          partNumbers: [],
          suppliers: [],
          shapes: [],
          materialLogTypes: []
        },

        customSelectableValues: {
          partNumber: null,
          supplier: null
        },

        notes: [],
        newNotes: [],
      },

      validationRules: {
        required: function(value) {
          if (value === null || value === undefined || !value.toString().trim()) {
            return 'Required.'
          }
          return true;
        }
      }
    }
  },
  methods: {
    goToInventoryTicketsList: function() {
      this.$router.push({ name: 'InventoryTicketsList', params: { lotNumber: this.lotNumber }});
    },
    printAll: function() {
      this.$printElement('printAll');
    },
    printLabel: function() {
      this.$printElement('printLabel');
    },
    switchEditMode: function() {
      const self = this;
      const vm = self.materialLogModel;

      vm.editMode = !vm.editMode;
      self.$refs.defaultPropertiesForm.resetValidation();
    },
    getNotes: function() {
      const self = this;
      const vm = self.materialLogModel;

      return self.axios.get(`/api/MaterialLog/${self.lotNumber}/notes`).then((response) => {
        vm.notes = response.data;
        vm.newNotes = [];
      });
    },
    saveMaterialLog: function() {
      const self = this;
      const vm = self.materialLogModel;

      const isValid = self.$refs.defaultPropertiesForm.validate();

      if (!isValid)
        return;

      const requestData = {
        materialLog: vm.materialLog,
        partNumber: vm.customSelectableValues.partNumber,
        supplier: vm.customSelectableValues.supplier,
        newNotes: vm.newNotes
      };

      function create() {
        self.axios.post(`/api/MaterialLog`, requestData).then((response) => {
          vm.materialLog = response.data;
          vm.isNew = false;
          self.$router.replace({ name: 'MaterialLog', params: { lotNumber: vm.materialLog.defaultProperties.lotNumber }});
          self.getNotes();
          self.$root.$simpleNotification.showSuccess(`Material Log ${vm.materialLog.defaultProperties.lotNumber} has been created`);
        }).catch(error => {
          self.$root.$simpleDialog.showAxiosError(error);
        });
      }

      function update() {
        self.axios.put(`/api/MaterialLog`, requestData).then((response) => {
          self.getNotes();
          self.$root.$simpleNotification.showSuccess(`Material Log ${vm.materialLog.defaultProperties.lotNumber} has been updated`);
        }).catch(error => {
          self.$root.$simpleDialog.showAxiosError(error);
        });
      }

      if (vm.isNew) {
        create();
      } else {
        update();
      }
    }
  },
  mounted: function() {
    const self = this;
    const vm = self.materialLogModel;

    vm.isNew = vm.editMode = self.lotNumber == 'new';

    function getMaterialLog() {
      return self.axios.get(`/api/MaterialLog/${self.lotNumber}`).then((response) => {
        vm.materialLog = response.data;
      });
    }

    function getSelectableOptions() {
      return self.axios.get(`/api/MaterialLog/selectableOptions`).then((response) => {
        vm.selectableOptions = response.data;
      });
    }

    const promises = [
      getSelectableOptions()
    ];

    if (!vm.isNew) {
      promises.push(getMaterialLog());
      promises.push(self.getNotes());
    }

    Promise.all(promises)
      .then(function() {
        self.$refs.defaultPropertiesForm.initPartNumbersCombobox();
        self.$refs.defaultPropertiesForm.initSupplierCombobox();

        if (vm.materialLog.isMagnet === null) {
          vm.materialLog.isMagnet = true;
        }
      });
  }
}
</script>