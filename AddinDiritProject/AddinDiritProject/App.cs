using AddinDiritProject.Utils;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace AddinDiritProject
{
    public class App : IExternalApplication
    {
        public static UIControlledApplication _AppCache;

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            _AppCache = application;

            CreateRibbonDrain(application);
            CreateRibbonFire(application);
            CreateRibbonMep(application);
            CreateRibbonGens(application);

            return Result.Succeeded;
        }

        #region Create Ribbon

        private void CreateRibbonDrain(UIControlledApplication app)
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;

            string tabName = Define.TabNameDrain;

            app.CreateRibbonTab(tabName);
        }

        private void CreateRibbonFire(UIControlledApplication app)
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;

            string tabName = Define.TabNameFire;

            app.CreateRibbonTab(tabName);
        }

        private void CreateRibbonMep(UIControlledApplication app)
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;

            string tabName = Define.TabNameMep;

            app.CreateRibbonTab(tabName);
        }

        private void CreateRibbonGens(UIControlledApplication app)
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;

            string tabName = Define.TabNameGens;

            app.CreateRibbonTab(tabName);
        }

        #endregion Create Ribbon

        #region Get Folder

        private string GetIconFolder()
        {
            string appDir = GetAppFolder();
            string imageDir = Path.Combine(appDir, "Icon");
            return imageDir;
        }

        private string GetAppFolder()
        {
            string location = Assembly.GetExecutingAssembly().Location;
            string dir = Path.GetDirectoryName(location);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return dir;
        }

        private void AddImages(ButtonData buttonData,
                               string iconFolder,
                               string largeImage,
                               string smallImage)
        {
            if (!string.IsNullOrEmpty(iconFolder)
                && Directory.Exists(iconFolder))
            {
                string largeImagePath = Path.Combine(iconFolder, largeImage);
                if (File.Exists(largeImagePath))
                    buttonData.LargeImage = new BitmapImage(new Uri(largeImagePath));

                string smallImagePath = Path.Combine(iconFolder, smallImage);
                if (File.Exists(smallImagePath))
                    buttonData.Image = new BitmapImage(new Uri(smallImagePath));
            }
        }

        #endregion Get Folder
    }
}