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

        public static void FatalError(string message, string captionText = "Error")
        {
            MessageBox.Show(message, captionText,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            FatalErrorCount++;
            Application.Exit();
            //Close();
        }



    }
}
