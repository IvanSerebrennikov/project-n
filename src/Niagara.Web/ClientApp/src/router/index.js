import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  },
  {
    path: '/material-logs',
    name: 'MaterialLogsList',
    component: () => import('../views/MaterialLogsList.vue')
  },
  {
    path: '/material-log/:lotNumber',
    name: 'MaterialLog',
    component: () => import('../views/MaterialLog.vue'),
    props: true
  },
  {
    path: '/inventory-tickets/:lotNumber',
    name: 'InventoryTicketsList',
    component: () => import('../views/InventoryTicketsList.vue'),
    props: true
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
