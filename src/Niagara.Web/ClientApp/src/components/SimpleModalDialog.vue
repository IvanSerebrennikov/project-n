<template>
  <v-dialog
    v-model="showSimpleModalDialog"
    :max-width="options.width"
    :style="{ zIndex: options.zIndex }"
    :persistent="options.isPersistent"
    @keydown.esc="cancel"
  >
    <v-card>
      <v-toolbar :color="options.color" dark dense flat>
        <v-toolbar-title class="white--text">{{ title }}</v-toolbar-title>
      </v-toolbar>
      <v-card-text v-show="!!message" class="pa-4">{{ message }}</v-card-text>
      <v-card-actions class="pt-0">
        <v-spacer></v-spacer>
        <v-btn v-if="options.showOkBtn" @click.native="ok" color="primary darken-1" text>{{options.okBtnText}}</v-btn>
        <v-btn v-if="options.showCancelBtn" @click.native="cancel" color="grey" text>{{options.cancelBtnText}}</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
/**
 * Vuetify Simple Dialog component
 *
 * Call it:
 * this.$root.simpleDialog.showMessage('Delete', 'Are you sure?', { color: 'red' }).then((isOk) => {})
 * Or use await:
 * if (await this.$root.simpleDialog.showMessage('Delete', 'Are you sure?', { color: 'red' })) {
 *   // yes
 * }
 * else {
 *   // cancel
 * }
 *
 */
export default {
  name: 'SimpleModalDialog',
  data: () => ({
    simpleModalDialog: false,
    resolve: null,
    reject: null,
    title: null,
    message: null,
    options: {
      showOkBtn: true,
      okBtnText: 'Ok',
      showCancelBtn: false,
      cancelBtnText: 'Cancel',
      color: 'primary',
      width: 290,
      zIndex: 200,
      isPersistent: false
    }
  }),
  computed: {
    showSimpleModalDialog: {
      get() {
        return this.simpleModalDialog
      },
      set(value) {
        this.simpleModalDialog = value
        if (value === false) {
          this.cancel()
        }
      }
    }
  },
  methods: {
    showMessage(title, message, options) {
      this.simpleModalDialog = true;
      this.title = title;
      this.message = message;
      this.options = Object.assign(this.options, options);
      return new Promise((resolve, reject) => {
        this.resolve = resolve;
        this.reject = reject;
      })
    },
    showError(errorMessage) {
      return this.showMessage('Error', errorMessage, { color: 'red', okBtnText: 'Close' });
    },
    showAxiosError(error) {
      if (error.response) {
        console.log(error.response.data);
        console.log(error.response.status);
        return this.showError(error.response.data);
      } else if (error.request) {
        console.log(error.request);
        return this.showError('Some error occured during request sending');
      } else {
        console.log('Error', error.message);
        return this.showError('Unexpected error occured');
      }
    },
    ok() {
      this.resolve(true);
      this.simpleModalDialog = false;
    },
    cancel() {
      this.resolve(false);
      this.simpleModalDialog = false;
    }
  }
}
</script>