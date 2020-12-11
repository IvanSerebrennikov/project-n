<template>
  <div>
    <table>
      <tbody>
        <tr>
          <td style="text-align: right;">
            Lot #:
          </td>
          <td colspan="3" style="font-weight: bold;">
            {{ materialLog.defaultProperties.lotNumber }}
          </td>
        </tr>
        <tr>
          <td style="text-align: right;">
            Part #:
          </td>
          <td colspan="3">
            {{ partNumberValue }}
          </td>
        </tr>
        <tr>
          <td style="text-align: right;">
            Description:
          </td>
          <td colspan="3">
            {{ materialLog.defaultProperties.description }}
          </td>
        </tr>
        <tr>
          <td style="text-align: right;">
            PO #:
          </td>
          <td style="padding-right: 20px;">
            {{ materialLog.defaultProperties.poNumber }}
          </td>
          <td style="text-align: right;">
            Qty Recvd:
          </td>
          <td>
            {{ materialLog.defaultProperties.quantity }}
          </td>
        </tr>
        <tr>
          <td style="text-align: right;">
            MRT #:
          </td>
          <td style="padding-right: 20px;">
            {{ materialLog.defaultProperties.mrtNumber }}
          </td>
          <td style="text-align: right;">
            U/M:
          </td>
          <td>
            {{ unitOfMeasureValue }}
          </td>
        </tr>
        <tr>
          <td style="text-align: right;">
            Status:
          </td>
          <td style="padding-right: 20px;">
            Accepted
          </td>
          <td style="text-align: right;">
            Magnet Type:
          </td>
          <td>
            {{ materialLogTypeValue }}
          </td>
        </tr>
        <tr>
          <td style="text-align: right;">
            Inspect By:
          </td>
          <td style="padding-right: 20px;">
            {{ materialLog.defaultProperties.createdBy }}
          </td>
          <td style="text-align: right;">
            Date:
          </td>
          <td>
            {{ materialLog.defaultProperties.dateCreated }}
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
  export default {
    props: {
      materialLog: Object,
      partNumberValue: String,
      unitOfMeasures: Array,
      materialLogTypes: Array
    },
    computed: {
      unitOfMeasureValue: function() {
        const vm = this;

        let selectedUnitOfMeasure = vm.unitOfMeasures.find(function(unitOfMeasure) {
          return unitOfMeasure.id == vm.materialLog.defaultProperties.unitOfMeasureId;
        });

        if (!selectedUnitOfMeasure)
          return "";

        return selectedUnitOfMeasure.value;
      },
      materialLogTypeValue: function() {
        const vm = this;

        let selectedMaterialLogType = vm.materialLogTypes.find(function(materialLogType) {
          return materialLogType.id == vm.materialLog.defaultProperties.materialLogTypeId;
        });

        if (!selectedMaterialLogType)
          return "";

        return selectedMaterialLogType.value;
      }
    }
  }
</script>