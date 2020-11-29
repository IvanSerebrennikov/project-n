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
          <v-form ref="defaultPropertiesForm">
            <v-container>
              <v-row>
                <v-col class="py-0">
                  <v-text-field
                    label="Lot #"
                    outlined
                    dense
                    readonly
                    prepend-icon="mdi-table-key"
                    hint="Automatically generated"
                    persistent-hint
                    v-model="materialLog.defaultProperties.lotNumber"
                  ></v-text-field>
                </v-col>
                <v-col class="py-0">
                  <v-combobox
                    v-model="partNumber"
                    outlined
                    dense
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
                <v-col class="pb-2 pt-0">
                  <v-switch
                    v-model="materialLog.isMagnet"
                    dense
                    :readonly="!editMode"
                    label="Magnet"
                  ></v-switch>
                </v-col>
                <v-col class="pb-2 pt-0">
                  <v-checkbox
                    label="Available"
                    dense
                    :readonly="!editMode"
                    v-model="materialLog.defaultProperties.isAvailable"
                  ></v-checkbox>
                </v-col>
              </v-row>
              <v-row>
                <v-col class="py-2">
                  <v-combobox
                    v-model="supplier"
                    outlined
                    dense
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
                <v-col class="pb-3 pt-0">
                  <v-text-field
                    label="PO #"
                    outlined
                    dense
                    readonly
                    prepend-icon="mdi-link-variant"
                    hint="Automatically generated"
                    persistent-hint
                    v-model="materialLog.defaultProperties.poNumber"
                  ></v-text-field>
                </v-col>
                <v-col class="pb-3 pt-0">
                  <v-checkbox
                    label="DFARS"
                    dense
                    :readonly="!editMode"
                    v-model="materialLog.defaultProperties.isDFARS"
                  ></v-checkbox>
                </v-col>
              </v-row>
              <v-row>
                <v-col class="py-2">
                  <v-text-field
                    label="Description"
                    outlined
                    dense
                    :readonly="!editMode"
                    :rules="[validationRules.required]"
                    v-model="materialLog.defaultProperties.description"
                  ></v-text-field>
                </v-col>
              </v-row>
              <v-row>
                <v-col class="py-2">
                  <v-text-field
                    label="Qty"
                    type="number"
                    :readonly="!editMode || !isNew"
                    outlined
                    dense
                    :hint="!isNew ? 'Can\'t be changed' : ''"
                    persistent-hint
                    :rules="[validationRules.required]"
                    v-model="materialLog.defaultProperties.quantity"
                  ></v-text-field>
                </v-col>
                <v-col class="py-2">
                  <v-text-field
                    label="Primary Location"
                    outlined
                    dense
                    :readonly="!editMode"
                    :rules="[validationRules.required]"
                    v-model="materialLog.defaultProperties.primaryLocation"
                  ></v-text-field>
                </v-col>
              </v-row>
              <v-row>
                <v-col class="py-2">
                  <v-text-field
                    label="Supplier Material Grade"
                    outlined
                    dense
                    :readonly="!editMode"
                    :rules="[validationRules.required]"
                    v-model="materialLog.defaultProperties.supplierMaterialGrade"
                  ></v-text-field>
                </v-col>
                <v-col class="py-2">
                  <v-text-field
                    label="MRT #"
                    outlined
                    dense
                    type="number"
                    :readonly="!editMode"
                    :rules="[validationRules.required]"
                    v-model="materialLog.defaultProperties.mrtNumber"
                  ></v-text-field>
                </v-col>
              </v-row>
              <v-row>
                <v-col class="py-2">
                  <v-select
                    v-model="materialLog.defaultProperties.unitOfMeasureId"
                    outlined
                    dense
                    :items="selectableOptions.unitOfMeasures"
                    item-text="value"
                    item-value="id"
                    :readonly="!editMode"
                    :rules="[validationRules.required]"
                    label="U/M"
                  ></v-select>
                </v-col>
                <v-col class="py-2">
                  <v-select
                    v-model="materialLog.defaultProperties.materialLogTypeId"
                    outlined
                    dense
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
                <v-col class="py-2">
                  <v-text-field
                    label="Date Created"
                    filled
                    dense
                    readonly
                    hint="Automatically generated"
                    persistent-hint
                    v-model="materialLog.defaultProperties.dateCreated"
                  ></v-text-field>
                </v-col>
                <v-col class="py-2">
                  <v-text-field
                    label="Created By"
                    filled
                    dense
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
          <v-expansion-panels>
            <v-expansion-panel
              @change="notesExpanded = !notesExpanded"
            >
              <v-expansion-panel-header>
                <v-row no-gutters>
                  <v-col>
                    <strong class="text-uppercase grey--text text--darken-1">
                      <v-icon left>
                        mdi-notebook-edit
                      </v-icon>
                      Notes
                    </strong>
                  </v-col>
                </v-row>
              </v-expansion-panel-header>
              <v-expansion-panel-content>
                <v-fab-transition>
                  <v-btn
                    v-show="notesExpanded && editMode"
                    @click="addNoteDialog = true"
                    color="success"
                    fab
                    dark
                    small
                    absolute
                    top
                    left
                  >
                    <v-icon>mdi-plus</v-icon>
                  </v-btn>
                </v-fab-transition>
                <v-dialog
                  v-model="addNoteDialog"
                  width="500"
                >
                  <v-card>
                    <v-card-title class="headline">
                      Add new Note
                    </v-card-title>
                    <v-card-text>
                      <v-textarea
                        outlined
                        v-model="newNoteText"
                        label="Note"
                      ></v-textarea>
                    </v-card-text>
                    <v-divider></v-divider>
                    <v-card-actions>
                      <v-spacer></v-spacer>
                      <v-btn
                        color="primary"
                        class="pr-3"
                        @click="addNoteDialog = false"
                      >
                        <v-icon left>
                          mdi-close-circle
                        </v-icon>
                        Cancel
                      </v-btn>
                      <v-btn
                        color="success"
                        class="pr-3"
                        @click="addNote"
                      >
                        <v-icon left>
                          mdi-notebook-check
                        </v-icon>
                        Add
                      </v-btn>
                    </v-card-actions>
                  </v-card>
                </v-dialog>
                <v-simple-table dense>
                  <template>
                    <thead>
                      <tr>
                        <th class="text-left">
                          Date
                        </th>
                        <th class="text-left">
                          Time
                        </th>
                        <th class="text-left">
                          Author
                        </th>
                        <th class="text-left" colspan="2">
                          Note
                        </th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr
                        v-for="(note, index) in notes"
                        :key="note.id"
                      >
                        <template v-if="note.dateCreated">
                          <td>{{ note.dateCreated }}</td>
                          <td>{{ note.timeCreated }}</td>
                          <td>{{ note.createdBy }}</td>
                          <td colspan="2">{{ note.text }}</td>
                        </template>
                        <template v-else>
                          <td colspan="3">
                            <span class="grey--text text--darken-1">
                              Save Material Log to receive date, time and author...
                            </span>
                          </td>
                          <td>{{ note.text }}</td>
                          <td style="width: 56px;">
                            <v-icon
                              @click="deleteNewNote(index)"
                            >
                              mdi-delete
                            </v-icon>
                          </td>
                        </template>
                      </tr>
                    </tbody>
                  </template>
                </v-simple-table>
              </v-expansion-panel-content>
            </v-expansion-panel>
          </v-expansion-panels>
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

      notes: [],
      notesExpanded: false,
      addNoteDialog: false,
      newNoteText: null,
      newNotes: [],

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
    goToInventoryTicketsList: function() {
      this.$router.push({ name: 'InventoryTicketsList', params: { lotNumber: this.lotNumber }});
    },
    switchEditMode: function() {
      this.editMode = !this.editMode;
      this.$refs.defaultPropertiesForm.resetValidation();
    },
    partNumberChanged: function(selectedValue) {
      if (this.validationRules.required(selectedValue) !== true)
        return;

      const existingPartNumber = this.partNumberOptions.find(function(partNumber) {
          return partNumber == selectedValue;
        });

      if (!existingPartNumber) {
        this.partNumberOptions.unshift(selectedValue);
      }
    },
    supplierChanged: function(selectedValue) {
      if (this.validationRules.required(selectedValue) !== true)
        return;
      
      const existingSupplier = this.supplierOptions.find(function(supplier) {
          return supplier == selectedValue;
        });

      if (!existingSupplier) {
        this.supplierOptions.unshift(selectedValue);
      }
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
    addNote: function() {
      if (this.validationRules.required(this.newNoteText) !== true)
        return;

      this.newNotes.unshift(this.newNoteText);
      this.notes.unshift({
        text: this.newNoteText
      });

      this.addNoteDialog = false;
      this.newNoteText = null;
    },
    deleteNewNote: function(index) {
      this.newNotes.splice(index, 1);
      this.notes.splice(index, 1);
    },
    saveMaterialLog: function() {
      var vm = this;

      const isValid = vm.$refs.defaultPropertiesForm.validate();

      if (!isValid)
        return;

      const requestData = {
        materialLog: vm.materialLog,
        partNumber: vm.partNumber,
        supplier: vm.supplier,
        newNotes: vm.newNotes
      };

      function create() {
        vm.axios.post(`/api/MaterialLog`, requestData).then((response) => {
          console.log(response);
          vm.materialLog = response.data;
          vm.$router.replace({ name: 'MaterialLog', params: { lotNumber: vm.materialLog.defaultProperties.lotNumber }});
          vm.getNotes();
        });
      }

      function update() {
        vm.axios.put(`/api/MaterialLog`, requestData).then((response) => {
          console.log(response);
          vm.getNotes();
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

    if (!vm.isNew) {
      promises.push(getMaterialLog());
      promises.push(vm.getNotes());
    }

    Promise.all(promises)
      .then(function() {
        initPartNumbersCombobox();
        initSupplierCombobox();

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