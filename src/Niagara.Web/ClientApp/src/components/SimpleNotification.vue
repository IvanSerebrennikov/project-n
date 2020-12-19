<template>
  <v-snackbar
    v-model="showSimpleNotification"
    :timeout="options.timeout"
    :color="options.color"
    :bottom="options.bottom"
    :left="options.left"
    :top="options.top"
    :right="options.right"
  >
    <div :style="{ width: options.width + 'px' }">
      {{ message }}
    </div>

    <template v-slot:action="{ attrs }">
      <v-icon
        v-bind="attrs"
        @click="showSimpleNotification = false"
      >
        mdi-close-circle
      </v-icon>
    </template>
  </v-snackbar>
</template>

<script>
export default {
  name: 'SimpleNotification',
  data: () => ({
    showSimpleNotification: false,
    message: null,
    options: {
      timeout: 4000,
      color: null,
      bottom: false,
      left: false,
      top: true,
      right: true,
      width: 300
    }
  }),
  methods: {
    showSuccess(message, options) {
      this.showSimpleNotification = true;
      this.message = message;
      options = options || {};
      options.color = 'success';
      this.options = Object.assign(this.options, options);
    }
  }
}
</script>