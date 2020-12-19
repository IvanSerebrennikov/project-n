<template>
  <div>
    <PrintAllPage
      id="printAll"
      class="d-none"
      :materialLog="materialLog"
      :partNumberValue="customSelectableValues.partNumberValue"
      :supplierValue="customSelectableValues.supplierValue"
      :unitOfMeasures="selectableOptions.unitOfMeasures"
      :shapes="selectableOptions.shapes"
      :materialLogTypes="selectableOptions.materialLogTypes"
    ></PrintAllPage>
    <PrintLabelPage
      id="printLabel"
      class="d-none"
      :materialLog="materialLog"
      :partNumberValue="customSelectableValues.partNumberValue"
      :unitOfMeasures="selectableOptions.unitOfMeasures"
      :materialLogTypes="selectableOptions.materialLogTypes"
    ></PrintLabelPage>
    <v-container>
      <v-row v-if="!formProperties.isNew">
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

            :defaultProperties="materialLog.defaultProperties"
            :magnetChecked.sync="materialLog.isMagnet"
            :partNumberValue.sync="customSelectableValues.partNumberValue"
            :supplierValue.sync="customSelectableValues.supplierValue"

            :editMode="formProperties.editMode"
            :isNew="formProperties.isNew"
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
                :editMode="formProperties.editMode"
                :shapes="selectableOptions.shapes"
              ></MagneticProperties>
              <NonMagneticProperties
                v-else-if="materialLog.isMagnet === false"
                :specifications="materialLog.specifications"
                :bars="materialLog.bars"
                :editMode="formProperties.editMode"
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
            :editMode="formProperties.editMode"
            :validationRules="validationRules"
          ></MaterialLogNotes>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <v-btn
            class="mr-6"
            color="primary"
            v-show="!formProperties.editMode"
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
            v-show="formProperties.editMode"
            @click="switchEditMode"
          >
            <v-icon left>
              mdi-pencil-off
            </v-icon>
            Cancel Edit
          </v-btn>
          <v-btn
            color="success"
            v-show="formProperties.editMode"
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
import { mapState, mapActions } from 'vuex';

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
  data() {
    return {
      validationRules: {
        required(value) {
          if (value === null || value === undefined || !value.toString().trim()) {
            return 'Required.'
          }
          return true;
        }
      }
    }
  },
  computed: {
    ...mapState({
      materialLog: state => state.materialLogModule.materialLog,
      selectableOptions: state => state.materialLogModule.selectableOptions,
      customSelectableValues: state => state.materialLogModule.customSelectableValues,
      notes: state => state.materialLogModule.notes,
      newNotes: state => state.materialLogModule.newNotes, // needed only in MaterialLogNotes component, will be removed from there later
      formProperties: state => state.materialLogModule.formProperties
    })
  },
  methods: {
    ...mapActions('materialLogModule', [
      'resetMaterialLogState',
      'initMaterialLog',
      'createMaterialLog',
      'updateMaterialLog'
    ]),
    goToInventoryTicketsList() {
      this.$router.push({ name: 'InventoryTicketsList', params: { lotNumber: this.lotNumber }});
    },
    printAll() {
      this.$printElement('printAll');
    },
    printLabel() {
      this.$printElement('printLabel');
    },
    switchEditMode() {
      this.formProperties.editMode = !this.formProperties.editMode;
      this.$refs.defaultPropertiesForm.resetValidation();
    },
    async saveMaterialLog() {
      var vm = this;

      const isValid = vm.$refs.defaultPropertiesForm.validate();

      if (!isValid)
        return;

      const create = async () => {
        const result = await vm.createMaterialLog();

        if (!result.error) {
          vm.$router.replace({ name: 'MaterialLog', params: { lotNumber: vm.materialLog.defaultProperties.lotNumber }});
          vm.$root.$simpleNotification.showSuccess(`Material Log ${vm.materialLog.defaultProperties.lotNumber} has been created`);
        } else {
          vm.$root.$simpleDialog.showError(error);
        }
      }

      const update = async () => {
        const result = await vm.updateMaterialLog();

        if (!result.error) {
          vm.$root.$simpleNotification.showSuccess(`Material Log ${vm.materialLog.defaultProperties.lotNumber} has been updated`);
        } else {
          vm.$root.$simpleDialog.showError(error);
        }
      }

      if (!vm.formProperties.isNew) {
        await update();
      } else {
        await create();
      }
    }
  },
  async mounted() {
    const vm = this;

    vm.formProperties.isNew = vm.formProperties.editMode = vm.lotNumber == 'new';

    await vm.initMaterialLog(vm.lotNumber);

    vm.$refs.defaultPropertiesForm.initPartNumbersCombobox();
    vm.$refs.defaultPropertiesForm.initSupplierCombobox();
  },
  destroyed() {
    this.resetMaterialLogState();
  }
}
</script>