import axios from 'axios';

const getAxiosErrorMessage = (error) => {
  if (error.response) {
    return error.response.data;
  } else if (error.request) {
    console.log(error.request);
    return 'Some error occured during request sending';
  } else {
    console.log('Error', error.message);
    return 'Unexpected error occured';
  }
};

export default {
  async getMaterialLog(lotNumber) {
    const response = await axios.get(`/api/MaterialLog/${lotNumber}`);
    return response.data;
  },
  async getSelectableOptions() {
    const response = await axios.get(`/api/MaterialLog/selectableOptions`);
    return response.data;
  },
  async getNotes(lotNumber) {
    const response = await axios.get(`/api/MaterialLog/${lotNumber}/notes`);
    return response.data;
  },
  async createMaterialLog(requestData) {
    try {
      const response = await axios.post(`/api/MaterialLog`, requestData);
      return {
        data: response.data
      };
    }
    catch (error) {
      return {
        error: getAxiosErrorMessage(error)
      };
    }
  },
  async updateMaterialLog(requestData) {
    try {
      const response = await axios.put(`/api/MaterialLog`, requestData);
      return {
        data: response.data
      };
    }
    catch (error) {
      return {
        error: getAxiosErrorMessage(error)
      };
    }
  }
}