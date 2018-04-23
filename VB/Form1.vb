Imports System
Imports System.Data
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
' ...


Public Class Form1

    Private Function CreateChartData() As DataTable
        ' Create an empty table.
        Dim Table As New DataTable("Table1")

        ' Add three columns to the table.
        Table.Columns.Add("Month", GetType([String]))
        Table.Columns.Add("Section", GetType([String]))
        Table.Columns.Add("Value", GetType(Int32))

        ' Add data rows to the table.
        Table.Rows.Add(New Object() {"Jan", "Section1", 10})
        Table.Rows.Add(New Object() {"Jan", "Section2", 20})
        Table.Rows.Add(New Object() {"Feb", "Section1", 20})
        Table.Rows.Add(New Object() {"Feb", "Section2", 30})
        Table.Rows.Add(New Object() {"March", "Section1", 15})
        Table.Rows.Add(New Object() {"March", "Section2", 25})

        Return Table
    End Function


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
    Handles MyBase.Load
        ' Create a chart.
        Dim Chart As New ChartControl()

        ' Generate a data table and bind the chart to it.
        Chart.DataSource = CreateChartData()

        ' Specify data members to bind the chart's series template.
        Chart.SeriesDataMember = "Month"
        Chart.SeriesTemplate.ArgumentDataMember = "Section"
        Chart.SeriesTemplate.ValueDataMembers.AddRange(New String() {"Value"})

        ' Specify the template's series view.
        Chart.SeriesTemplate.View = New StackedBarSeriesView()

        ' Specify the template's name prefix.
        Chart.SeriesNameTemplate.BeginText = "Month: "

        ' Dock the chart into its parent, and add it to the current form.
        Chart.Dock = DockStyle.Fill
        Me.Controls.Add(Chart)
    End Sub
End Class
