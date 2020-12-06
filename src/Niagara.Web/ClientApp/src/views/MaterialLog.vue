<template>
  <div>
    <v-container>
      <v-row v-if="!isNew">
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
            >
              <v-icon left>
                mdi-printer
              </v-icon>
              Print All
            </v-btn>
            <v-btn
              color="info"
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

            :defaultProperties="materialLog.defaultProperties"
            :magnetChecked.sync="materialLog.isMagnet"
            :partNumberValue.sync="partNumberValue"
            :supplierValue.sync="supplierValue"

            :editMode="editMode"
            :isNew="isNew"
            :validationRules="validationRules"
            :unitOfMeasures="selectableOptions.unitOfMeasures"
            :partNumbers="selectableOptions.partNumbers"
            :suppliers="selectableOptions.suppliers"
            :materialLogTypes="selectableOptions.materialLogTypes"
          ></DefaultPropertiesForm>
        </v-col>
        <v-col cols="12" lg="6">
          <v-form>
            <v-container>
              <MagneticProperties
                v-if="materialLog.isMagnet === true"
                :magneticProperties="materialLog.magneticProperties"
                :dimensions="materialLog.dimensions"
                :editMode="editMode"
                :shapes="selectableOptions.shapes"
              ></MagneticProperties>
              <NonMagneticProperties
                v-else-if="materialLog.isMagnet === false"
                :specifications="materialLog.specifications"
                :bars="materialLog.bars"
                :editMode="editMode"
              ></NonMagneticProperties>
            </v-container>
          </v-form>
        </v-col>
      </v-row>
      <v-row>
        <v-col class="pt-0">
          <MaterialLogNotes
            :notes="notes"
            :newNotes="newNotes"
            :editMode="editMode"
            :validationRules="validationRules"
          ></MaterialLogNotes>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <v-btn
            class="mr-6"
            color="primary"
            v-show="!editMode"
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
            v-show="editMode"
            @click="switchEditMode"
          >
            <v-icon left>
              mdi-pencil-off
            </v-icon>
            Cancel Edit
          </v-btn>
          <v-btn
            color="success"
            v-show="editMode"
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

export default {
  name: 'MaterialLog',
  props: ['lotNumber'],
  components: {
    MaterialLogNotes,
    DefaultPropertiesForm,
    MagneticProperties,
    NonMagneticProperties
  },
  data: function() {
    return {
      editMode: false,

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

      notes: [],
      newNotes: [],

      partNumberValue: null,
      supplierValue: null,

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
    switchEditMode: function() {
      this.editMode = !this.editMode;
      this.$refs.defaultPropertiesForm.resetValidation();
    },
    getNotes: function() {
      const vm = this;
      return vm.axios.get(`/api/MaterialLog/${vm.lotNumber}/notes`).then((response) => {
        vm.notes = response.data;
        vm.newNotes = [];
      });
    },
    saveMaterialLog: function() {
      var vm = this;

      const isValid = vm.$refs.defaultPropertiesForm.validate();

      if (!isValid)
        return;

      const requestData = {
        materialLog: vm.materialLog,
        partNumber: vm.partNumberValue,
        supplier: vm.supplierValue,
        newNotes: vm.newNotes
      };

      function create() {
        vm.axios.post(`/api/MaterialLog`, requestData).then((response) => {
          vm.materialLog = response.data;
          vm.$router.replace({ name: 'MaterialLog', params: { lotNumber: vm.materialLog.defaultProperties.lotNumber }});
          vm.getNotes();
        }).catch(error => {
          vm.$root.$simpleDialog.showAxiosError(error);
        });
      }

      function update() {
        vm.axios.put(`/api/MaterialLog`, requestData).then((response) => {
          vm.getNotes();
        }).catch(error => {
          vm.$root.$simpleDialog.showAxiosError(error);
        });
      }

      if (vm.materialLog.defaultProperties.lotNumber) {
        update();
      } else {
        create();
      }
    }
  },
  mounted: function() {
    const vm = this;

    function getMaterialLog() {
      return vm.axios.get(`/api/MaterialLog/${vm.lotNumber}`).then((response) => {
        vm.materialLog = response.data;
      });
    }

    function getSelectableOptions() {
      return vm.axios.get(`/api/MaterialLog/selectableOptions`).then((response) => {
        vm.selectableOptions = response.data;
      });
    }

    const promises = [
      getSelectableOptions()
    ];

    if (!vm.isNew) {
      promises.push(getMaterialLog());
      promises.push(vm.getNotes());
    }

    Promise.all(promises)
      .then(function() {
        vm.$refs.defaultPropertiesForm.initPartNumbersCombobox();
        vm.$refs.defaultPropertiesForm.initSupplierCombobox();

        if (vm.materialLog.isMagnet === null) {
          vm.materialLog.isMagnet = true;
        }
      });
  },
  computed: {
    isNew: function() {
      return this.lotNumber == 'new';
    }
  }
}
</script>