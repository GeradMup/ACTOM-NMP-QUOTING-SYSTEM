using NMP_Quoting_System.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PDF_GEN
{
   
	public class GearboxQuote
	{

		private List<string> generalInfo;
		private List<string> performanceInfo;
		private List<string> dimensionInfo;
		private List<string> lubricantInfo;
		private List<string> userInfo;

		public GearboxQuote()
        {
		
		}

        /// <summary>
        /// Function for generating PDF Quotes for Gearboxes
        /// </summary>
		public void generateQuote(Gearbox gearboxData, Dimensions dimensions, Lubricant lubricant, User user) 
        {

            //DEFINE ALL THE DATA HERE
            //*************************************************************************************************************************
            generalInfo = new List<string>
            {
                gearboxData.Type.ToString() + (gearboxData.Number < 100 ? " 0" + gearboxData.Number.ToString() : gearboxData.Number.ToString()),
                gearboxData.Rating.ToString() + " kW",
                gearboxData.HollowShaftDiameter.ToString() + " mm",
                " ## mm",
                gearboxData.Spec.ToString(),
                " ##"
            };

            performanceInfo = new List<string>
            {
                gearboxData.InitialRpm.ToString(),
                gearboxData.FinalRpm.ToString(),
                gearboxData.Ratio.ToString(),
                gearboxData.Torque.ToString(),
                gearboxData.Fs.ToString(),
            };

            dimensionInfo = new List<string>
            {
                dimensions.FlangeOuterDiameter.ToString(),
                dimensions.PCD.ToString(),
                dimensions.FlangeInnerDiameter.ToString(),
                dimensions.ShaftDiameter.ToString(),
            };

            lubricantInfo = new List<string>
            {
                lubricant.Manufacturer.ToString(),
                lubricant.OilType.ToString(),
                lubricant.OilGrade.ToString(),
                lubricant.OilQuantity.ToString(),
            };

            userInfo = new List<string>
            {
                user.Name.ToString(),
                user.Designation.ToString(),

            };
            //*************************************************************************************************************************

            QuestPDF.Settings.License = LicenseType.Community;

			Document.Create(document =>
			{
				document.Page(page =>
				{
					page.Size(PageSizes.A4);
					page_Horizontal_Margin(page, PDF_Constants.HorizontalMargins);

					Header(page.Header(), "Gearbox Unit Technical Datasheet");

					page.Content().Element(Contents);

					string date = DateTime.Now.ToString(PDF_Constants.DateFormat);
					Footer(page.Footer(),date);

							
				});
			})
			.GeneratePdf("test2.pdf");

		}
		void page_Horizontal_Margin(PageDescriptor page, uint sizeOfMargins)
		{
			page.MarginHorizontal(sizeOfMargins);
		}
		void Header(IContainer container, string headerTitle)
		{
			container.Background("#006CB7")
					 .Height(1, Unit.Centimetre)
					 .Column(column =>
					 {
						 column.Item().Text(headerTitle).FontColor(Colors.White).SemiBold();
						 column.Item().PaddingVertical(1).LineHorizontal(1).LineColor(Colors.White);
						 column.Item().PaddingVertical(1).LineHorizontal(1).LineColor(Colors.White);
					 });
		}

		void Contents (IContainer container) 
		{
			
			container.Column(column =>
			{	
				space_Between_Columns(column, PDF_Constants.ColumnSpacing);

				//=====THIS FORMS PART OF THE DOCUMENT TITLE=============
				Add_Row_Image_Description(column.Item(),10,55,"ARW.png","Worm Drive Gearbox Unit",36,"#006CB7");


				column.Item().Row(row =>
				{
					space_Between_Columns(column, PDF_Constants.ColumnSpacing);
					//=====GENERAL INFORMATION SECTION=====
					space_Between_Rows(row, PDF_Constants.RowSpacing);
					List<string> generalInfoHeaders = PDF_Constants.GeneralInfoHeaders;
					String tableHeader = "General Information";

					Add_Table_With_Header(row.ConstantItem(350), tableHeader, PDF_Constants.FontSize, generalInfoHeaders, generalInfo);
					row.RelativeItem().Width(210).Height(140).Placeholder();
				});
				//=====GEARBOX PERFORMANCE SECTION=====
				column.Item().Row(row =>
				{
					space_Between_Columns(column, PDF_Constants.ColumnSpacing);
					space_Between_Rows(row, PDF_Constants.RowSpacing);
					List<string> performanceHeaders = PDF_Constants.PerformanceHeaders;
					String tableHeader = "Gearbox Performance";

					Add_Table_With_Header(row.ConstantItem(350), tableHeader, PDF_Constants.FontSize, performanceHeaders, performanceInfo);
					row.RelativeItem().Width(210).Height(135).Placeholder();
				});

				//=====GEARBOX DIMENSIONS SECTION====
				column.Item().Row(row =>
				{
					space_Between_Columns(column, PDF_Constants.ColumnSpacing);
					space_Between_Rows(row, PDF_Constants.RowSpacing);
					List<string> dimensionHeaders = PDF_Constants.DimensionHeaders;
					String tableHeader = "Gearbox Dimensions";

					Add_Table_With_Header(row.ConstantItem(350), tableHeader, PDF_Constants.FontSize, dimensionHeaders, dimensionInfo);
					row.RelativeItem().Width(210).Height(100).Placeholder();
				});

				//=====GEARBOX LUBRICANT SECTON=====
				column.Item().Row(row =>
				{
					space_Between_Columns(column, PDF_Constants.ColumnSpacing);
					space_Between_Rows(row, PDF_Constants.RowSpacing);
					List<string> lubricantHeaders = PDF_Constants.LubricantHeaders;
					String tableHeader = "Gearbox Lubricant";

					Add_Table_With_Header(row.ConstantItem(350), tableHeader, PDF_Constants.FontSize, lubricantHeaders, lubricantInfo);
					row.RelativeItem().Width(210).Height(100).Placeholder();
																						
				});
				//=====THIS SECTION IS BELOW THE TABLES====
				column.Item().Row(row =>
				{
					
					row.ConstantItem(350).Table(table =>
					{

						table.ColumnsDefinition(columns =>
						{
							columns.ConstantColumn(100);
							columns.ConstantColumn(120);
						});
						List<string> userHeaders = PDF_Constants.UserHeaders;
						string colour = PDF_Constants.White;

						Create_Cell(table, 1, 1, colour, userHeaders[0], 12,Align.Right,5);
						Create_Cell(table, 1, 2, colour, userHeaders[1], 12, Align.Right,5);
						Create_Cell(table, 2, 1, colour, userInfo[0], 12, Align.Left);
						Create_Cell(table, 2, 2, colour, userInfo[1], 12, Align.Left);


					});
					
				});

			});


		}
		void Footer(IContainer container, string date) 
		{
			container.Column(column => 
			{
				column.Item().PaddingBottom(0).AlignRight()
							.Text(date)
							.SemiBold();

				column.Item().Image("ActomLogo.png").FitWidth();
			});
			
					 
		}
		void space_Between_Rows(RowDescriptor row,uint rowSpace)
		{
			row.Spacing(rowSpace);
		}

		void space_Between_Columns(ColumnDescriptor column, uint columnSpace)
		{
			column.Spacing(columnSpace);
		}
		void Add_Table_With_Header
			(IContainer row, 
			string headerTitle,
			int fontSize, 
			List<string> headers, 
			List<string>data)
		{
			row.Table(table =>
			{
				table.ColumnsDefinition(columns =>
				{
					columns.ConstantColumn(175);
					columns.RelativeColumn();
				});


				string colour = "";
				int rows = headers.Count();

				for (uint row = 1; row <= rows; row++)
				{
					colour = (row % 2 != 0) ? PDF_Constants.LightBlue : PDF_Constants.White;
					Create_Cell(table, 1, row, colour, headers[(int)(row - 1)], fontSize);
					Create_Cell(table, 2, row, colour, data[(int)(row - 1)], fontSize);
				}

				table.Header(header =>
				{
					Create_Header_Cell(header, 2, PDF_Constants.ActomBlue, headerTitle, 18, PDF_Constants.White);

				});
			});

		}
		void Create_Header_Cell
			(TableCellDescriptor headerCellContents,
			uint numOfColumns,
			string backgroundColour, 
			string cellContents, 
			int fontSize, 
			string fontColour)
		{
			headerCellContents.Cell()
				.ColumnSpan(numOfColumns)
				.Background(backgroundColour)
				.AlignCenter()
				.Text(cellContents)
				.FontSize(fontSize)
				.FontColor(fontColour);
		}
		void Create_Cell(
			TableDescriptor table, 
			uint columnNumber, 
			uint rowNumber, 
			string backgroundColour,
			string cellContents,
			int fontSize, 
			Align align = Align.Center,
			uint rightPaddingValue = 0)
		{

			if (align == Align.Center)
			{
				table.Cell()
					.Column(columnNumber)
					.Row(rowNumber)
                    .PaddingRight(rightPaddingValue)
                    .Background(backgroundColour)
					.AlignCenter()
					.Text(cellContents)
					.FontSize(fontSize);
			}
			else if (align == Align.Left) 
			{
				table.Cell()
					.Column(columnNumber)
					.Row(rowNumber)
					.PaddingRight(rightPaddingValue)
                    .Background(backgroundColour)
					.AlignLeft()
					.Text(cellContents)
					.FontSize(fontSize);
			}
			else if (align == Align.Right)
			{
				table.Cell()
					.Column(columnNumber)
					.Row(rowNumber)
                    .PaddingRight(rightPaddingValue)
                    .Background(backgroundColour)
					.AlignRight()
					.Text(cellContents)
					.FontSize(fontSize);
			}
		}
		void Add_Image(IContainer column, int spacing, int imageSize, string imageName)
		{
			column.Row(row =>
			{
				row.Spacing(spacing);
				row.ConstantItem(imageSize)
					//.PaddingVertical(10)
					.Image(imageName).FitArea();
			});
		}

		void Add_Row_Image_Description
			(IContainer column, 
			int rowSpacing, 
			int imageSize, 
			string imageName,
			string descriptionContent,
			int fontSize, 
			string hexColourCode)
		{
			column.Row(row =>
			{
				row.Spacing(rowSpacing);
				row.ConstantItem(imageSize)
					.PaddingVertical(10)
					.Image(imageName).FitArea();

				row.RelativeItem()
				   .Text(descriptionContent)
				.FontSize(fontSize)
				.FontColor(hexColourCode);
			});

		}
	}

	enum Align 
	{ 
		Left,
		Right,
		Center
	};
};
