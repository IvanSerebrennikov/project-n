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
import materialLogService from '@/services/api/materialLogService';

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
      }
    }
  },
  methods: {
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
      const self = this;
      const vm = self.materialLogModel;

      vm.editMode = !vm.editMode;
      self.$refs.defaultPropertiesForm.resetValidation();
    },
    async getNotes() {
      const self = this;
      const vm = self.materialLogModel;

      const notes = await materialLogService.getNotes(self.lotNumber);

      vm.notes = notes;
      vm.newNotes = [];
    },
    async saveMaterialLog() {
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

      const create = async () => {
        const result = await materialLogService.createMaterialLog(requestData);

        if (!result.error) {
          vm.materialLog = result.data;
          vm.isNew = false;
          self.$router.replace({ name: 'MaterialLog', params: { lotNumber: vm.materialLog.defaultProperties.lotNumber }});
          self.getNotes();
          self.$root.$simpleNotification.showSuccess(`Material Log ${vm.materialLog.defaultProperties.lotNumber} has been created`);
        } else {
          self.$root.$simpleDialog.showError(result.error);
        }
      }

      const update = async () => {
        const result = await materialLogService.updateMaterialLog(requestData);

        if (!result.error) {
          self.getNotes();
          self.$root.$simpleNotification.showSuccess(`Material Log ${vm.materialLog.defaultProperties.lotNumber} has been updated`);
        } else {
          self.$root.$simpleDialog.showError(result.error);
        }
      }

      if (vm.isNew) {
        await create();
      } else {
        await update();
      }
    }
  },
  async mounted() {
    const self = this;
    const vm = self.materialLogModel;

    vm.isNew = vm.editMode = self.lotNumber == 'new';

    const getMaterialLog = async () => {
      const materialLog = await materialLogService.getMaterialLog(self.lotNumber);
      vm.materialLog = materialLog;
    }

    const getSelectableOptions = async () => {
      const selectableOptions = await materialLogService.getSelectableOptions();
      vm.selectableOptions = selectableOptions;
    }

    const promises = [
      getSelectableOptions()
    ];

    if (!vm.isNew) {
      promises.push(getMaterialLog());
      promises.push(self.getNotes());
    }

    await Promise.all(promises);

    if (vm.materialLog.isMagnet === null) {
      vm.materialLog.isMagnet = true;
    }

    self.$refs.defaultPropertiesForm.initPartNumbersCombobox();
    self.$refs.defaultPropertiesForm.initSupplierCombobox();
  }
}
</script>