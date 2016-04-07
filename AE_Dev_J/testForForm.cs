﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace AE_Dev_J
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("Office 2013");

            AE_Dev_J.Form.ClassificationForm classform = new Form.ClassificationForm();
            classform.Show();

            Application.Run();
            
        }
    }
}