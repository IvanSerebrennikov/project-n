import materialLogService from '@/api/materialLogService';

// Simple state without mutations and getters
const mutations = { };
const getters = { };

const getDefaultState = () => {
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
    customSelectableValues: {
      partNumberValue: null,
      supplierValue: null,
    },
    notes: [],
    newNotes: [],
    formProperties: {
      isNew: false,
      editMode: false
    }
  };
}

const state = getDefaultState();

const privateMethods = {
  async initSelectableOptions(state) {
    const selectableOptions = await materialLogService.getSelectableOptions();
    state.selectableOptions = selectableOptions;
  },
  async initNotes(state, lotNumber) {
    const notes = await materialLogService.getNotes(lotNumber);
    state.notes = notes;
    state.newNotes = [];
  },
  async initMaterialLog(state, lotNumber) {
    const materialLog = await materialLogService.getMaterialLog(lotNumber);
    state.materialLog = materialLog;
  },
  collectRequestData(state) {
    const requestData = {
      materialLog: state.materialLog,
      partNumber: state.customSelectableValues.partNumberValue,
      supplier: state.customSelectableValues.supplierValue,
      newNotes: state.newNotes
    };
    return requestData;
  }
}

const actions = {
  resetMaterialLogState({ state }) {
    Object.assign(state, getDefaultState());
  },
  async initMaterialLog({ state }, lotNumber) {
    const promises = [
      privateMethods.initSelectableOptions(state)
    ];

    if (!state.formProperties.isNew) {
      promises.push(privateMethods.initMaterialLog(state, lotNumber));
      promises.push(privateMethods.initNotes(state, lotNumber));
    }

    await Promise.all(promises);

    if (state.materialLog.isMagnet === null) {
      state.materialLog.isMagnet = true;
    }
  },
  async createMaterialLog({ state }) {
    const requestData = privateMethods.collectRequestData(state);
    const result = await materialLogService.createMaterialLog(requestData);

    if (!result.error) {
      state.materialLog = result.data;
      state.formProperties.isNew = false;
      privateMethods.initNotes(state, state.materialLog.defaultProperties.lotNumber);
    }

    return result;
  },
  async updateMaterialLog({ state }) {
    const requestData = privateMethods.collectRequestData(state);
    const result = await materialLogService.updateMaterialLog(requestData);

    if (!result.error) {
      privateMethods.initNotes(state, state.materialLog.defaultProperties.lotNumber);
    }

    return result;
  }
};

export default {
  namespaced: true,
  state,
  mutations,
  actions,
  getters
}