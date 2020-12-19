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

const sendBaseReadRequest = async (url) => {
  const response = await axios.get(url);
  return response.data;
}

const sendBaseWriteRequest = async (method, url, requestData) => {
  try {
    const response = await axios[method](url, requestData);
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

export default {
  getAxiosErrorMessage,
  sendBaseReadRequest,
  sendBaseWriteRequest
}