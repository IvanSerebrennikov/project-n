<template>
  <div>
    <v-container>
      <v-row class="mb-6">
        <v-col cols="12" lg="6">
          <v-form>
            <v-container>
              <v-row>
                <v-col>
                  <v-text-field
                    label="Lot #"
                    v-model="materialLog.defaultProperties.lotNumber"
                  ></v-text-field>
                </v-col>
                <v-col>
                  <v-combobox
                    v-model="partNumber"
                    :items="partNumberOptions"
                    :search-input.sync="partNumberSearch"
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
                    label="Magnet"
                  ></v-switch>
                </v-col>
                <v-col>
                  <v-checkbox
                    label="Available"
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
                    v-model="materialLog.defaultProperties.poNumber"
                  ></v-text-field>
                </v-col>
                <v-col>
                  <v-checkbox
                    label="DFARS"
                    v-model="materialLog.defaultProperties.isDFARS"
                  ></v-checkbox>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-text-field
                    label="Description"
                    v-model="materialLog.defaultProperties.description"
                  ></v-text-field>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-text-field
                    label="Qty"
                    v-model="materialLog.defaultProperties.quantity"
                  ></v-text-field>
                </v-col>
                <v-col>
                  <v-text-field
                    label="Primary Location"
                    v-model="materialLog.defaultProperties.primaryLocation"
                  ></v-text-field>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-text-field
                    label="Supplier Material Grade"
                    v-model="materialLog.defaultProperties.supplierMaterialGrade"
                  ></v-text-field>
                </v-col>
                <v-col>
                  <v-text-field
                    label="MRT #"
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
                    label="U/M"
                  ></v-select>
                </v-col>
                <v-col>
                  <v-select
                    v-model="materialLog.defaultProperties.materialLogTypeId"
                    :items="selectableOptions.materialLogTypes"
                    item-text="value"
                    item-value="id"
                    label="Type"
                  ></v-select>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-text-field
                    label="Date Created"
                    v-model="materialLog.defaultProperties.dateCreated"
                  ></v-text-field>
                </v-col>
                <v-col>
                  <v-text-field
                    label="Created By"
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
                              hint="MGOe"
                              persistent-hint
                              v-model="materialLog.magneticProperties.bHmax"
                            ></v-text-field>
                          </v-col>
                          <v-col>
                            <v-text-field
                              label="Hci"
                              hint="kOe"
                              persistent-hint
                              v-model="materialLog.magneticProperties.hci"
                            ></v-text-field>
                          </v-col>
                        </v-row>
                        <v-row>
                          <v-col>
                            <v-text-field
                              label="Br"
                              hint="kG"
                              persistent-hint
                              v-model="materialLog.magneticProperties.br"
                            ></v-text-field>
                          </v-col>
                          <v-col>
                            <v-text-field
                              label="Hc"
                              hint="kOe"
                              persistent-hint
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
                              label="Shape"
                            ></v-select>
                          </v-col>
                        </v-row>
                        <v-row>
                          <v-col cols="4">
                            <v-text-field
                              label="Dim1"
                              v-model="materialLog.dimensions.dim1"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <v-text-field
                              label="Dim2"
                              v-model="materialLog.dimensions.dim2"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <v-text-field
                              label="DimLm"
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
                              v-model="materialLog.bars.bars1"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <v-text-field
                              label="FT 1"
                              v-model="materialLog.bars.fT1"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <v-text-field
                              label="Total FT"
                              v-model="materialLog.bars.totalFT"
                            ></v-text-field>
                          </v-col>
                        </v-row>
                        <v-row>
                          <v-col cols="4">
                            <v-text-field
                              label="Bars 2"
                              v-model="materialLog.bars.bars2"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <v-text-field
                              label="FT 2"
                              v-model="materialLog.bars.fT2"
                            ></v-text-field>
                          </v-col>
                        </v-row>
                        <v-row>
                          <v-col cols="4">
                            <v-text-field
                              label="Bars 3"
                              v-model="materialLog.bars.bars3"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <v-text-field
                              label="FT 3"
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
            color="success"
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
      supplierSearch: null
    }
  },
  methods: {
    partNumberChanged: function(selectedValue) {
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