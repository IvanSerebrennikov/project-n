const PrintElement = {
  install (Vue, options = {}) {
    Vue.prototype.$printElement = (elementId) => {
      const htmlToPrint = window.document.getElementById(elementId).innerHTML;

      const windowToPrint = window.open('', '', 'fullscreen=1,toolbar=0,scrollbars=1,status=0');

      windowToPrint.document.write(`
        <!DOCTYPE html>
        <html>
          <body>
            ${htmlToPrint}
          </body>
        </html>
      `);

      setTimeout(() => {
        windowToPrint.document.close();
        windowToPrint.focus();
        windowToPrint.print();
        windowToPrint.close();
      }, 1000);
      
      return true;
    };
  }
}

export default PrintElement;