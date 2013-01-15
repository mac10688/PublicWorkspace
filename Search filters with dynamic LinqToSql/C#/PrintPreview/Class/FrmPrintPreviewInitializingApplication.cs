//Call dll netFramework 4.0
using System.Windows.Controls;

//Call NameSpace PrintPreviewResources
using PrintPreview.Resources;

//PrtintPreview project
namespace PrintPreview.Class
{
    //Static class FrmPrintPreviewInitializingApplication
    static class FrmPrintPreviewInitializingApplication
    {
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
                btn[0].Content = FrmPrintPreviewResources.Button1;
                btn[1].Content = FrmPrintPreviewResources.Button2;
                btn[2].Content = FrmPrintPreviewResources.Button3;
                btn[3].Content = FrmPrintPreviewResources.Button4;
                btn[4].Content = FrmPrintPreviewResources.Button5;
                btn[5].Content = FrmPrintPreviewResources.Button6;
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
                lbl[0].Content = FrmPrintPreviewResources.Label1;
                lbl[1].Content = FrmPrintPreviewResources.Label2;
            }
        }

        /*This method is to read through the CultureInfo culture and who are currently active on the PC, 
         * the application supports two cultures, English and Italian. 
         * In this case if and active culture en-US Text property of the TextBlock controls on Form FrmMain
         * will be enhanced with the English terms retrieved from the resource file FrmSearchResources. 
         * Interesting and params keyword, which allows you to specify a parameter for the method that uses a variable number of arguments.
         */
        public static void ChangeContentTextBlock(params TextBlock[] tbk)
        {
            var cultureinfo = System.Globalization.CultureInfo.CreateSpecificCulture("it-IT");

            if (!System.Globalization.CultureInfo.CurrentCulture.Equals(cultureinfo))
            {
                tbk[0].Text = FrmPrintPreviewResources.TextBlock1;
                tbk[1].Text = FrmPrintPreviewResources.TextBlock2;
            }
        }
    }
}
