using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using System.Text;
using EnvDTE;
using EnvDTE80;
using Microsoft.Web.Samples;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;

namespace Stratsys.Stratsys_SpriteIt
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the informations needed to show the this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidSpriteItPkgString)]
    public sealed class Stratsys_SpriteItPackage : Package
    {      
        /// <summary>
        /// Initialization of the package; this is the place where you can put all the initilaization
        /// code that relay on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            // Trace the beginning of this method and call the base implementation.
            base.Initialize();

            // Now get the OleCommandService object provided by the MPF; this object is the one
            // responsible for handling the collection of commands implemented by the package.
            var mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (null == mcs) return;
            
            //For Traverse commands we have to define its id that is an unique Guid/integer pair.
            var idGenerateSprite = new CommandID(GuidList.guidSpriteItCmdSet, PkgCmdIDList.cmdidGenerateSprite);
            // Now create the OleMenuCommand object for these commands. The EventHandler object is the
            // function that will be called when the user will select the command.
            var commandGenerateSprite = new OleMenuCommand(GenerateSpriteCommand, idGenerateSprite);
            // Add the commands to the command service.
            mcs.AddCommand(commandGenerateSprite);
        }


        private void GenerateSpriteCommand(object caller, EventArgs args)
        {
            var dte = (DTE)GetService(typeof(DTE));
            var dte2 =(DTE2) dte;
            var imageOptimizations = new ImageOptimizations();
            foreach (UIHierarchyItem item in (IEnumerable)dte2.ToolWindows.SolutionExplorer.SelectedItems)
            {
                var projectItem = (ProjectItem)item.Object;
                imageOptimizations.ProcessDirectory(projectItem.FileNames[0]);
            }           
        }
    }
}
