Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
' ...

Namespace BindUsingTemplatesRuntimeCS
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Function CreateChartData() As DataTable
			' Create an empty table.
			Dim table As New DataTable("Table1")

			' Add three columns to the table.
			table.Columns.Add("Month", GetType(String))
			table.Columns.Add("Section", GetType(String))
			table.Columns.Add("Value", GetType(Int32))

			' Add data rows to the table.
			table.Rows.Add(New Object() { "Jan", "Section1", 10 })
			table.Rows.Add(New Object() { "Jan", "Section2", 20 })
			table.Rows.Add(New Object() { "Feb", "Section1", 20 })
			table.Rows.Add(New Object() { "Feb", "Section2", 30 })
			table.Rows.Add(New Object() { "March", "Section1", 15 })
			table.Rows.Add(New Object() { "March", "Section2", 25 })

			Return table
		End Function

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Create a chart.
			Dim chart As New ChartControl()

			' Generate a data table and bind the chart to it.
			chart.DataSource = CreateChartData()

			' Specify data members to bind the chart's series template.
			chart.SeriesDataMember = "Month"
			chart.SeriesTemplate.ArgumentDataMember = "Section"
			chart.SeriesTemplate.ValueDataMembers.AddRange(New String() {"Value"})

			' Specify the template's series view.
			chart.SeriesTemplate.View = New StackedBarSeriesView()

			' Specify the template's name prefix.
			chart.SeriesNameTemplate.BeginText = "Month: "

			' Dock the chart into its parent, and add it to the current form.
			chart.Dock = DockStyle.Fill
			Me.Controls.Add(chart)
		End Sub
	End Class
End Namespace