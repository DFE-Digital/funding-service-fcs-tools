// Type: Microsoft.Crm.Tools.SolutionPackager.SolutionPackager
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    public sealed class SolutionPackager
  {
    public List<string> PreExistingFiles = new List<string>();

    public Context Context { get; private set; }

    public SolutionPackager(PackagerArguments arguments)
    {
      Logger.Level = arguments.ErrorLevel;
      if (!string.IsNullOrWhiteSpace(arguments.LogFile))
      {
        Helper.EnsurePathDirectory(arguments.LogFile);
        Trace.Listeners.Add(new TextWriterTraceListener(arguments.LogFile));
      }
      Filer.Initialize(arguments);
      Context = new Context(arguments);
      Helper.SetSafety(arguments.AllowWrites == AllowWrite.No, arguments.Clobber);
    }

    public void Run()
    {
      try
      {
        var str1 = Context.ZipFile;
        string path1 = null;
        if (Context.PackageTypeArgument == SolutionPackageType.Both)
        {
          if (Path.GetFileNameWithoutExtension(Context.ZipFile).EndsWith("_managed"))
            throw new ArgumentException("Do not use the managed file when extracting both Managed and Unmanaged");
          path1 = Path.Combine(Path.GetDirectoryName(Context.ZipFile), string.Format("{0}_managed{1}", Path.GetFileNameWithoutExtension(Context.ZipFile), Path.GetExtension(Context.ZipFile)));
          str1 = string.Format("{0} and {1}", Context.ZipFile, path1);
        }
        switch (Context.Action)
        {
          case CommandAction.Extract:
            if (Context.PackageTypeArgument == SolutionPackageType.Both && !File.Exists(path1))
              throw new FileNotFoundException("Assumed Managed solution file not found: " + path1);
            Logger.Message(TraceLevel.Info, "\r\nExtracting {0} to {1}\r\n", str1, Path.GetFullPath(Context.RootFolder));
            if (Directory.Exists(Context.RootFolder))
              PreExistingFiles.AddRange(Directory.GetFiles(Context.RootFolder, "*.*", SearchOption.AllDirectories));
            using (var zipReader = new ZipReader())
            {
              using (var diskWriter = new DiskWriter())
                Run(zipReader, diskWriter);
            }
            if (Context.PackageTypeArgument == SolutionPackageType.Both)
            {
              Context.ZipFile = path1;
              Context.IsManagedPackage = true;
              using (var zipReader = new ZipReader())
              {
                using (var diskWriter = new DiskWriter())
                  Run(zipReader, diskWriter);
              }
            }
            var path2 = Path.Combine(Context.RootFolder, "Resources");
            if (Directory.Exists(path2))
            {
              foreach (var str2 in Directory.GetFiles(path2, "*.*", SearchOption.AllDirectories))
              {
                if (PreExistingFiles.Contains(str2))
                  PreExistingFiles.Remove(str2);
              }
            }
            DeleteStrayFilesAsNecessary();
            break;
          case CommandAction.Pack:
            Logger.Message(TraceLevel.Info, "\r\nPacking {0} to {1}\r\n", Path.GetFullPath(Context.RootFolder), str1);
            using (var diskReader = new DiskReader())
            {
              using (var zipWriter = new ZipWriter())
                Run(diskReader, zipWriter);
            }
            if (Context.PackageTypeArgument != SolutionPackageType.Both)
              break;
            Context.ZipFile = path1;
            Context.IsManagedPackage = true;
            using (var diskReader = new DiskReader())
            {
              using (var zipWriter = new ZipWriter())
              {
                Run(diskReader, zipWriter);
                break;
              }
            }
          default:
            throw new NotImplementedException();
        }
      }
      finally
      {
        Trace.Flush();
      }
    }

    private void Run(IPackageReader reader, IPackageWriter writer)
    {
      var plugins = Context.ComponentConfigurationManager.ConfigurationSection.Plugins;
      var pluginContext = new PluginContext(Context);
      foreach (PluginConfigurationElement pluginConfig in plugins)
        InvokePlugin(pluginConfig, p => p.BeforeRead(pluginContext));
      Context.Customizations = new Customizations();
      reader.Initialize(Context);
      reader.Load();
      foreach (PluginConfigurationElement pluginConfig in plugins)
        InvokePlugin(pluginConfig, p => p.AfterRead(pluginContext));
      foreach (PluginConfigurationElement pluginConfig in plugins)
        InvokePlugin(pluginConfig, p => p.BeforeWrite(pluginContext));
      writer.Initialize(Context);
      writer.LocalizeComponents();
      writer.WriteComponents();
      foreach (PluginConfigurationElement pluginConfig in plugins)
        InvokePlugin(pluginConfig, p => p.AfterWrite(pluginContext));
      if (Helper.ReadOnlyFiles.Count > 0)
      {
        Logger.Message(TraceLevel.Error, "\r\nCould write the {0} read-only file(s)", Helper.ReadOnlyFiles.Count);
        foreach (var messageText in Helper.ReadOnlyFiles)
          Logger.Message(TraceLevel.Info, messageText);
      }
      Logger.Message(TraceLevel.Info, "\r\n{0} {1} complete.\r\n", (SolutionPackageType) (Context.IsManagedPackage ? 1 : 0), Context.Action);
    }

    private void InvokePlugin(PluginConfigurationElement pluginConfig, Action<IPackagePlugin> action)
    {
      try
      {
        action(pluginConfig.PluginInstance);
      }
      catch (PluginExecutionException ex)
      {
        ex.PluginName = pluginConfig.Name;
        throw;
      }
      catch (Exception ex)
      {
        throw new PluginExecutionException(ex.Message, ex)
        {
          PluginName = pluginConfig.Name
        };
      }
    }

    private void DeleteStrayFilesAsNecessary()
    {
      foreach (var str in Helper.WrittenFiles)
        PreExistingFiles.Remove(str);
      if (PreExistingFiles.Count <= 0)
        return;
      Logger.Message(TraceLevel.Warning, "\r\nThere are {0} unnecessary files", PreExistingFiles.Count);
      var allowDelete = Context.AllowDeletes;
      while (allowDelete == AllowDelete.Prompt)
      {
        Console.Write("Delete files? [Yes/No/List]:");
        switch ((Console.ReadLine() ?? "n").ToUpperInvariant())
        {
          case "Y":
          case "YES":
            allowDelete = AllowDelete.Yes;
            continue;
          case "N":
          case "NO":
            allowDelete = AllowDelete.No;
            continue;
          case "L":
          case "LIST":
            Console.WriteLine();
            foreach (object obj in PreExistingFiles)
              Console.WriteLine("  {0}", obj);
            Console.WriteLine();
            continue;
          default:
            continue;
        }
      }
      if (allowDelete == AllowDelete.Yes)
      {
        Logger.Message(TraceLevel.Info, "Deleting files...");
        foreach (var filename in PreExistingFiles)
          Helper.DeleteFile(filename);
      }
      else
        Logger.Message(TraceLevel.Info, "Not deleting files");
    }
  }
}
