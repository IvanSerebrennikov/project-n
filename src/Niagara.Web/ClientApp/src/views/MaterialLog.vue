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
              <template v-if="materialLog.isMagnet === true">
                <v-row>
                  <v-col class="pt-0">
                    <v-card
                      elevation="2"
                    >
                      <v-card-title>
                        Magnetic Properties
                      </v-card-title>
                      <v-card-text>
                        <v-row>
                          <v-col>
                            <v-text-field
                              label="BHmax"
                              suffix="MGOe"
                              type="number"
                              :readonly="!editMode"
                              v-model="materialLog.magneticProperties.bHmax"
                            ></v-text-field>
                          </v-col>
                          <v-col>
                            <v-text-field
                              label="Hci"
                              suffix="kOe"
                              type="number"
                              :readonly="!editMode"
                              v-model="materialLog.magneticProperties.hci"
                            ></v-text-field>
                          </v-col>
                        </v-row>
                        <v-row>
                          <v-col>
                            <v-text-field
                              label="Br"
                              suffix="kG"
                              type="number"
                              :readonly="!editMode"
                              v-model="materialLog.magneticProperties.br"
                            ></v-text-field>
                          </v-col>
                          <v-col>
                            <v-text-field
                              label="Hc"
                              suffix="kOe"
                              type="number"
                              :readonly="!editMode"
                              v-model="materialLog.magneticProperties.hc"
                            ></v-text-field>
                          </v-col>
                        </v-row>
                      </v-card-text>
                    </v-card>
                  </v-col>
                </v-row>
                <v-row>
                  <v-col>
                    <v-card
                      elevation="2"
                    >
                      <v-card-title>
                        Dimensions
                      </v-card-title>
                      <v-card-text>
                        <v-row>
                          <v-col cols="8">
                            <v-select
                              v-model="materialLog.dimensions.shapeId"
                              :items="selectableOptions.shapes"
                              item-text="value"
                              item-value="id"
                              :readonly="!editMode"
                              @change="shapeChanged"
                              label="Shape"
                            ></v-select>
                          </v-col>
                        </v-row>
                        <v-row>
                          <v-col cols="4">
                            <v-text-field
                              label="Dim1"
                              type="number"
                              :readonly="!editMode"
                              v-model="materialLog.dimensions.dim1"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <v-text-field
                              label="Dim2"
                              type="number"
                              :readonly="!editMode"
                              v-model="materialLog.dimensions.dim2"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <v-text-field
                              label="DimLm"
                              type="number"
                              :readonly="!editMode"
                              v-model="materialLog.dimensions.dimLm"
                            ></v-text-field>
                          </v-col>
                        </v-row>
                      </v-card-text>
                    </v-card>
                  </v-col>
                </v-row>
              </template>
              <template v-else-if="materialLog.isMagnet === false">
                <v-row>
                  <v-col class="pt-0">
                    <v-card
                      elevation="2"
                    >
                      <v-card-title>
                        Specifications
                      </v-card-title>
                      <v-card-text>
                        <v-text-field
                          label="Material Complies to"
                          :readonly="!editMode"
                          v-model="materialLog.specifications.materialCompliesTo"
                        ></v-text-field>
                      </v-card-text>
                    </v-card>
                  </v-col>
                </v-row>
                <v-row>
                  <v-col>
                    <v-card
                      elevation="2"
                    >
                      <v-card-text>
                        <v-row>
                          <v-col cols="4">
                            <v-text-field
                              label="Bars 1"
                              type="number"
                              :readonly="!editMode"
                              v-model="materialLog.bars.bars1"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <v-text-field
                              label="FT 1"
                              type="number"
                              :readonly="!editMode"
                              v-model="materialLog.bars.fT1"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <v-text-field
                              label="Total FT"
                              type="number"
                              :readonly="!editMode"
                              v-model="materialLog.bars.totalFT"
                            ></v-text-field>
                          </v-col>
                        </v-row>
                        <v-row>
                          <v-col cols="4">
                            <v-text-field
                              label="Bars 2"
                              type="number"
                              :readonly="!editMode"
                              v-model="materialLog.bars.bars2"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <v-text-field
                              label="FT 2"
                              type="number"
                              :readonly="!editMode"
                              v-model="materialLog.bars.fT2"
                            ></v-text-field>
                          </v-col>
                        </v-row>
                        <v-row>
                          <v-col cols="4">
                            <v-text-field
                              label="Bars 3"
                              type="number"
                              :readonly="!editMode"
                              v-model="materialLog.bars.bars3"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <v-text-field
                              label="FT 3"
                              type="number"
                              :readonly="!editMode"
                              v-model="materialLog.bars.fT3"
                            ></v-text-field>
                          </v-col>
                        </v-row>
                      </v-card-text>
                    </v-card>
                  </v-col>
                </v-row>
              </template>
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

export default {
  name: 'MaterialLog',
  props: ['lotNumber'],
  components: {
    MaterialLogNotes,
    DefaultPropertiesForm
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
    shapeChanged: function(selectedValue) {
      this.materialLog.dimensions.dim1 = null;
      this.materialLog.dimensions.dim2 = null;
      this.materialLog.dimensions.dimLm = null;
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