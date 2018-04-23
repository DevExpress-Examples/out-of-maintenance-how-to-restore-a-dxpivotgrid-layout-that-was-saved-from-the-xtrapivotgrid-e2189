Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraPivotGrid
Imports DevExpress.Xpf.PivotGrid
Imports DevExpress.Core
Imports DevExpress.Utils

Namespace PivotLayoutLoader
    Public Module PivotLayoutConverter
        <System.Runtime.CompilerServices.Extension()> _
        Public Function ToFieldListStyle(ByVal value As DevExpress.XtraPivotGrid.Customization.CustomizationFormStyle) As FieldListStyle
            Return CType(value, FieldListStyle)
        End Function
        <System.Runtime.CompilerServices.Extension()> _
        Public Function ToFieldListLayout(ByVal value As DevExpress.XtraPivotGrid.Customization.CustomizationFormLayout) As FieldListLayout
            Return CType(value, FieldListLayout)
        End Function
        <System.Runtime.CompilerServices.Extension()> _
        Public Sub RestoreWinLayoutFromXml(ByVal xpfPivot As DevExpress.Xpf.PivotGrid.PivotGridControl, ByVal layoutFileName As String)
            Dim winPivot As New DevExpress.XtraPivotGrid.PivotGridControl()
            winPivot.OptionsLayout.Columns.RemoveOldColumns = False
            winPivot.RestoreLayoutFromXml(layoutFileName)
            xpfPivot.BeginInit()
            CopyFields(winPivot, xpfPivot)
            ' XPF properties
            xpfPivot.OlapConnectionString = winPivot.OLAPConnectionString
            xpfPivot.PrefilterCriteria = winPivot.Prefilter.Criteria
            xpfPivot.IsPrefilterEnabled = winPivot.Prefilter.Enabled
            xpfPivot.ShowDataHeaders = winPivot.OptionsView.ShowDataHeaders
            ' OptionsData            
            xpfPivot.AllowCrossGroupVariation = winPivot.OptionsData.AllowCrossGroupVariation
            xpfPivot.GroupDataCaseSensitive = winPivot.OptionsData.CaseSensitive
            xpfPivot.DrillDownMaxRowCount = winPivot.OptionsData.DrillDownMaxRowCount
            'OptionsCustomization
            xpfPivot.FieldListStyle = winPivot.OptionsCustomization.CustomizationFormStyle.ToFieldListStyle()
            xpfPivot.FieldListLayout = winPivot.OptionsCustomization.CustomizationFormLayout.ToFieldListLayout()
            xpfPivot.DeferredUpdates = winPivot.OptionsCustomization.DeferredUpdates
            xpfPivot.AllowPrefilter = winPivot.OptionsCustomization.AllowPrefilter
            xpfPivot.AllowHideFields = winPivot.OptionsCustomization.AllowHideFields.ToAllowHideFieldsType()
            ' OptionsView
            xpfPivot.DrawFocusedCellRect = winPivot.OptionsView.DrawFocusedCellRect
            xpfPivot.ShowColumnGrandTotals = winPivot.OptionsView.ShowColumnGrandTotals
            xpfPivot.ShowColumnHeaders = winPivot.OptionsView.ShowColumnHeaders
            xpfPivot.ShowColumnTotals = winPivot.OptionsView.ShowColumnTotals
            xpfPivot.ShowCustomTotalsForSingleValues = winPivot.OptionsView.ShowCustomTotalsForSingleValues
            xpfPivot.ShowDataHeaders = winPivot.OptionsView.ShowDataHeaders
            xpfPivot.ShowFilterHeaders = winPivot.OptionsView.ShowFilterHeaders
            xpfPivot.ShowGrandTotalsForSingleValues = winPivot.OptionsView.ShowGrandTotalsForSingleValues
            xpfPivot.ShowRowGrandTotals = winPivot.OptionsView.ShowRowGrandTotals
            xpfPivot.ShowRowHeaders = winPivot.OptionsView.ShowRowHeaders
            xpfPivot.ShowRowTotals = winPivot.OptionsView.ShowRowTotals
            xpfPivot.ShowTotalsForSingleValues = winPivot.OptionsView.ShowTotalsForSingleValues
            xpfPivot.ColumnTotalsLocation = winPivot.OptionsView.ColumnTotalsLocation.ToFieldTotalsLocationType()
            xpfPivot.RowTotalsLocation = winPivot.OptionsView.RowTotalsLocation.ToFieldTotalsLocationType()
            xpfPivot.RowTreeWidth = winPivot.OptionsView.RowTreeWidth
            xpfPivot.RowTreeOffset = winPivot.OptionsView.RowTreeOffset
            ' OptionsDataField
            xpfPivot.DataFieldArea = winPivot.OptionsDataField.Area.ToDataFieldAreaType()
            xpfPivot.DataFieldAreaIndex = winPivot.OptionsDataField.AreaIndex
            xpfPivot.DataFieldWidth = winPivot.OptionsDataField.RowHeaderWidth
            xpfPivot.DataFieldCaption = winPivot.OptionsDataField.Caption
            xpfPivot.SummaryDataSourceFieldNaming = winPivot.OptionsDataField.FieldNaming.ToSummaryDataSourceFieldNamingType()
            ' OptionsChartDataSource
            xpfPivot.ChartProvideDataByColumns = winPivot.OptionsChartDataSource.ProvideDataByColumns
            xpfPivot.ChartFieldValuesProvideMode = DirectCast(winPivot.OptionsChartDataSource.FieldValuesProvideMode, DevExpress.Xpf.PivotGrid.PivotChartFieldValuesProvideMode)
            xpfPivot.ChartSelectionOnly = winPivot.OptionsChartDataSource.SelectionOnly
            xpfPivot.ChartProvideColumnTotals = winPivot.OptionsChartDataSource.ProvideColumnTotals
            xpfPivot.ChartProvideColumnGrandTotals = winPivot.OptionsChartDataSource.ProvideColumnGrandTotals
            xpfPivot.ChartProvideColumnCustomTotals = winPivot.OptionsChartDataSource.ProvideColumnCustomTotals
            xpfPivot.ChartProvideRowTotals = winPivot.OptionsChartDataSource.ProvideRowTotals
            xpfPivot.ChartProvideRowGrandTotals = winPivot.OptionsChartDataSource.ProvideRowGrandTotals
            xpfPivot.ChartProvideRowCustomTotals = winPivot.OptionsChartDataSource.ProvideRowCustomTotals
            xpfPivot.ChartProvideColumnFieldValuesAsType = winPivot.OptionsChartDataSource.ProvideColumnFieldValuesAsType
            xpfPivot.ChartProvideRowFieldValuesAsType = winPivot.OptionsChartDataSource.ProvideRowFieldValuesAsType
            xpfPivot.ChartProvideCellValuesAsType = winPivot.OptionsChartDataSource.ProvideCellValuesAsType
            ' OptionsBehavior
            xpfPivot.CopyToClipboardWithFieldValues = winPivot.OptionsBehavior.CopyToClipboardWithFieldValues
            ' OptionsSelection
            If (Not winPivot.OptionsSelection.CellSelection) Then
                xpfPivot.SelectMode = SelectMode.None
            ElseIf winPivot.OptionsSelection.MultiSelect Then
                xpfPivot.SelectMode = SelectMode.MultiSelection
            Else
                xpfPivot.SelectMode = SelectMode.SolidSelection
            End If
            ' PivotGridCells
            xpfPivot.FocusedCell = winPivot.Cells.FocusedCell
            xpfPivot.MultiSelection.SetSelection(winPivot.Cells.MultiSelection.SelectedCells.ToArray())
            xpfPivot.EndInit()
        End Sub
        Private Sub CopyFields(ByVal source As DevExpress.XtraPivotGrid.PivotGridControl, ByVal dest As DevExpress.Xpf.PivotGrid.PivotGridControl)
            Dim fields As New Dictionary(Of DevExpress.XtraPivotGrid.PivotGridFieldBase, DevExpress.Xpf.PivotGrid.PivotGridField)()
            Dim xpfField As DevExpress.Xpf.PivotGrid.PivotGridField
            For Each winField As DevExpress.XtraPivotGrid.PivotGridField In source.Fields
                xpfField = dest.Fields.Add()
                fields.Add(winField, xpfField)
                xpfField.MinWidth = winField.MinWidth
                xpfField.AllowedAreas = winField.AllowedAreas.ToFieldAllowedAreas()
                xpfField.Area = winField.Area.ToFieldArea()
                xpfField.AreaIndex = winField.AreaIndex
                xpfField.Caption = winField.Caption
                xpfField.ExpandedInFieldsGroup = winField.ExpandedInFieldsGroup
                xpfField.EmptyCellText = winField.EmptyCellText
                xpfField.EmptyValueText = winField.EmptyValueText
                xpfField.FieldName = winField.FieldName
                xpfField.GrandTotalText = winField.GrandTotalText
                xpfField.GroupInterval = winField.GroupInterval.ToFieldGroupInterval()
                xpfField.GroupIntervalNumericRange = winField.GroupIntervalNumericRange
                xpfField.RunningTotal = winField.RunningTotal
                xpfField.SortMode = winField.SortMode.ToFieldSortMode()
                xpfField.SortOrder = winField.SortOrder.ToFieldSortOrder()
                xpfField.SummaryType = winField.SummaryType.ToFieldSummaryType()
                xpfField.SummaryDisplayType = winField.SummaryDisplayType.ToFieldSummaryDisplayType()
                xpfField.TopValueCount = winField.TopValueCount
                xpfField.TopValueShowOthers = winField.TopValueShowOthers
                xpfField.TopValueType = winField.TopValueType.ToFieldTopValueType()
                xpfField.TotalsVisibility = winField.TotalsVisibility.ToFieldTotalsVisibility()
                xpfField.UnboundType = winField.UnboundType.ToFieldUnboundColumnType()
                xpfField.UnboundExpression = winField.UnboundExpression
                xpfField.UnboundFieldName = winField.UnboundFieldName
                xpfField.UseNativeFormat = winField.UseNativeFormat.ToBool()
                xpfField.Visible = winField.Visible
                ' Options
                xpfField.AllowSort = winField.Options.AllowSort.ToBool()
                xpfField.AllowFilter = winField.Options.AllowFilter.ToBool()
                xpfField.AllowDrag = winField.Options.AllowDrag.ToBool()
                xpfField.AllowExpand = winField.Options.AllowExpand.ToBool()
                xpfField.AllowSortBySummary = winField.Options.AllowSortBySummary.ToBool()
                xpfField.AllowUnboundExpressionEditor = winField.Options.ShowUnboundExpressionMenu
                xpfField.ShowInCustomizationForm = winField.Options.ShowInCustomizationForm
                xpfField.ShowGrandTotal = winField.Options.ShowGrandTotal
                xpfField.ShowTotals = winField.Options.ShowTotals
                xpfField.ShowValues = winField.Options.ShowValues
                xpfField.ShowCustomTotals = winField.Options.ShowCustomTotals
                xpfField.ShowSummaryTypeName = winField.Options.ShowSummaryTypeName
                xpfField.HideEmptyVariationItems = winField.Options.HideEmptyVariationItems
                xpfField.OlapFilterUsingWhereClause = winField.Options.OLAPFilterUsingWhereClause.ToFieldOLAPFilterUsingWhereClause()
                ' SortBySummaryInfo
                xpfField.SortByFieldName = winField.SortBySummaryInfo.FieldName
                xpfField.SortBySummaryType = winField.SortBySummaryInfo.SummaryType.ToFieldSummaryType()
                xpfField.CellFormat = winField.CellFormat.FormatString
                xpfField.GrandTotalCellFormat = winField.GrandTotalCellFormat.FormatString
                xpfField.TotalCellFormat = winField.TotalCellFormat.FormatString
                xpfField.TotalValueFormat = winField.TotalValueFormat.FormatString
                xpfField.ValueFormat = winField.ValueFormat.FormatString
            Next winField
            Dim winSourceField As DevExpress.XtraPivotGrid.PivotGridField
            For i As Integer = 0 To source.Fields.Count - 1
                winSourceField = source.Fields(i)
                xpfField = dest.Fields(i)
                ' Group
                If winSourceField.Group IsNot Nothing Then
                    If xpfField.Group Is Nothing Then
                        xpfField.Group = New DevExpress.Xpf.PivotGrid.PivotGridGroup()
                    End If
                    For Each winFieldBase As DevExpress.XtraPivotGrid.PivotGridFieldBase In winSourceField.Group
                        If fields.ContainsKey(winFieldBase) Then
                            xpfField.Group.Add(fields(winFieldBase))
                        End If
                    Next winFieldBase
                    xpfField.GroupIndex = winSourceField.InnerGroupIndex
                End If
                ' SortBySummaryInfo
                If winSourceField.SortBySummaryInfo.Field IsNot Nothing AndAlso fields.ContainsKey(winSourceField.SortBySummaryInfo.Field) Then
                    xpfField.SortByField = fields(winSourceField.SortBySummaryInfo.Field)
                End If
            Next i
        End Sub
    End Module
End Namespace
