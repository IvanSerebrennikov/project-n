import Vue from 'vue'
import Vuex from 'vuex'
import materialLogModule from './modules/materialLogModule'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    materialLogModule
  }
})
