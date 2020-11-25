<template>
  <div class="material-log">
    
  </div>
</template>

<script>
export default {
  name: 'MaterialLog',
  props: ['lotNumber'],
  data: function() {
    return {}
  },
  mounted: function() {
    console.log(this.lotNumber);
  }
}
</script>