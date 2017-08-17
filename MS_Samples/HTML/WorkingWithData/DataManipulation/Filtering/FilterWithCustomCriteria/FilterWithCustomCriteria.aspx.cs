using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.DataVisualization.Charting;

namespace System.Web.UI.DataVisualization.Charting.Samples
{
	/// <summary>
	/// Summary description for FilterWithCustomCriteria.
	/// </summary>
	public partial class FilterWithCustomCriteria : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Populate chart with random data
			Random	random = new Random();
			double	xValue = 2;
			for(int pointIndex = 0; pointIndex < 50; pointIndex++)
			{
				Chart1.Series["Series Input"].Points.AddXY(xValue, random.Next(2, 47));
				xValue += 2;
			}

			// Create strip lines which cover the areas with filtered values
			StripLine stripLine = new StripLine();
			stripLine.BackColor = Color.FromArgb(120, 241,185,168);
			stripLine.IntervalOffset = double.Parse(IntervalOffsetList.SelectedItem.Value);
			stripLine.Interval = double.Parse(StripWidthList.SelectedItem.Value) * 2.0;
			stripLine.StripWidth = double.Parse(StripWidthList.SelectedItem.Value);
			Chart1.ChartAreas["ChartArea1"].AxisX.StripLines.Add(stripLine);

			// Filter series data using custom filtering criteria
			Chart1.DataManipulator.Filter(new CustomFilter(stripLine.IntervalOffset, stripLine.StripWidth), "Series Input", "Series Output");

			// Show data points using point's index
			if(ShowAsIndexedList.SelectedItem.Text == "True")
			{
				Chart1.Series["Series Output"].IsXValueIndexed = true;
				Chart1.ChartAreas["FilteredData"].AxisX.Minimum = double.NaN;
				Chart1.ChartAreas["FilteredData"].AxisX.Maximum = double.NaN;
				Chart1.ChartAreas["FilteredData"].AxisX.LabelStyle.Interval = 2;
				Chart1.ChartAreas["FilteredData"].AxisX.MajorTickMark.Interval = 2;
				Chart1.ChartAreas["FilteredData"].AxisX.MajorGrid.Interval = 2;
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		/// <summary>
		/// Class define custom filtering criteria
		/// </summary>
		private class CustomFilter : IDataPointFilter
		{
			private double offset = 0;		// interval offset
			private double interval = 0;	// interval size

			// Public constructor
			public CustomFilter(double offset, double interval)
			{
				this.offset = offset;
				this.interval = interval;
			}

			// Filtering method
			public bool FilterDataPoint(DataPoint dataPoint, Series series, int pointIndex)
			{
				// Check if point's X value is in one of the intervals
				for(double val = offset; val < 100; val += 2.0 * interval)
				{
					if(dataPoint.XValue >= val && dataPoint.XValue <= (val + interval))
					{
						return true;	// Return true to remove the point
					}
				}
				return false;	// Return false to keep the point
			}
		}

	}

}
