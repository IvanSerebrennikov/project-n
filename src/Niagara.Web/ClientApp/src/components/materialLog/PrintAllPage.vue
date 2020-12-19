<template>
  <div>
    <table>
      <tbody style="vertical-align: top;">
        <tr>
          <td style="text-align: right; vertical-align: top;">
            Lot #:
          </td>
          <td style="font-weight: bold; padding-right: 20px; width: 170px;">
            {{ materialLog.defaultProperties.lotNumber }}
          </td>
          <td style="text-align: right; vertical-align: top;">
            Part #:
          </td>
          <td>
            {{ partNumberValue }}
          </td>
        </tr>
        <tr>
          <td style="text-align: right; vertical-align: top;">
            Magnet:
          </td>
          <td style="padding-right: 20px;">
            {{ materialLog.isMagnet ? 'Yes' : 'No' }}
          </td>
          <td style="text-align: right; vertical-align: top;">
            Available:
          </td>
          <td>
            {{ materialLog.defaultProperties.isAvailable ? 'Yes' : 'No' }}
          </td>
        </tr>
        <tr>
          <td style="text-align: right; vertical-align: top;">
            Supplier:
          </td>
          <td>
            {{ supplierValue }}
          </td>
          <td></td>
          <td></td>
        </tr>
        <tr>
          <td style="text-align: right; vertical-align: top;">
            PO #:
          </td>
          <td style="padding-right: 20px;">
            {{ materialLog.defaultProperties.poNumber }}
          </td>
          <td style="text-align: right; vertical-align: top;">
            DFARS:
          </td>
          <td>
            {{ materialLog.defaultProperties.isDFARS ? 'Yes' : 'No' }}
          </td>
        </tr>
        <tr>
          <td style="text-align: right; vertical-align: top;">
            Description:
          </td>
          <td>
            {{ materialLog.defaultProperties.description }}
          </td>
          <td></td>
          <td></td>
        </tr>
        <tr>
          <td style="text-align: right; vertical-align: top;">
            Qty:
          </td>
          <td style="padding-right: 20px;">
            {{ materialLog.defaultProperties.quantity }}
          </td>
          <td style="text-align: right; vertical-align: top;">
            Pr. Location:
          </td>
          <td>
            {{ materialLog.defaultProperties.primaryLocation }}
          </td>
        </tr>
        <tr>
          <td style="text-align: right; vertical-align: top;">
            Sup. Material Gr.:
          </td>
          <td style="padding-right: 20px;">
            {{ materialLog.defaultProperties.supplierMaterialGrade }}
          </td>
          <td style="text-align: right; vertical-align: top;">
            MRT #:
          </td>
          <td>
            {{ materialLog.defaultProperties.mrtNumber }}
          </td>
        </tr>
        <tr>
          <td style="text-align: right; vertical-align: top;">
            U/M:
          </td>
          <td style="padding-right: 20px;">
            {{ unitOfMeasureValue }}
          </td>
          <td style="text-align: right; vertical-align: top;">
            Type:
          </td>
          <td>
            {{ materialLogTypeValue }}
          </td>
        </tr>
        <tr>
          <td style="text-align: right; vertical-align: top;">
            Date Created:
          </td>
          <td style="padding-right: 20px;">
            {{ materialLog.defaultProperties.dateCreated }}
          </td>
          <td style="text-align: right; vertical-align: top;">
            Created By:
          </td>
          <td>
            {{ materialLog.defaultProperties.createdBy }}
          </td>
        </tr>
      </tbody>
    </table>
    <div v-if="materialLog.isMagnet" style="padding-left: 50px;">
      <br/>
      <table>
        <caption style="text-align: left; font-weight: bold;">Magnetic Properties</caption>
        <tbody style="vertical-align: top;">
          <tr>
            <td style="text-align: right; vertical-align: top;">
              BHmax:
            </td>
            <td style="padding-right: 20px;">
              {{ materialLog.magneticProperties.bHmax }}
            </td>
            <td style="text-align: right; vertical-align: top;">
              Hci:
            </td>
            <td>
              {{ materialLog.magneticProperties.hci }}
            </td>
          </tr>
          <tr>
            <td style="text-align: right; vertical-align: top;">
              Br:
            </td>
            <td style="padding-right: 20px;">
              {{ materialLog.magneticProperties.br }}
            </td>
            <td style="text-align: right; vertical-align: top;">
              Hc:
            </td>
            <td>
              {{ materialLog.magneticProperties.hc }}
            </td>
          </tr>
        </tbody>
      </table>
      <br/>
      <table>
        <caption style="text-align: left; font-weight: bold;">Dimensions</caption>
        <tbody style="vertical-align: top;">
          <tr>
            <td style="text-align: right; vertical-align: top;">
              Shape:
            </td>
            <td colspan="5">
              {{ shapeValue }}
            </td>
          </tr>
          <tr>
            <td style="text-align: right; vertical-align: top;">
              Dim1:
            </td>
            <td style="padding-right: 10px;">
              {{ materialLog.dimensions.dim1 }}
            </td>
            <td style="text-align: right; vertical-align: top;">
              Dim2:
            </td>
            <td style="padding-right: 10px;">
              {{ materialLog.dimensions.dim2 }}
            </td>
            <td style="text-align: right; vertical-align: top;">
              DimLm:
            </td>
            <td>
              {{ materialLog.dimensions.dimLm }}
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div v-else style="padding-left: 50px;">
      <br/>
      <table>
        <caption style="text-align: left; font-weight: bold;">Specifications</caption>
        <tbody style="vertical-align: top;">
          <tr>
            <td style="text-align: right; vertical-align: top;">
              Material Complies to:
            </td>
            <td>
              {{ materialLog.specifications.materialCompliesTo }}
            </td>
          </tr>
        </tbody>
      </table>
      <br/>
      <table>
        <tbody style="vertical-align: top;">
          <tr>
            <td style="text-align: right; vertical-align: top;">
              Bars 1:
            </td>
            <td style="padding-right: 20px;">
              {{ materialLog.bars.bars1 }}
            </td>
            <td style="text-align: right; vertical-align: top;">
              FT 1:
            </td>
            <td>
              {{ materialLog.bars.fT1 }}
            </td>
          </tr>
          <tr>
            <td style="text-align: right; vertical-align: top;">
              Bars 2:
            </td>
            <td style="padding-right: 20px;">
              {{ materialLog.bars.bars2 }}
            </td>
            <td style="text-align: right; vertical-align: top;">
              FT 2:
            </td>
            <td>
              {{ materialLog.bars.fT2 }}
            </td>
          </tr>
          <tr>
            <td style="text-align: right; vertical-align: top;">
              Bars 3:
            </td>
            <td style="padding-right: 20px;">
              {{ materialLog.bars.bars3 }}
            </td>
            <td style="text-align: right; vertical-align: top;">
              FT 3:
            </td>
            <td>
              {{ materialLog.bars.fT3 }}
            </td>
          </tr>
          <tr>
            <td style="text-align: right; vertical-align: top;">
              Total FT:
            </td>
            <td colspan="3">
              {{ materialLog.bars.totalFT }}
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
  export default {
    props: {
      materialLogModel: Object
    },
    computed: {
      materialLog() {
        const vm = this.materialLogModel;
        return vm.materialLog;
      },
      partNumberValue() {
        const vm = this.materialLogModel;
        return vm.customSelectableValues.partNumber;
      },
      supplierValue() {
        const vm = this.materialLogModel;
        return vm.customSelectableValues.supplier;
      },
      unitOfMeasureValue() {
        const vm = this.materialLogModel;

        let selectedUnitOfMeasure = vm.selectableOptions.unitOfMeasures.find(function(unitOfMeasure) {
          return unitOfMeasure.id == vm.materialLog.defaultProperties.unitOfMeasureId;
        });

        if (!selectedUnitOfMeasure)
          return "";

        return selectedUnitOfMeasure.value;
      },
      materialLogTypeValue() {
        const vm = this.materialLogModel;

        let selectedMaterialLogType = vm.selectableOptions.materialLogTypes.find(function(materialLogType) {
          return materialLogType.id == vm.materialLog.defaultProperties.materialLogTypeId;
        });

        if (!selectedMaterialLogType)
          return "";

        return selectedMaterialLogType.value;
      },
      shapeValue() {
        const vm = this.materialLogModel;

        let selectedShape = vm.selectableOptions.shapes.find(function(shape) {
          return shape.id == vm.materialLog.dimensions.shapeId;
        });

        if (!selectedShape)
          return "";

        return selectedShape.value;
      }
    }
  }
</script>