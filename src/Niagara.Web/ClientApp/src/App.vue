<template>
  <v-app>
    <v-app-bar
      app
      color="white"
      flat
    >
      <v-container :style="{ maxWidth: maxContainerWidth }" class="py-0 fill-height">
        <v-btn
          depressed
          @click="goTo('Home')"
        >
          Home
        </v-btn>

        <v-spacer></v-spacer>

      </v-container>
    </v-app-bar>

    <v-main class="grey lighten-3">
      <v-container :style="{ maxWidth: maxContainerWidth }">
        <v-row>
          <v-col cols="12" xl="2" lg="2" md="2" sm="3">
            <v-sheet rounded="lg">
              <v-list color="transparent">
                <v-list-item link @click="goTo('Home')">
                  <v-list-item-content>
                    <v-list-item-title>
                      Home
                    </v-list-item-title>
                  </v-list-item-content>
                </v-list-item>
                <v-list-item link @click="goTo('About')">
                  <v-list-item-content>
                    <v-list-item-title>
                      About
                    </v-list-item-title>
                  </v-list-item-content>
                </v-list-item>
                <v-list-item link @click="goTo('MaterialLogsList')">
                  <v-list-item-content>
                    <v-list-item-title>
                      Material Logs
                    </v-list-item-title>
                  </v-list-item-content>
                </v-list-item>

                <v-divider class="my-2"></v-divider>

                <v-list-item link>
                  <v-list-item-content>
                    <v-list-item-title>
                      ...
                    </v-list-item-title>
                  </v-list-item-content>
                </v-list-item>
              </v-list>
            </v-sheet>
          </v-col>

          <v-col cols="12" xl="10" lg="10" md="10" sm="9">
            <v-sheet
              min-height="70vh"
              rounded="lg"
            >
              <router-view/>
            </v-sheet>
          </v-col>
        </v-row>
      </v-container>
    </v-main>
    <SimpleModalDialog ref="simpleDialog"></SimpleModalDialog>
    <SimpleNotification ref="simpleNotification"></SimpleNotification>
  </v-app>
</template>

<script>
import SimpleModalDialog from './components/SimpleModalDialog';
import SimpleNotification from './components/SimpleNotification';

export default {
  name: 'App',

  components: {
    SimpleModalDialog,
    SimpleNotification
  },

  data: () => ({
    //
  }),
  methods: {
    goTo(routeName) {
      if (this.$route.name == routeName)
        return;

      this.$router.push({ name: routeName });
    }
  },
  computed: {
    maxContainerWidth() {
      return this.$vuetify.breakpoint.thresholds.lg + 'px';
    }
  },
  mounted() {
    this.$root.$simpleDialog = this.$refs.simpleDialog
    this.$root.$simpleNotification = this.$refs.simpleNotification
  }
};
</script>
