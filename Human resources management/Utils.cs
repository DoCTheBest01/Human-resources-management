using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human_resources_management
{
    internal class Utils
    {
        internal static void GeneratePdf(DataSet dataSet, string outputPath)
        {
            // Create a new PDF document
            PdfDocument document = new PdfDocument();

            // Specify the Persian font file path
            string fontFilePath = "PersianFont.ttf"; // Update with the actual file path of your Persian font

            // Load the Persian font
            XFont font = LoadFont(fontFilePath, 12, XFontStyle.Regular);

            foreach (DataTable table in dataSet.Tables)
            {
                // Add a new page for each table in the DataSet
                PdfPage page = document.AddPage();

                // Get an XGraphics object for drawing
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Create a brush for drawing text
                XBrush brush = XBrushes.Black;

                // Define column widths
                int numColumns = table.Columns.Count;
                double[] columnWidths = new double[numColumns];
                for (int i = 0; i < numColumns; i++)
                {
                    columnWidths[i] = page.Width / numColumns;
                }

                // Draw table headers
                double xPosition = 20;
                double yPosition = 20;
                for (int i = 0; i < numColumns; i++)
                {
                    gfx.DrawString(table.Columns[i].ColumnName, font, brush, xPosition, yPosition);
                    xPosition += columnWidths[i];
                }
                yPosition += 20;

                // Draw table data
                foreach (DataRow row in table.Rows)
                {
                    xPosition = 20;
                    for (int i = 0; i < numColumns; i++)
                    {
                        // Get the text
                        string text = row[i].ToString();

                        // Reverse the text to simulate RTL directionality
                        string reversedText = ReverseString(text);

                        // Draw the reversed text
                        gfx.DrawString(reversedText, font, brush, xPosition, yPosition);

                        xPosition += columnWidths[i];
                    }
                    yPosition += 20;
                }
            }

            // Save the document to the specified output path
            document.Save(outputPath);

            // Close the document
            document.Close();
        }

        private static XFont LoadFont(string fontFilePath, double size, XFontStyle style)
        {
            // Check if the font file exists
            if (!File.Exists(fontFilePath))
            {
                throw new FileNotFoundException($"Font file '{fontFilePath}' not found.");
            }

            // Return the loaded font
            return new XFont(fontFilePath, size, style);
        }


        // Function to reverse a string
        private static string ReverseString(string text)
        {
            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
