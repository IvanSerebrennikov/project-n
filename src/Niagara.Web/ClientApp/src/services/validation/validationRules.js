export default {
  required(value) {
    if (value === null || value === undefined || !value.toString().trim()) {
      return 'Required.'
    }
    return true;
  }
}