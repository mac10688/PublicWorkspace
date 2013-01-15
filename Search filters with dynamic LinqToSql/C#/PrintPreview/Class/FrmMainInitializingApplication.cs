//Call dll netFramework 4.0
using System.Windows.Controls;

//Call NameSpace PrintPreviewResources
using PrintPreview.Resources;

//PrtintPreview project
namespace PrintPreview.Class
{
    //Static class FrmMainInitializingApplication
    static class FrmMainInitializingApplication
    {
        /*This method is to read through the CultureInfo culture and who are currently active on the PC, 
         * the application supports two cultures, English and Italian. 
         * In this case if and active culture en-US Items method of the ComboBox controls on Form FrmMain
         * will be enhanced with the English terms retrieved from the resource file FrmSearchResources. 
         * Interesting and params keyword, which allows you to specify a parameter for the method that uses a variable number of arguments.
         */
        public static void ChangeItemComboBox(params ComboBox[] cbx)
        {
            var cultureinfo = System.Globalization.CultureInfo.CreateSpecificCulture("it-IT");

            if (!System.Globalization.CultureInfo.CurrentCulture.Equals(cultureinfo))
            {
                cbx[0].Items.Clear();
                cbx[0].Items.Add(FrmSearchResources.RadioButton1.ToUpper());
                cbx[0].Items.Add(FrmSearchResources.RadioButton2.ToUpper());
                cbx[0].Items.Add(FrmSearchResources.RadioButton3.ToUpper());

                cbx[1].Items.Clear();
                cbx[1].Items.Add(FrmSearchResources.CheckBox1.ToUpper());
                cbx[1].Items.Add(FrmSearchResources.CheckBox2.ToUpper());
                cbx[1].Items.Add(FrmSearchResources.CheckBox3.ToUpper());
                cbx[1].Items.Add(FrmSearchResources.CheckBox4.ToUpper());
                cbx[1].Items.Add(FrmSearchResources.CheckBox5.ToUpper());
                cbx[1].Items.Add(FrmSearchResources.CheckBox6.ToUpper());
                cbx[1].Items.Add(FrmSearchResources.CheckBox7.ToUpper());
                cbx[1].Items.Add(FrmSearchResources.CheckBox8.ToUpper());
                cbx[1].Items.Add(FrmSearchResources.CheckBox9.ToUpper());
                cbx[1].Items.Add(FrmSearchResources.CheckBox10.ToUpper());
                cbx[1].Items.Add(FrmSearchResources.CheckBox11.ToUpper());
                cbx[1].Items.Add(FrmSearchResources.CheckBox12.ToUpper());
                cbx[1].Items.Add(FrmSearchResources.CheckBox13.ToUpper());
                cbx[1].Items.Add(FrmSearchResources.CheckBox14.ToUpper());
                cbx[1].Items.Add(FrmSearchResources.CheckBox15.ToUpper());
            }
        }

        /*This method is to read through the CultureInfo culture and who are currently active on the PC, 
         * the application supports two cultures, English and Italian. 
         * In this case if and active culture en-US Header property of the DataGrid controls on Form FrmMain
         * will be enhanced with the English terms retrieved from the resource file FrmSearchResources. 
         * Interesting and params keyword, which allows you to specify a parameter for the method that uses a variable number of arguments.
         */
        public static void ChangeHeaderText(params DataGrid[] dgv)
        {
            var cultureinfo = System.Globalization.CultureInfo.CreateSpecificCulture("it-IT");

            if (!System.Globalization.CultureInfo.CurrentCulture.Equals(cultureinfo))
            {
                dgv[0].Columns[0].Header = FrmMainResource.DataGridColumn1;
                dgv[0].Columns[1].Header = FrmMainResource.DataGridColumn2;
                dgv[0].Columns[2].Header = FrmMainResource.DataGridColumn3;
                dgv[0].Columns[3].Header = FrmMainResource.DataGridColumn4;
                dgv[0].Columns[4].Header = FrmMainResource.DataGridColumn5;
                dgv[1].Columns[0].Header = FrmMainResource.DataGridColumn6;
                dgv[1].Columns[1].Header = FrmMainResource.DataGridColumn7;
            }
        }

        /*This method is to read through the CultureInfo culture and who are currently active on the PC, 
         * the application supports two cultures, English and Italian. 
         * In this case if and active culture en-US Content property of the Button controls on Form FrmMain
         * will be enhanced with the English terms retrieved from the resource file FrmSearchResources. 
         * Interesting and params keyword, which allows you to specify a parameter for the method that uses a variable number of arguments.
         */
        public static void ChangeContentButton(params Button[] btn)
        {
            var cultureinfo = System.Globalization.CultureInfo.CreateSpecificCulture("it-IT");

            if (!System.Globalization.CultureInfo.CurrentCulture.Equals(cultureinfo))
            {
                btn[0].Content = FrmMainResource.Button1;
                btn[1].Content = FrmMainResource.Button2;
                btn[2].Content = FrmMainResource.Button3;
                btn[3].Content = FrmMainResource.Button4;
                btn[4].Content = FrmMainResource.Button5;
                btn[5].Content = FrmMainResource.Button6;
                btn[6].Content = FrmMainResource.Button7;
                btn[7].Content = FrmMainResource.Button8;
            }
        }

        /*This method is to read through the CultureInfo culture and who are currently active on the PC, 
         * the application supports two cultures, English and Italian. 
         * In this case if and active culture en-US Content property of the Label controls on Form FrmMain
         * will be enhanced with the English terms retrieved from the resource file FrmSearchResources. 
         * Interesting and params keyword, which allows you to specify a parameter for the method that uses a variable number of arguments.
         */
        public static void ChangeContentLabel(params Label[] lbl)
        {
            var cultureinfo = System.Globalization.CultureInfo.CreateSpecificCulture("it-IT");

            if (!System.Globalization.CultureInfo.CurrentCulture.Equals(cultureinfo))
            {
                lbl[0].Content = FrmMainResource.Label1;
                lbl[1].Content = FrmMainResource.Label2;
                lbl[2].Content = FrmMainResource.Label3;
                lbl[3].Content = FrmMainResource.Label4;
                lbl[4].Content = FrmMainResource.Label5;
                lbl[5].Content = FrmMainResource.Label6;
                lbl[6].Content = FrmMainResource.Label7;
            }
        }
    }
}