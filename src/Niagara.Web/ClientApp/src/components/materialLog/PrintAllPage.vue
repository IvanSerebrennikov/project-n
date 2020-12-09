<template>
  <div>
    All. {{ materialLog.defaultProperties.description }}
  </div>
</template>

<script>
  export default {
    props: {
      materialLog: Object
    }
  }
</script>