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
    path: '/material-logs/:lotNumber',
    name: 'MaterialLog',
    component: () => import('../views/MaterialLog.vue'),
    props: true
  },
  {
    path: '/material-logs/:lotNumber/inventory-tickets',
    name: 'InventoryTicketsList',
    component: () => import('../views/InventoryTicketsList.vue'),
    props: true
  },
  {
    path: '/material-logs/:lotNumber/inventory-tickets/:ticketId',
    name: 'InventoryTicket',
    component: () => import('../views/InventoryTicket.vue'),
    props: true
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
