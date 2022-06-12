//using iTextSharp.text;
//using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc.Rendering;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SStorm.CTH.DAL.EntityClasses;
using SStorm.CTH.DAL.HelperClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SStorm.CTH.Web
{
    public class DataHelper
    {

        public static SelectList GetSelectList<T>(EntityField2 dataValueField, EntityField2 dataTextField) where T : IEntity2, new()
        {
            var entityCollection = CTH.BL.DataBaseClassHelper.GetCollection<T>(null, 0, null, null, 0, 0, dataValueField, dataTextField);


            return new SelectList(entityCollection, dataValueField.Name, dataTextField.Name);
        }

        public static SelectList GetSelectList<T>(EntityField2 dataValueField, EntityField2 dataTextField, RelationPredicateBucket filter) where T : IEntity2, new()
        {
            var entityCollection = CTH.BL.DataBaseClassHelper.GetCollection<T>(filter, 0, null, null, 0, 0, dataValueField, dataTextField);


            return new SelectList(entityCollection, dataValueField.Name, dataTextField.Name);
        }

        public static SelectList GetSelectList<T>(EntityField2 dataValueField, EntityField2 dataTextField, RelationPredicateBucket filter, PrefetchPath2 path) where T : IEntity2, new()
        {
            var entityCollection = BL.DataBaseClassHelper.GetCollection<T>(filter, 0, null, path, 0, 0, dataValueField, dataTextField);


            return new SelectList(entityCollection, dataValueField.Name, dataTextField.Name);
        }
        public static SelectList GetStagingSelectList(EntityField2 dataValueField, EntityField2 dataTextField, EntityField2 dataTextField2, RelationPredicateBucket filter)
        {
            EntityCollection<CTHTNMStagingEntity> stagingEntities = new EntityCollection<CTHTNMStagingEntity>();
            CTH.BL.DataBaseClassHelper.FillCollection(stagingEntities, filter, 0, null, null, 0, 0, dataValueField, dataTextField, dataTextField2);

            var combinedReslt = stagingEntities.Select(x => new { ID = x.ID, Name = $"{x.Name} - {x.Description}" });

            return new SelectList(combinedReslt, dataValueField.Name, dataTextField.Name);
        }

        public static SelectList GetSelectListGrouped<T>(EntityField2 dataValueField, EntityField2 dataTextField1, EntityField2 dataTextField2, RelationPredicateBucket filter) where T : IEntity2, new()
        {
            var entityCollection = CTH.BL.DataBaseClassHelper.GetCollection<T>(filter, 0, null, null, 0, 0, dataValueField, dataTextField1, dataTextField2);
            return new SelectList(entityCollection, dataValueField.Name, dataTextField1.Name, null, dataTextField2.Name);
        }

        public static List<SelectListItem> GetDirectionSelectList<T>()
        {
            Array values = Enum.GetValues(typeof(T));
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var i in values)
            {
                items.Add(new SelectListItem
                {
                    Text = Enum.GetName(typeof(T), i),
                    Value = ((int)i).ToString()
                });
            }

            return items;
        }

        public static int GetEnumValue<T>(string EnumText)
        {
            var EnumValue = 0;
            Array values = Enum.GetValues(typeof(T));
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (var i in values)
            {
                var Text = Enum.GetName(typeof(T), i);
                if (Text == EnumText)
                {
                    EnumValue = (int)i;
                }
            }
            return EnumValue;
        }


        public static void ExportToPdf(List<DataTable> dts, string strFilePath, string Header)
        {
            //string fontpath = Environment.GetEnvironmentVariable("SystemRoot") +
            //    "\\fonts\\tahoma.ttf";
            //BaseFont basefont = BaseFont.CreateFont
            //(fontpath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            //Font tahomaFont = new Font(basefont, 10, Font.NORMAL, BaseColor.BLACK);
            //Font tahomaHeaderFont = new Font(basefont, 20, Font.NORMAL, BaseColor.BLACK);
            //Font TableHeaderFont = new Font(basefont, 13, Font.NORMAL, BaseColor.BLACK);

            //Document document = new Document();
            //PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(strFilePath, FileMode.Create));
            //document.Open();
            //PdfPTable HeaderTable = new PdfPTable(1);
            //PdfPCell HeaderCell = new PdfPCell();
            //HeaderCell.Border = 0;
            //Paragraph p = new Paragraph(Header, tahomaHeaderFont);
            //p.Alignment = Element.ALIGN_CENTER;
            //HeaderCell.AddElement(p);
            //HeaderTable.AddCell(HeaderCell);
            //HeaderTable.SpacingAfter = 20;
            //document.Add(HeaderTable);

            //List<PdfPTable> tables = new List<PdfPTable>();
            //var counter = 0;

            //foreach (var dt in dts)
            //{
            //    PdfPTable table = new PdfPTable(dt.Columns.Count);
            //    table.DefaultCell.FixedHeight = 40f;

            //    float[] widths = new float[dt.Columns.Count];
            //    for (int i = 0; i < dt.Columns.Count; i++)
            //        widths[i] = 4f;

            //    table.SetWidths(widths);

            //    table.WidthPercentage = 100;

            //    table.SpacingAfter = 20;

            //    PdfPCell cell = new PdfPCell(new Phrase("Products"));

            //    cell.Colspan = dt.Columns.Count;
            //    table.RunDirection = PdfWriter.RUN_DIRECTION_LTR;
            //    foreach (DataColumn c in dt.Columns)
            //    {
            //        PdfPCell cc = new PdfPCell();
            //        var e = new Paragraph();
            //        if (counter % 2 == 0 && counter != 0 || counter == 1)
            //        {
            //            cc.BackgroundColor = BaseColor.LIGHT_GRAY;
            //            e = new Paragraph(c.ColumnName + "\n", tahomaFont);
            //        }
            //        else
            //        {
            //            e = new Paragraph(c.ColumnName, TableHeaderFont);
            //        }
            //        e.SpacingAfter = 10;
            //        e.Alignment = Element.ALIGN_CENTER;
            //        cc.AddElement(e);

            //        table.AddCell(cc);
            //    }

            //    foreach (DataRow r in dt.Rows)
            //    {
            //        if (dt.Rows.Count > 0)
            //        {
            //            for (int h = 0; h < dt.Columns.Count; h++)
            //            {
            //                PdfPCell c = new PdfPCell();
            //                var e = new Paragraph(r[h].ToString(), tahomaFont);
            //                e.SpacingAfter = 10;
            //                e.Alignment = Element.ALIGN_CENTER;
            //                c.AddElement(e);
            //                table.AddCell(c);
            //            }
            //        }
            //    }
            //    document.Add(table);
            //    counter++;
            //}
            //document.Close();
        }

        //added method
        public static EntityCollection<CTHCancerTypeEntity> RecursiveData(IEnumerable<CTHCancerTypeEntity> root, EntityCollection<CTHCancerTypeEntity> CancerTypes)
        {
            if (root == null) return null;
            foreach (var item in root)
            {
                var subs = CancerTypes.Where(x => x.ParentID == item.ID);
                item.CTHCancerTypeCollection.AddRange(subs);
                RecursiveData(subs, CancerTypes);
            }
            return new EntityCollection<CTHCancerTypeEntity>(root);
        }

    }
}
