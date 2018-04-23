using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraPivotGrid;
using DevExpress.Xpf.PivotGrid;
using DevExpress.Core;

namespace PivotLayoutLoader {
    public static class PivotLayoutConverter {
        public static FieldListStyle ToFieldListStyle(this DevExpress.XtraPivotGrid.Customization.CustomizationFormStyle value) {
            return (FieldListStyle)value;
        }
        public static FieldListLayout ToFieldListLayout(this DevExpress.XtraPivotGrid.Customization.CustomizationFormLayout value) {
            return (FieldListLayout)value;
        }
        public static void RestoreWinLayoutFromXml(this DevExpress.Xpf.PivotGrid.PivotGridControl xpfPivot, string layoutFileName) {
            DevExpress.XtraPivotGrid.PivotGridControl winPivot = new DevExpress.XtraPivotGrid.PivotGridControl();            
            winPivot.OptionsLayout.Columns.RemoveOldColumns = false;
            winPivot.RestoreLayoutFromXml(layoutFileName);
            xpfPivot.BeginInit();
            CopyFields(winPivot, xpfPivot);
            // XPF properties
            xpfPivot.OlapConnectionString = winPivot.OLAPConnectionString;
            xpfPivot.PrefilterCriteria = winPivot.Prefilter.Criteria;
            xpfPivot.IsPrefilterEnabled = winPivot.Prefilter.Enabled;
            xpfPivot.ShowDataHeaders = winPivot.OptionsView.ShowDataHeaders;
            // OptionsData            
            xpfPivot.AllowCrossGroupVariation = winPivot.OptionsData.AllowCrossGroupVariation;
            xpfPivot.GroupDataCaseSensitive = winPivot.OptionsData.CaseSensitive;
            xpfPivot.DrillDownMaxRowCount = winPivot.OptionsData.DrillDownMaxRowCount;
            //OptionsCustomization
            xpfPivot.FieldListStyle = winPivot.OptionsCustomization.CustomizationFormStyle.ToFieldListStyle();
            xpfPivot.FieldListLayout = winPivot.OptionsCustomization.CustomizationFormLayout.ToFieldListLayout();
            xpfPivot.DeferredUpdates = winPivot.OptionsCustomization.DeferredUpdates;
            xpfPivot.AllowPrefilter = winPivot.OptionsCustomization.AllowPrefilter;
            xpfPivot.AllowHideFields = winPivot.OptionsCustomization.AllowHideFields.ToAllowHideFieldsType();
            // OptionsView
            xpfPivot.DrawFocusedCellRect = winPivot.OptionsView.DrawFocusedCellRect;
            xpfPivot.ShowColumnGrandTotals = winPivot.OptionsView.ShowColumnGrandTotals;
            xpfPivot.ShowColumnHeaders = winPivot.OptionsView.ShowColumnHeaders;
            xpfPivot.ShowColumnTotals = winPivot.OptionsView.ShowColumnTotals;
            xpfPivot.ShowCustomTotalsForSingleValues = winPivot.OptionsView.ShowCustomTotalsForSingleValues;
            xpfPivot.ShowDataHeaders = winPivot.OptionsView.ShowDataHeaders;
            xpfPivot.ShowFilterHeaders = winPivot.OptionsView.ShowFilterHeaders;
            xpfPivot.ShowGrandTotalsForSingleValues = winPivot.OptionsView.ShowGrandTotalsForSingleValues;
            xpfPivot.ShowRowGrandTotals = winPivot.OptionsView.ShowRowGrandTotals;
            xpfPivot.ShowRowHeaders = winPivot.OptionsView.ShowRowHeaders;
            xpfPivot.ShowRowTotals = winPivot.OptionsView.ShowRowTotals;
            xpfPivot.ShowTotalsForSingleValues = winPivot.OptionsView.ShowTotalsForSingleValues;
            xpfPivot.ColumnTotalsLocation = winPivot.OptionsView.ColumnTotalsLocation.ToFieldTotalsLocationType();
            xpfPivot.RowTotalsLocation = winPivot.OptionsView.RowTotalsLocation.ToFieldTotalsLocationType();
            xpfPivot.RowTreeWidth = winPivot.OptionsView.RowTreeWidth;
            xpfPivot.RowTreeOffset = winPivot.OptionsView.RowTreeOffset;
            // OptionsDataField
            xpfPivot.DataFieldArea = winPivot.OptionsDataField.Area.ToDataFieldAreaType();
            xpfPivot.DataFieldAreaIndex = winPivot.OptionsDataField.AreaIndex;
            xpfPivot.DataFieldWidth = winPivot.OptionsDataField.RowHeaderWidth;
            xpfPivot.DataFieldCaption = winPivot.OptionsDataField.Caption;
            xpfPivot.SummaryDataSourceFieldNaming = winPivot.OptionsDataField.FieldNaming.ToSummaryDataSourceFieldNamingType();
            // OptionsChartDataSource
            xpfPivot.ChartDataVertical = winPivot.OptionsChartDataSource.ChartDataVertical;
            xpfPivot.ChartExportFieldValueMode = winPivot.OptionsChartDataSource.ExportFieldValueMode;
            xpfPivot.ChartSelectionOnly = winPivot.OptionsChartDataSource.SelectionOnly;
            xpfPivot.ChartShowColumnTotals = winPivot.OptionsChartDataSource.ShowColumnTotals;
            xpfPivot.ChartShowColumnGrandTotals = winPivot.OptionsChartDataSource.ShowColumnGrandTotals;
            xpfPivot.ChartShowColumnCustomTotals = winPivot.OptionsChartDataSource.ShowColumnCustomTotals;
            xpfPivot.ChartShowRowTotals = winPivot.OptionsChartDataSource.ShowRowTotals;
            xpfPivot.ChartShowRowGrandTotals = winPivot.OptionsChartDataSource.ShowRowGrandTotals;
            xpfPivot.ChartShowRowCustomTotals = winPivot.OptionsChartDataSource.ShowRowCustomTotals;
            xpfPivot.ChartExportColumnFieldValuesAsType = winPivot.OptionsChartDataSource.ExportColumnFieldValuesAsType;
            xpfPivot.ChartExportRowFieldValuesAsType = winPivot.OptionsChartDataSource.ExportRowFieldValuesAsType;
            xpfPivot.ChartExportCellValuesAsType = winPivot.OptionsChartDataSource.ExportCellValuesAsType;
            // OptionsBehavior
            xpfPivot.CopyToClipboardWithFieldValues = winPivot.OptionsBehavior.CopyToClipboardWithFieldValues;
            // OptionsSelection
            if(!winPivot.OptionsSelection.CellSelection)
                xpfPivot.SelectMode = SelectMode.None;
            else if(winPivot.OptionsSelection.MultiSelect)
                xpfPivot.SelectMode = SelectMode.MultiSelection;
            else
                xpfPivot.SelectMode = SelectMode.SolidSelection;
            // PivotGridCells
            xpfPivot.FocusedCell = winPivot.Cells.FocusedCell;
            xpfPivot.MultiSelection.SetSelection(winPivot.Cells.MultiSelection.SelectedCells.ToArray<System.Drawing.Point>());
            xpfPivot.EndInit();
        }
        static void CopyFields(DevExpress.XtraPivotGrid.PivotGridControl source, DevExpress.Xpf.PivotGrid.PivotGridControl dest) {
            Dictionary<DevExpress.XtraPivotGrid.PivotGridFieldBase, DevExpress.Xpf.PivotGrid.PivotGridField> fields = new Dictionary<DevExpress.XtraPivotGrid.PivotGridFieldBase, DevExpress.Xpf.PivotGrid.PivotGridField>();
            DevExpress.Xpf.PivotGrid.PivotGridField xpfField;
            foreach(DevExpress.XtraPivotGrid.PivotGridField winField in source.Fields) {
                xpfField = dest.Fields.Add();
                fields.Add(winField, xpfField);
                xpfField.MinWidth = winField.MinWidth;
                xpfField.AllowedAreas = winField.AllowedAreas.ToFieldAllowedAreas();
                xpfField.Area = winField.Area.ToFieldArea();
                xpfField.AreaIndex = winField.AreaIndex;
                xpfField.Caption = winField.Caption;
                xpfField.ExpandedInFieldsGroup = winField.ExpandedInFieldsGroup;
                xpfField.EmptyCellText = winField.EmptyCellText;
                xpfField.EmptyValueText = winField.EmptyValueText;
                xpfField.FieldName = winField.FieldName;
                xpfField.GrandTotalText = winField.GrandTotalText;
                xpfField.GroupInterval = winField.GroupInterval.ToFieldGroupInterval();
                xpfField.GroupIntervalNumericRange = winField.GroupIntervalNumericRange;
                xpfField.RunningTotal = winField.RunningTotal;
                xpfField.SortMode = winField.SortMode.ToFieldSortMode();
                xpfField.SortOrder = winField.SortOrder.ToFieldSortOrder();
                xpfField.SummaryType = winField.SummaryType.ToFieldSummaryType();
                xpfField.SummaryDisplayType = winField.SummaryDisplayType.ToFieldSummaryDisplayType();
                xpfField.TopValueCount = winField.TopValueCount;
                xpfField.TopValueShowOthers = winField.TopValueShowOthers;
                xpfField.TopValueType = winField.TopValueType.ToFieldTopValueType();
                xpfField.TotalsVisibility = winField.TotalsVisibility.ToFieldTotalsVisibility();
                xpfField.UnboundType = winField.UnboundType.ToFieldUnboundColumnType();
                xpfField.UnboundExpression = winField.UnboundExpression;
                xpfField.UnboundFieldName = winField.UnboundFieldName;
                xpfField.UseNativeFormat = winField.UseNativeFormat.ToBool();
                xpfField.Visible = winField.Visible;
                // Options
                xpfField.AllowSort = winField.Options.AllowSort.ToBool();
                xpfField.AllowFilter = winField.Options.AllowFilter.ToBool();
                xpfField.AllowDrag = winField.Options.AllowDrag.ToBool();
                xpfField.AllowExpand = winField.Options.AllowExpand.ToBool();
                xpfField.AllowSortBySummary = winField.Options.AllowSortBySummary.ToBool();
                xpfField.AllowUnboundExpressionEditor = winField.Options.ShowUnboundExpressionMenu;
                xpfField.ShowInCustomizationForm = winField.Options.ShowInCustomizationForm;
                xpfField.ShowGrandTotal = winField.Options.ShowGrandTotal;
                xpfField.ShowTotals = winField.Options.ShowTotals;
                xpfField.ShowValues = winField.Options.ShowValues;
                xpfField.ShowCustomTotals = winField.Options.ShowCustomTotals;
                xpfField.ShowSummaryTypeName = winField.Options.ShowSummaryTypeName;
                xpfField.HideEmptyVariationItems = winField.Options.HideEmptyVariationItems;
                xpfField.OlapFilterUsingWhereClause = winField.Options.OLAPFilterUsingWhereClause;
                // SortBySummaryInfo
                xpfField.SortByFieldName = winField.SortBySummaryInfo.FieldName;
                xpfField.SortBySummaryType = winField.SortBySummaryInfo.SummaryType.ToFieldSummaryType();
                xpfField.CellFormat = winField.CellFormat.FormatString;
                xpfField.GrandTotalCellFormat = winField.GrandTotalCellFormat.FormatString;
                xpfField.TotalCellFormat = winField.TotalCellFormat.FormatString;
                xpfField.TotalValueFormat = winField.TotalValueFormat.FormatString;
                xpfField.ValueFormat = winField.ValueFormat.FormatString;
            }
            DevExpress.XtraPivotGrid.PivotGridField winSourceField;
            for(int i = 0; i < source.Fields.Count; i++) {
                winSourceField = source.Fields[i];
                xpfField = dest.Fields[i];
                // Group
                if(winSourceField.Group != null) {
                    if(xpfField.Group == null)
                        xpfField.Group = new DevExpress.Xpf.PivotGrid.PivotGridGroup();
                    foreach(DevExpress.XtraPivotGrid.PivotGridFieldBase winFieldBase in winSourceField.Group) {
                        if(fields.ContainsKey(winFieldBase))
                            xpfField.Group.Add(fields[winFieldBase]);
                    }
                    xpfField.GroupIndex = winSourceField.InnerGroupIndex;
                }
                // SortBySummaryInfo
                if(winSourceField.SortBySummaryInfo.Field != null && fields.ContainsKey(winSourceField.SortBySummaryInfo.Field))
                    xpfField.SortByField = fields[winSourceField.SortBySummaryInfo.Field];
            }
        }
    }
}
