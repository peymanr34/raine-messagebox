using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Demo48
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DialogResult result = new Raine.MessageBox.MessageBoxBuilder()
                .WithAppendLine("Would you like to exit?")
                .WithAppendLine("Any unsaved progress will be lost.")
                .WithAppendLine()
                .WithAppendLine("Please save your work before closing.")
                .WithAppendLine()
                .WithAppend("From: ")
                .WithAppendLine(RuntimeInformation.FrameworkDescription)
                .WithCaption("Are you sure?")
                .WithButtons(MessageBoxButtons.YesNo)
                .WithIcon(MessageBoxIcon.Question)
                .WithDefaultButton(MessageBoxDefaultButton.Button1)
                .WithOptions(MessageBoxOptions.RightAlign)
                .Show();

            Debug.WriteLine($"You have clicked '{result}'.");
        }
    }
}
