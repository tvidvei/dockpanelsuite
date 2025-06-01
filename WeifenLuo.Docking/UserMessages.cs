using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WeifenLuo.Docking
{
    public static class UserMessages
    {

        public static int FatalErrorCount { get; set; } = 0;

        public static void FatalErrorMessage(string message, string captionText = "Fatal Error")
        {
            MessageBox.Show(message, captionText,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            FatalErrorCount++;
            Application.Exit();
            //Close();
        }

        public static void ErrorMessage(string message, string location = null)
        {
            MessageBox.Show(message, location != null ? "Error in " + location : "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public static void InfoMessage(string message, string location = null)
        {
            MessageBox.Show(message, location != null ? "Information from " + location : "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

    }
}
