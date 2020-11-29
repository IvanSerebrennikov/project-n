<template>
  <v-app>
    <v-app-bar
      app
      color="white"
      flat
    >
      <v-container class="py-0 fill-height">
        <v-btn>
          <router-link to="/">Home</router-link>
        </v-btn>

        <v-spacer></v-spacer>

      </v-container>
    </v-app-bar>

    <v-main class="grey lighten-3">
      <v-container>
        <v-row>
          <v-col cols="2">
            <v-sheet rounded="lg">
              <v-list color="transparent">
                <v-list-item>
                  <v-list-item-content>
                    <v-list-item-title>
                      <router-link to="/">Home</router-link>
                    </v-list-item-title>
                  </v-list-item-content>
                </v-list-item>
                <v-list-item>
                  <v-list-item-content>
                    <v-list-item-title>
                      <router-link to="/about">About</router-link>
                    </v-list-item-title>
                  </v-list-item-content>
                </v-list-item>
                <v-list-item>
                  <v-list-item-content>
                    <v-list-item-title>
                      <router-link to="/material-logs">Material Logs</router-link>
                    </v-list-item-title>
                  </v-list-item-content>
                </v-list-item>

                <v-divider class="my-2"></v-divider>

                <v-list-item
                  link
                  color="grey lighten-4"
                >
                  <v-list-item-content>
                    <v-list-item-title>
                      ...
                    </v-list-item-title>
                  </v-list-item-content>
                </v-list-item>
              </v-list>
            </v-sheet>
          </v-col>

          <v-col>
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
  </v-app>
</template>

<script>
import SimpleModalDialog from './components/SimpleModalDialog';

export default {
  name: 'App',

  components: {
    SimpleModalDialog
  },

  data: () => ({
    //
  }),
  mounted() {
    this.$root.$simpleDialog = this.$refs.simpleDialog
  }
};
</script>
