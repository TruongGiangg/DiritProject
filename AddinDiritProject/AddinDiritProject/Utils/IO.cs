using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace AddinDiritProject.Utils
{
    public class IO
    {
        #region message boxes

        public static void ShowInfo(string mess, string title = "Information")
        {
            MessageBox.Show(mess, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void ShowWarning(string mess, string title = "Warning")
        {
            MessageBox.Show(mess, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void ShowError(string mess, string title = "Error")
        {
            MessageBox.Show(mess, title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        public static MessageBoxResult ShowQuestion(string mess, string title = "Question")
        {
            return MessageBox.Show(mess, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        public static void ShowException(Exception ex)
        {
            string mess = ex.Message + Environment.NewLine + ex.StackTrace;
            MessageBox.Show(mess, "Exception");
        }

        #endregion message boxes

        #region folders

        public static string GetAssemlyFolder()
        {
            string location = Assembly.GetExecutingAssembly().Location;
            string dir = Path.GetDirectoryName(location);
            return dir;
        }

        public static string GetAddinFolder()
        {
            string assemblyFolder = GetAssemlyFolder();
            return Directory.GetParent(assemblyFolder).FullName;
        }

        public static string GetRibbonIconFolder()
        {
            string addin = GetAddinFolder();
            string images = Path.Combine(addin);
            return images;
        }

        #endregion folders
    }
}