<template>
  <v-form ref="form">
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
            v-model="defaultProperties.lotNumber"
          ></v-text-field>
        </v-col>
        <v-col class="py-0">
          <v-combobox
            v-model="customSelectableValues.partNumber"
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
            v-model="materialLogModel.materialLog.isMagnet"
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
            v-model="defaultProperties.isAvailable"
          ></v-checkbox>
        </v-col>
      </v-row>
      <v-row>
        <v-col class="py-2">
          <v-combobox
            v-model="customSelectableValues.supplier"
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
            v-model="defaultProperties.poNumber"
          ></v-text-field>
        </v-col>
        <v-col class="pb-3 pt-0">
          <v-checkbox
            label="DFARS"
            dense
            :readonly="!editMode"
            v-model="defaultProperties.isDFARS"
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
            v-model="defaultProperties.description"
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
            v-model="defaultProperties.quantity"
          ></v-text-field>
        </v-col>
        <v-col class="py-2">
          <v-text-field
            label="Primary Location"
            outlined
            dense
            :readonly="!editMode"
            :rules="[validationRules.required]"
            v-model="defaultProperties.primaryLocation"
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
            v-model="defaultProperties.supplierMaterialGrade"
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
            v-model="defaultProperties.mrtNumber"
          ></v-text-field>
        </v-col>
      </v-row>
      <v-row>
        <v-col class="py-2">
          <v-select
            v-model="defaultProperties.unitOfMeasureId"
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
            v-model="defaultProperties.materialLogTypeId"
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
            v-model="defaultProperties.dateCreated"
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
            v-model="defaultProperties.createdBy"
          ></v-text-field>
        </v-col>
      </v-row>
    </v-container>
  </v-form>
</template>

<script>
import validationRules from '@/services/validation/validationRules';

export default {
  name: 'DefaultPropertiesForm',
  props: {
    materialLogModel: Object
  },
  data() {
    return {
      partNumberOptions: [],
      partNumberSearch: null,

      supplierOptions: [],
      supplierSearch: null,
    }
  },
  computed: {
    defaultProperties() {
      const vm = this.materialLogModel;
      return vm.materialLog.defaultProperties;
    },
    selectableOptions() {
      const vm = this.materialLogModel;
      return vm.selectableOptions;
    },
    customSelectableValues() {
      const vm = this.materialLogModel;
      return vm.customSelectableValues;
    },
    editMode() {
      const vm = this.materialLogModel;
      return vm.editMode;
    },
    isNew() {
      const vm = this.materialLogModel;
      return vm.isNew;
    },
    validationRules() {
      return validationRules;
    }
  },
  methods: {
    partNumberChanged(selectedValue) {
      if (this.validationRules.required(selectedValue) !== true)
        return;

      const existingPartNumber = this.partNumberOptions.find(function(partNumber) {
        return partNumber == selectedValue;
      });

      if (!existingPartNumber) {
        this.partNumberOptions.unshift(selectedValue);
      }
    },

    supplierChanged(selectedValue) {
      if (this.validationRules.required(selectedValue) !== true)
        return;
      
      const existingSupplier = this.supplierOptions.find(function(supplier) {
        return supplier == selectedValue;
      });

      if (!existingSupplier) {
        this.supplierOptions.unshift(selectedValue);
      }
    },

    initPartNumbersCombobox() {
      const self = this;

      self.partNumberOptions = self.selectableOptions.partNumbers.map(function(partNumber) {
        return partNumber.value;
      });

      const currentPartNumberObject = self.selectableOptions.partNumbers.find(function(partNumber) {
        return partNumber.id == self.defaultProperties.partNumberId;
      });

      if (currentPartNumberObject) {
        self.customSelectableValues.partNumber = currentPartNumberObject.value;
      }

      self.defaultProperties.partNumberId = 0;
    },

    initSupplierCombobox() {
      const self = this;

      self.supplierOptions = self.selectableOptions.suppliers.map(function(supplier) {
        return supplier.value;
      });

      const currentSupplierObject = self.selectableOptions.suppliers.find(function(supplier) {
        return supplier.id == self.defaultProperties.supplierId;
      });

      if (currentSupplierObject) {
        self.customSelectableValues.supplier = currentSupplierObject.value;
      }

      self.defaultProperties.supplierId = 0;
    },

    validate() {
      return this.$refs.form.validate();
    },

    resetValidation() {
      return this.$refs.form.resetValidation();
    }
  }
}
</script>