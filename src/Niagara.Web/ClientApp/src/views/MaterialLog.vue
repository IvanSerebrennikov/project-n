<template>
  <div>
    <v-container>
      <v-row class="mb-6">
        <v-col cols="12" lg="6">
          <v-form ref="defaultPropertiesForm">
            <v-container>
              <v-row>
                <v-col>
                  <v-text-field
                    label="Lot #"
                    outlined
                    readonly
                    hint="Automatically generated"
                    persistent-hint
                    v-model="materialLog.defaultProperties.lotNumber"
                  ></v-text-field>
                </v-col>
                <v-col>
                  <v-combobox
                    v-model="partNumber"
                    :items="partNumberOptions"
                    :search-input.sync="partNumberSearch"
                    :readonly="!editMode"
                    :rules="[validationRules.required]"
                    label="Part #"
                    @change="partNumberChanged"
                  >
                    <template v-slot:no-data>
                      <v-list-item>
                        <v-list-item-content>
                          <v-list-item-title>
                            No results matching "<strong>{{ partNumberSearch }}</strong>". Press <kbd>enter</kbd> to create a new one.
                          </v-list-item-title>
                        </v-list-item-content>
                      </v-list-item>
                    </template>
                  </v-combobox>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-switch
                    v-model="materialLog.isMagnet"
                    :readonly="!editMode"
                    label="Magnet"
                  ></v-switch>
                </v-col>
                <v-col>
                  <v-checkbox
                    label="Available"
                    :readonly="!editMode"
                    v-model="materialLog.defaultProperties.isAvailable"
                  ></v-checkbox>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-combobox
                    v-model="supplier"
                    :items="supplierOptions"
                    :search-input.sync="supplierSearch"
                    :readonly="!editMode"
                    :rules="[validationRules.required]"
                    label="Supplier"
                    @change="supplierChanged"
                  >
                    <template v-slot:no-data>
                      <v-list-item>
                        <v-list-item-content>
                          <v-list-item-title>
                            No results matching "<strong>{{ supplierSearch }}</strong>". Press <kbd>enter</kbd> to create a new one.
                          </v-list-item-title>
                        </v-list-item-content>
                      </v-list-item>
                    </template>
                  </v-combobox>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-text-field
                    label="PO #"
                    outlined
                    readonly
                    hint="Automatically generated"
                    persistent-hint
                    v-model="materialLog.defaultProperties.poNumber"
                  ></v-text-field>
                </v-col>
                <v-col>
                  <v-checkbox
                    label="DFARS"
                    :readonly="!editMode"
                    v-model="materialLog.defaultProperties.isDFARS"
                  ></v-checkbox>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-text-field
                    label="Description"
                    :readonly="!editMode"
                    :rules="[validationRules.required]"
                    v-model="materialLog.defaultProperties.description"
                  ></v-text-field>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-text-field
                    label="Qty"
                    type="number"
                    :readonly="!editMode"
                    :rules="[validationRules.required]"
                    v-model="materialLog.defaultProperties.quantity"
                  ></v-text-field>
                </v-col>
                <v-col>
                  <v-text-field
                    label="Primary Location"
                    :readonly="!editMode"
                    :rules="[validationRules.required]"
                    v-model="materialLog.defaultProperties.primaryLocation"
                  ></v-text-field>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-text-field
                    label="Supplier Material Grade"
                    :readonly="!editMode"
                    :rules="[validationRules.required]"
                    v-model="materialLog.defaultProperties.supplierMaterialGrade"
                  ></v-text-field>
                </v-col>
                <v-col>
                  <v-text-field
                    label="MRT #"
                    type="number"
                    :readonly="!editMode"
                    :rules="[validationRules.required]"
                    v-model="materialLog.defaultProperties.mrtNumber"
                  ></v-text-field>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-select
                    v-model="materialLog.defaultProperties.unitOfMeasureId"
                    :items="selectableOptions.unitOfMeasures"
                    item-text="value"
                    item-value="id"
                    :readonly="!editMode"
                    :rules="[validationRules.required]"
                    label="U/M"
                  ></v-select>
                </v-col>
                <v-col>
                  <v-select
                    v-model="materialLog.defaultProperties.materialLogTypeId"
                    :items="selectableOptions.materialLogTypes"
                    item-text="value"
                    item-value="id"
                    :readonly="!editMode"
                    :rules="[validationRules.required]"
                    label="Type"
                  ></v-select>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-text-field
                    label="Date Created"
                    filled
                    readonly
                    hint="Automatically generated"
                    persistent-hint
                    v-model="materialLog.defaultProperties.dateCreated"
                  ></v-text-field>
                </v-col>
                <v-col>
                  <v-text-field
                    label="Created By"
                    filled
                    readonly
                    hint="Automatically generated"
                    persistent-hint
                    v-model="materialLog.defaultProperties.createdBy"
                  ></v-text-field>
                </v-col>
              </v-row>
            </v-container>
          </v-form>
        </v-col>
        <v-col cols="12" lg="6">
          <v-form>
            <v-container>
              <template v-if="materialLog.isMagnet === true">
                <v-row>
                  <v-col>
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
                              :readonly="!editMode"
                              v-model="materialLog.magneticProperties.bHmax"
                            ></v-text-field>
                          </v-col>
                          <v-col>
                            <v-text-field
                              label="Hci"
                              suffix="kOe"
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
                              :readonly="!editMode"
                              v-model="materialLog.magneticProperties.br"
                            ></v-text-field>
                          </v-col>
                          <v-col>
                            <v-text-field
                              label="Hc"
                              suffix="kOe"
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
                  <v-col>
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
        <v-col>
          Notes
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
export default {
  name: 'MaterialLog',
  props: ['lotNumber'],
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
      partNumberOptions: [],
      partNumber: null,
      partNumberSearch: null,
      supplierOptions: [],
      supplier: null,
      supplierSearch: null,
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
    switchEditMode: function() {
      this.editMode = !this.editMode;
      this.$refs.defaultPropertiesForm.resetValidation();
    },
    partNumberChanged: function(selectedValue) {
      if (selectedValue === null || selectedValue === undefined || !selectedValue.toString().trim())
        return;

      const existingPartNumber = this.partNumberOptions.find(function(partNumber) {
          return partNumber == selectedValue;
        });

      if (!existingPartNumber) {
        this.partNumberOptions.unshift(selectedValue);
      }
    },
    supplierChanged: function(selectedValue) {
      const existingSupplier = this.supplierOptions.find(function(supplier) {
          return supplier == selectedValue;
        });

      if (!existingSupplier) {
        this.supplierOptions.unshift(selectedValue);
      }
    },
    saveMaterialLog: function() {
      var vm = this;

      const isValid = vm.$refs.defaultPropertiesForm.validate();

      if (!isValid)
        return;

      const requestData = {
        materialLog: vm.materialLog,
        partNumber: vm.partNumber,
        supplier: vm.supplier
      };

      function create() {
        vm.axios.post(`/api/MaterialLog`, requestData).then((response) => {
          console.log(response);
          vm.materialLog = response.data;
          vm.$router.replace({ name: 'MaterialLog', params: { lotNumber: vm.materialLog.defaultProperties.lotNumber }});
        });
      }

      function update() {
        vm.axios.put(`/api/MaterialLog`, requestData).then((response) => {
          console.log(response);
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
      return vm.axios.get(`/api/MaterialLog/single/${vm.lotNumber}`).then((response) => {
        vm.materialLog = response.data;
      });
    }

    function getSelectableOptions() {
      return vm.axios.get(`/api/MaterialLog/selectableOptions`).then((response) => {
        vm.selectableOptions = response.data;
      });
    }

    function initPartNumbersCombobox() {
      vm.partNumberOptions = vm.selectableOptions.partNumbers.map(function(partNumber) {
          return partNumber.value;
        });

        const currentPartNumberObject = vm.selectableOptions.partNumbers.find(function(partNumber) {
          return partNumber.id == vm.materialLog.defaultProperties.partNumberId;
        });

        if (currentPartNumberObject) {
          vm.partNumber = currentPartNumberObject.value;
        }

        vm.materialLog.defaultProperties.partNumberId = 0;
    }

    function initSupplierCombobox() {
      vm.supplierOptions = vm.selectableOptions.suppliers.map(function(supplier) {
          return supplier.value;
        });

        const currentSupplierObject = vm.selectableOptions.suppliers.find(function(supplier) {
          return supplier.id == vm.materialLog.defaultProperties.supplierId;
        });

        if (currentSupplierObject) {
          vm.supplier = currentSupplierObject.value;
        }

        vm.materialLog.defaultProperties.supplierId = 0;
    }

    const promises = [
      getSelectableOptions()
    ];

    if (vm.lotNumber != 'new') {
      promises.push(getMaterialLog());
    }

    Promise.all(promises)
      .then(function() {
        console.log(vm.materialLog);
        console.log(vm.selectableOptions);

        initPartNumbersCombobox();
        initSupplierCombobox();

        if (vm.materialLog.isMagnet === null) {
          vm.materialLog.isMagnet = true;
        }
      });
  }
}
</script>