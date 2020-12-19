<template>
  <div>
    <v-row>
      <v-col class="pt-0">
        <v-card
          elevation="2"
        >
          <v-card-title>
            Magnetic Properties
          </v-card-title>
          <v-card-text>
            <v-row>
              <v-col>
                <v-text-field
                  label="BHmax"
                  suffix="MGOe"
                  type="number"
                  :readonly="!editMode"
                  v-model="magneticProperties.bHmax"
                ></v-text-field>
              </v-col>
              <v-col>
                <v-text-field
                  label="Hci"
                  suffix="kOe"
                  type="number"
                  :readonly="!editMode"
                  v-model="magneticProperties.hci"
                ></v-text-field>
              </v-col>
            </v-row>
            <v-row>
              <v-col>
                <v-text-field
                  label="Br"
                  suffix="kG"
                  type="number"
                  :readonly="!editMode"
                  v-model="magneticProperties.br"
                ></v-text-field>
              </v-col>
              <v-col>
                <v-text-field
                  label="Hc"
                  suffix="kOe"
                  type="number"
                  :readonly="!editMode"
                  v-model="magneticProperties.hc"
                ></v-text-field>
              </v-col>
            </v-row>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <v-card
          elevation="2"
        >
          <v-card-title>
            Dimensions
          </v-card-title>
          <v-card-text>
            <v-row>
              <v-col cols="8">
                <v-select
                  v-model="dimensions.shapeId"
                  :items="selectableOptions.shapes"
                  item-text="value"
                  item-value="id"
                  :readonly="!editMode"
                  @change="shapeChanged"
                  label="Shape"
                ></v-select>
              </v-col>
            </v-row>
            <v-row>
              <v-col cols="4">
                <v-text-field
                  label="Dim1"
                  type="number"
                  :readonly="!editMode"
                  v-model="dimensions.dim1"
                ></v-text-field>
              </v-col>
              <v-col cols="4">
                <v-text-field
                  label="Dim2"
                  type="number"
                  :readonly="!editMode"
                  v-model="dimensions.dim2"
                ></v-text-field>
              </v-col>
              <v-col cols="4">
                <v-text-field
                  label="DimLm"
                  type="number"
                  :readonly="!editMode"
                  v-model="dimensions.dimLm"
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
  name: 'MagneticProperties',
  props: {
    materialLogModel: Object
  },
  computed: {
    magneticProperties() {
      const vm = this.materialLogModel;
      return vm.materialLog.magneticProperties;
    },
    dimensions() {
      const vm = this.materialLogModel;
      return vm.materialLog.dimensions;
    },
    selectableOptions() {
      const vm = this.materialLogModel;
      return vm.selectableOptions;
    },
    editMode() {
      const vm = this.materialLogModel;
      return vm.editMode;
    }
  },
  methods: {
    shapeChanged: function(selectedValue) {
      this.dimensions.dim1 = null;
      this.dimensions.dim2 = null;
      this.dimensions.dimLm = null;
    }
  }
}
</script>