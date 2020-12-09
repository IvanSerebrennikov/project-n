import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import axios from 'axios'
import VueAxios from 'vue-axios'
import vuetify from './plugins/vuetify';
import PrintElement from './plugins/print-element';

Vue.config.productionTip = false

Vue.use(VueAxios, axios)
Vue.use(PrintElement)

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
