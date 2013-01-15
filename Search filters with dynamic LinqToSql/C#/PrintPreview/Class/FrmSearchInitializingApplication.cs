//Call dll netFramework 4.0
using System.Windows.Controls;

//Call NameSpace PrintPreviewResources
using PrintPreview.Resources;


//PrtintPreview project
namespace PrintPreview.Class
{
    //Static Class FrmSearchInitializingApplication
    static class FrmSearchInitializingApplication
    {
        /*This method is to read through the CultureInfo culture and who are currently active on the PC, 
         * the application supports two cultures, English and Italian. 
         * In this case if and active culture en-US Content property of the RadioButton controls on Form FrmSearch 
         * will be enhanced with the English terms retrieved from the resource file FrmSearchResources. 
         * Interesting and params keyword, which allows you to specify a parameter for the method that uses a variable number of arguments.
         */
        public static void ChangeContentRadioButton(params RadioButton[] rbt)
        {
            var cultureinfo = System.Globalization.CultureInfo.CreateSpecificCulture("it-IT");

            if (!System.Globalization.CultureInfo.CurrentCulture.Equals(cultureinfo))
            {
                rbt[0].Content = FrmSearchResources.RadioButton1;
                rbt[1].Content = FrmSearchResources.RadioButton2;
                rbt[2].Content = FrmSearchResources.RadioButton3;
            }
        }

        /*This method is to read through the CultureInfo culture and who are currently active on the PC, 
         * the application supports two cultures, English and Italian. 
         * In this case if and active culture en-US Content property of the CheckBox controls on Form FrmSearch 
         * will be enhanced with the English terms retrieved from the resource file FrmSearchResources. 
         * Interesting and params keyword, which allows you to specify a parameter for the method that uses a variable number of arguments.
         */
        public static void ChangeContentCheckBox(params CheckBox[] chk)
        {
            var cultureinfo = System.Globalization.CultureInfo.CreateSpecificCulture("it-IT");

            if (!System.Globalization.CultureInfo.CurrentCulture.Equals(cultureinfo))
            {
                chk[0].Content = FrmSearchResources.CheckBox1;
                chk[1].Content = FrmSearchResources.CheckBox2;
                chk[2].Content = FrmSearchResources.CheckBox3;
                chk[3].Content = FrmSearchResources.CheckBox4;
                chk[4].Content = FrmSearchResources.CheckBox5;
                chk[5].Content = FrmSearchResources.CheckBox6;
                chk[6].Content = FrmSearchResources.CheckBox7;

                chk[7].Content = FrmSearchResources.CheckBox8;
                chk[8].Content = FrmSearchResources.CheckBox9;
                chk[9].Content = FrmSearchResources.CheckBox10;
                chk[10].Content = FrmSearchResources.CheckBox11;
                chk[11].Content = FrmSearchResources.CheckBox12;
                chk[12].Content = FrmSearchResources.CheckBox12;
                chk[13].Content = FrmSearchResources.CheckBox14;

                chk[14].Content = FrmSearchResources.CheckBox15;
                chk[15].Content = FrmSearchResources.CheckBox16;
            }
        }

        /*This method is to read through the CultureInfo culture and who are currently active on the PC, 
         * the application supports two cultures, English and Italian. 
         * In this case if and active culture en-US Content property of the Button controls on Form FrmSearch 
         * will be enhanced with the English terms retrieved from the resource file FrmSearchResources. 
         * Interesting and params keyword, which allows you to specify a parameter for the method that uses a variable number of arguments.
         */
        public static void ChangeContentButton(params Button[] btn)
        {
            var cultureinfo = System.Globalization.CultureInfo.CreateSpecificCulture("it-IT");

            if (!System.Globalization.CultureInfo.CurrentCulture.Equals(cultureinfo))
            {
                btn[0].Content = FrmSearchResources.Button1;
                btn[1].Content = FrmSearchResources.Button2;
            }
        }
    }
}
