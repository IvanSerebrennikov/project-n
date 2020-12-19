<template>
  <v-expansion-panels>
    <v-expansion-panel
      @change="notesExpanded = !notesExpanded"
    >
      <v-expansion-panel-header>
        <v-row no-gutters>
          <v-col>
            <strong class="text-uppercase grey--text text--darken-1">
              <v-icon left>
                mdi-notebook-edit
              </v-icon>
              Notes
            </strong>
          </v-col>
        </v-row>
      </v-expansion-panel-header>
      <v-expansion-panel-content>
        <v-fab-transition>
          <v-btn
            v-show="notesExpanded && editMode"
            @click="addNoteDialog = true"
            color="success"
            fab
            dark
            small
            absolute
            top
            left
          >
            <v-icon>mdi-plus</v-icon>
          </v-btn>
        </v-fab-transition>
        <v-dialog
          v-model="addNoteDialog"
          width="500"
        >
          <v-card>
            <v-card-title class="headline">
              Add new Note
            </v-card-title>
            <v-card-text>
              <v-textarea
                outlined
                v-model="newNoteText"
                label="Note"
              ></v-textarea>
            </v-card-text>
            <v-divider></v-divider>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                color="primary"
                class="pr-3"
                @click="addNoteDialog = false"
              >
                <v-icon left>
                  mdi-close-circle
                </v-icon>
                Cancel
              </v-btn>
              <v-btn
                color="success"
                class="pr-3"
                @click="addNote"
              >
                <v-icon left>
                  mdi-notebook-check
                </v-icon>
                Add
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
        <v-simple-table dense>
          <template>
            <thead>
              <tr>
                <th class="text-left">
                  Date
                </th>
                <th class="text-left">
                  Time
                </th>
                <th class="text-left">
                  Author
                </th>
                <th class="text-left" colspan="2">
                  Note
                </th>
              </tr>
            </thead>
            <tbody>
              <tr
                v-for="(note, index) in notes"
                :key="note.id"
              >
                <template v-if="note.dateCreated">
                  <td>{{ note.dateCreated }}</td>
                  <td>{{ note.timeCreated }}</td>
                  <td>{{ note.createdBy }}</td>
                  <td colspan="2">{{ note.text }}</td>
                </template>
                <template v-else>
                  <td colspan="3">
                    <span class="grey--text text--darken-1">
                      Save Material Log to receive date, time and author...
                    </span>
                  </td>
                  <td>{{ note.text }}</td>
                  <td style="width: 56px;">
                    <v-icon
                      @click="deleteNewNote(index)"
                    >
                      mdi-delete
                    </v-icon>
                  </td>
                </template>
              </tr>
            </tbody>
          </template>
        </v-simple-table>
      </v-expansion-panel-content>
    </v-expansion-panel>
  </v-expansion-panels>
</template>

<script>
export default {
  name: 'MaterialLogNotes',
  props: {
    materialLogModel: Object,
    validationRules: Object
  },
  data() {
    return {
      notesExpanded: false,
      addNoteDialog: false,
      newNoteText: null
    }
  },
  computed: {
    notes() {
      const vm = this.materialLogModel;
      return vm.notes;
    },
    newNotes() {
      const vm = this.materialLogModel;
      return vm.newNotes;
    },
    editMode() {
      const vm = this.materialLogModel;
      return vm.editMode;
    }
  },
  methods: {
    addNote: function() {
      if (this.validationRules.required(this.newNoteText) !== true)
        return;

      this.newNotes.unshift(this.newNoteText);
      this.notes.unshift({
        text: this.newNoteText
      });

      this.addNoteDialog = false;
      this.newNoteText = null;
    },
    deleteNewNote: function(index) {
      this.newNotes.splice(index, 1);
      this.notes.splice(index, 1);
    },
  }
}
</script>