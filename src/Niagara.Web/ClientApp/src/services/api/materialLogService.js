import apiHelpers from '@/services/api/helpers/apiHelpers';

const baseMaterialLogApiUrl = '/api/MaterialLog';

export default {
  async getMaterialLogsCount() {
    return await apiHelpers.sendBaseReadRequest(
      `${baseMaterialLogApiUrl}/count`);
  },
  async getMaterialLogs(skip = 0, take) {
    return await apiHelpers.sendBaseReadRequest(
      `${baseMaterialLogApiUrl}?skip=${skip}&take=${take}`);
  },
  async getMaterialLog(lotNumber) {
    return await apiHelpers.sendBaseReadRequest(
      `${baseMaterialLogApiUrl}/${lotNumber}`);
  },
  async getSelectableOptions() {
    return await apiHelpers.sendBaseReadRequest(
      `${baseMaterialLogApiUrl}/selectableOptions`);
  },
  async getNotes(lotNumber) {
    return await apiHelpers.sendBaseReadRequest(
      `${baseMaterialLogApiUrl}/${lotNumber}/notes`);
  },
  async createMaterialLog(requestData) {
    return await apiHelpers.sendBaseWriteRequest('post',
      `${baseMaterialLogApiUrl}`, requestData);
  },
  async updateMaterialLog(requestData) {
    return await apiHelpers.sendBaseWriteRequest('put',
      `${baseMaterialLogApiUrl}`, requestData);
  },
  async getInventoryMaterialTickets(lotNumber) {
    return await apiHelpers.sendBaseReadRequest(
      `${baseMaterialLogApiUrl}/${lotNumber}/inventoryMaterialTickets`);
  },
  async getInventoryMaterialTicket(lotNumber, ticketId) {
    return await apiHelpers.sendBaseReadRequest(
      `${baseMaterialLogApiUrl}/${lotNumber}/inventoryMaterialTickets/${ticketId}`);
  },
  async createInventoryMaterialTicket(lotNumber, requestData) {
    return await apiHelpers.sendBaseWriteRequest('post',
      `${baseMaterialLogApiUrl}/${lotNumber}/inventoryMaterialTickets`, requestData);
  },
}