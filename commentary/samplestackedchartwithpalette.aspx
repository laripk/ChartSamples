<!-- this sample comes from https://www.experts-exchange.com/questions/28310264/Creating-a-Chart-with-MS-Chart-Control-C.html -->
<Chart Palette="None" PaletteCustomColors="149,189,66; 197,56,52; 55,118,193; 117,82,160; 49,171,204; 255,136,35; 168,203,104; 209,98,96; 97,142,206; 142,116,178; 93,186,215; 255,155,83">
  <Series>
	<Series ChartType="StackedBar100" Font="{0}, 9.5px" LabelForeColor="59, 59, 59" CustomProperties="PointWidth=0.75, MaxPixelPointWidth=40">
	  <SmartLabelStyle Enabled="True" />
	</Series>
  </Series>
  <ChartAreas>
	<ChartArea BorderColor="White" BorderDashStyle="Solid">
	  <AxisY LabelAutoFitMinFontSize="8" TitleForeColor="59, 59, 59" TitleFont="{0}, 10.5px" LineColor="165, 172, 181" IntervalAutoMode="VariableCount">
		<MajorGrid LineColor="239, 242, 246" />
		<MajorTickMark LineColor="165, 172, 181" />
		<LabelStyle Font="{0}, 10.5px" ForeColor="59, 59, 59" />
	  </AxisY>
	  <AxisX LabelAutoFitMinFontSize="8" TitleForeColor="59, 59, 59" TitleFont="{0}, 10.5px" LineColor="165, 172, 181" IntervalAutoMode="VariableCount">
		<MajorGrid Enabled="False" />
		<MajorTickMark Enabled="False" />
		<LabelStyle Font="{0}, 10.5px" ForeColor="59, 59, 59" />
	  </AxisX>
	</ChartArea>
  </ChartAreas>
  <Titles>
	<Title Alignment="TopLeft" DockingOffset="-3" Font="{0}, 13px" ForeColor="0, 0, 0" />
  </Titles>
</Chart>


	