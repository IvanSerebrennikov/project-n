<template>
  <div>
    <v-container>
      <v-row class="mb-6">
        <v-col cols="12" lg="6">
          <v-form>
            <v-container>
              <v-row>
                <v-col>
                  <v-text-field
                    label="Lot #"
                  ></v-text-field>
                </v-col>
                <v-col>
                  <v-text-field
                    label="Part #"
                  ></v-text-field>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-text-field
                    label="PO #"
                  ></v-text-field>
                </v-col>
                <v-col>
                  <v-text-field
                    label="Type"
                  ></v-text-field>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-text-field
                    label="Available"
                  ></v-text-field>
                </v-col>
                <v-col>
                  <v-text-field
                    label="DFARS"
                  ></v-text-field>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-text-field
                    label="Supplier Material Grade"
                  ></v-text-field>
                </v-col>
                <v-col>
                  <v-text-field
                    label="MRT #"
                  ></v-text-field>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-text-field
                    label="Supplier"
                  ></v-text-field>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-text-field
                    label="Description"
                  ></v-text-field>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-text-field
                    label="Qty"
                  ></v-text-field>
                </v-col>
                <v-col>
                  <v-text-field
                    label="Primary Location"
                  ></v-text-field>
                </v-col>
              </v-row>
              <v-row>
                <v-col>
                  <v-text-field
                    label="Date Created"
                  ></v-text-field>
                </v-col>
                <v-col>
                  <v-text-field
                    label="Created By"
                  ></v-text-field>
                </v-col>
              </v-row>
              <v-row>
                <v-col cols="6">
                  <v-text-field
                    label="U/M"
                  ></v-text-field>
                </v-col>
              </v-row>
            </v-container>
          </v-form>
        </v-col>
        <v-col cols="12" lg="6">
          <v-form>
            <v-container>
              <v-row>
                <v-col cols="6">
                  <v-select
                    v-model="selectedMagnetOption"
                    :items="magnetOptions"
                    label="Magnet"
                  ></v-select>
                </v-col>
              </v-row>
              <template v-if="isMagnet">
                <v-row>
                  <v-col>
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
                              hint="MGOe"
                              persistent-hint
                            ></v-text-field>
                          </v-col>
                          <v-col>
                            <v-text-field
                              label="Hci"
                              hint="kOe"
                              persistent-hint
                            ></v-text-field>
                          </v-col>
                        </v-row>
                        <v-row>
                          <v-col>
                            <v-text-field
                              label="Br"
                              hint="kG"
                              persistent-hint
                            ></v-text-field>
                          </v-col>
                          <v-col>
                            <v-text-field
                              label="Hc"
                              hint="kOe"
                              persistent-hint
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
                            <v-text-field
                              label="Shape"
                            ></v-text-field>
                          </v-col>
                        </v-row>
                        <v-row>
                          <v-col cols="4">
                            <v-text-field
                              label="Dim1"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <v-text-field
                              label="Dim2"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <v-text-field
                              label="DimLm"
                            ></v-text-field>
                          </v-col>
                        </v-row>
                      </v-card-text>
                    </v-card>
                  </v-col>
                </v-row>
              </template>
              <template v-else>
                <v-row>
                  <v-col>
                    <v-card
                      elevation="2"
                    >
                      <v-card-title>
                        Specifications
                      </v-card-title>
                      <v-card-text>
                        <v-text-field
                          label="Material Complies to"
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
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <v-text-field
                              label="FT 1"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <v-text-field
                              label="Total FT"
                            ></v-text-field>
                          </v-col>
                        </v-row>
                        <v-row>
                          <v-col cols="4">
                            <v-text-field
                              label="Bars 2"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <v-text-field
                              label="FT 2"
                            ></v-text-field>
                          </v-col>
                        </v-row>
                        <v-row>
                          <v-col cols="4">
                            <v-text-field
                              label="Bars 3"
                            ></v-text-field>
                          </v-col>
                          <v-col cols="4">
                            <v-text-field
                              label="FT 3"
                            ></v-text-field>
                          </v-col>
                        </v-row>
                      </v-card-text>
                    </v-card>
                  </v-col>
                </v-row>
              </template>
            </v-container>
          </v-form>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
export default {
  name: 'MaterialLog',
  props: ['lotNumber'],
  data: function() {
    return {
      materialLog: {},
      magnetOptions: ['Yes', 'No'],
      selectedMagnetOption: 'Yes' // temp
    }
  },
  mounted: function() {
    console.log(this.lotNumber);
    this.axios.get(`/api/MaterialLog/${this.lotNumber}`).then((response) => {
      this.materialLog = response.data;
    });
  },
  computed: {
    isMagnet: function() {
      return this.selectedMagnetOption == 'Yes';
    }
  }
}
</script>