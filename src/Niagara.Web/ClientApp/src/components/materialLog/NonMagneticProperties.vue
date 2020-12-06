<template>
  <div>
    <v-row>
      <v-col class="pt-0">
        <v-card
          elevation="2"
        >
          <v-card-title>
            Specifications
          </v-card-title>
          <v-card-text>
            <v-text-field
              label="Material Complies to"
              :readonly="!editMode"
              v-model="specifications.materialCompliesTo"
            ></v-text-field>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <v-card
          elevation="2"
        >
          <v-card-text>
            <v-row>
              <v-col cols="4">
                <v-text-field
                  label="Bars 1"
                  type="number"
                  :readonly="!editMode"
                  v-model="bars.bars1"
                ></v-text-field>
              </v-col>
              <v-col cols="4">
                <v-text-field
                  label="FT 1"
                  type="number"
                  :readonly="!editMode"
                  v-model="bars.fT1"
                ></v-text-field>
              </v-col>
              <v-col cols="4">
                <v-text-field
                  label="Total FT"
                  type="number"
                  :readonly="!editMode"
                  v-model="bars.totalFT"
                ></v-text-field>
              </v-col>
            </v-row>
            <v-row>
              <v-col cols="4">
                <v-text-field
                  label="Bars 2"
                  type="number"
                  :readonly="!editMode"
                  v-model="bars.bars2"
                ></v-text-field>
              </v-col>
              <v-col cols="4">
                <v-text-field
                  label="FT 2"
                  type="number"
                  :readonly="!editMode"
                  v-model="bars.fT2"
                ></v-text-field>
              </v-col>
            </v-row>
            <v-row>
              <v-col cols="4">
                <v-text-field
                  label="Bars 3"
                  type="number"
                  :readonly="!editMode"
                  v-model="bars.bars3"
                ></v-text-field>
              </v-col>
              <v-col cols="4">
                <v-text-field
                  label="FT 3"
                  type="number"
                  :readonly="!editMode"
                  v-model="bars.fT3"
                ></v-text-field>
              </v-col>
            </v-row>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </div>
</template>

<script>
  export default {
    name: 'NonMagneticProperties',
    props: {
      specifications: Object,
      bars: Object,
      editMode: Boolean
    }
  }
</script>