using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FSWatchConsole
{
  public class Program
  {
    private static bool bNFOverload = false;
    private static NotifyFilters nf = new NotifyFilters();
    private static bool bIncludeSubDirs = true;

    private static bool DefineNotifyFilters(string _sArgKey)
    {
      switch (_sArgKey)
      {
        case "-local":
          bIncludeSubDirs = false;
          break;

        case "-la":
          bNFOverload = true;
          nf |= NotifyFilters.LastAccess;
          break;
        case "-lw":
          bNFOverload = true;
          nf |= NotifyFilters.LastWrite;
          break;
        case "-fn":
          bNFOverload = true;
          nf |= NotifyFilters.FileName;
          break;
        case "-dn":
          bNFOverload = true;
          nf |= NotifyFilters.DirectoryName;
          break;
        case "-ct":
          bNFOverload = true;
          nf |= NotifyFilters.CreationTime;
          break;
        case "-at":
          bNFOverload = true;
          nf |= NotifyFilters.Attributes;
          break;
        case "-sc":
          bNFOverload = true;
          nf |= NotifyFilters.Security;
          break;
        case "-sz":
          bNFOverload = true;
          nf |= NotifyFilters.Size;
          break;

        case "-all":
          bNFOverload = true;
          nf |= NotifyFilters.LastAccess;
          nf |= NotifyFilters.LastWrite;
          nf |= NotifyFilters.FileName;
          nf |= NotifyFilters.DirectoryName;
          nf |= NotifyFilters.CreationTime;
          nf |= NotifyFilters.Attributes;
          nf |= NotifyFilters.Security;
          nf |= NotifyFilters.Size;
          break;
        default:
          return false;
      }
      return true;
    }

    static void Main(string[] args)
    {
      if (args.Length < 1 || args[0] == "/?" || args[0] == "-?")
      {
        Console.WriteLine(About);
        return;
      }

      nf ^= nf;
      for (uint c = 0; c < (args.Length - 1); c++)
      {
        if (!DefineNotifyFilters(args[c]))
        {
          Console.WriteLine("Unrecognized argument: `{0}`", args[c]);
          return;
        }
      }

      string dir = args[args.Length-1];
      if (!Directory.Exists(dir))
      {
        Console.Write("Folder `{0}` not exists;", dir);
        return;
      }

      FileSystemWatcher fsw = new FileSystemWatcher();
      fsw.Path = dir;
      fsw.IncludeSubdirectories = bIncludeSubDirs;
      fsw.Filter = "";  // all
      if (bNFOverload)
      {
        fsw.NotifyFilter = nf;
      }
      else
      {
        fsw.NotifyFilter =
          NotifyFilters.LastAccess |
          NotifyFilters.LastWrite |
          NotifyFilters.FileName |
          NotifyFilters.DirectoryName;
      }
      
      fsw.Changed += new FileSystemEventHandler(fsw_Changed);
      fsw.Created += new FileSystemEventHandler(fsw_Changed);
      fsw.Deleted += new FileSystemEventHandler(fsw_Changed);
      fsw.Renamed += new RenamedEventHandler(fsw_Renamed);
      fsw.Error += new ErrorEventHandler(fsw_Error);
      
      // start
      fsw.EnableRaisingEvents = true;

      Console.Clear();
      Console.WriteLine("- Started, press `x` to stop...");
      Console.WriteLine(fsw.NotifyFilter.ToString() + ", Subfolders=" + bIncludeSubDirs);
      while (Console.Read() != 'x') ;
    }

    static void fsw_Error(object sender, ErrorEventArgs e)
    {
      WriteRecord(string.Format("ERROR> {0}\r\n"
        , e.GetException().Message));
    }

    private static void fsw_Renamed(object sender, RenamedEventArgs e)
    {
      WriteRecord(string.Format("{0} `{1}` to `{2}`"
        , GetChangeMark(e.ChangeType), e.OldFullPath, e.FullPath));
    }

    private static void fsw_Changed(object sender, FileSystemEventArgs e)
    {
      WriteRecord(string.Format("{0} `{1}`", GetChangeMark(e.ChangeType), e.FullPath));
    }

    private static void WriteRecord(string _str)
    {
      Console.WriteLine(GetTheMoment() + _str);
    }

    private static string GetChangeMark(WatcherChangeTypes _wct)
    {
      switch (_wct)
      {
        case WatcherChangeTypes.Changed: return "**";
        case WatcherChangeTypes.Created: return "++";
        case WatcherChangeTypes.Deleted: return "--";
        case WatcherChangeTypes.Renamed: return "~~";
        default:                         return "???";
      }
    }
    
    private static string GetTheMoment()
    {
      DateTime moment = DateTime.Now;
      return String.Format("{0}.{1:00}.{2:00}{3} {4:00}:{5:00}:{6:00}.{7:000} "
        , moment.Year, moment.Month
        , moment.Day, moment.DayOfWeek.ToString().Substring(0, 2).ToLower()
        , moment.Hour, moment.Minute, moment.Second, moment.Millisecond);
    }

    private static string About
    {
      get
      {
        return "About: Console implementation of a .Net class System.IO.FileSystemWatcher"
          + "\n  More information available online at:"
          + "\n  http://msdn.microsoft.com/en-us/library/system.io.filesystemwatcher.aspx"
          + "\n\nUsage:"
          + "\n  FSWatchConsole.exe [-local] [-all]|[[-la] [-lw] [-fn] [-dn] [-ct] [-at] [-sc] [-sz]] <folder>"
          + "\n\nArguments:"
          + "\n  -local        - watching specified folder local activity (recursively if omitted)"
          + "\n  -all          - set all the following..."
          + "\n  -la           - LastAccess (default)"
          + "\n  -lw           - LastWrite (default)"
          + "\n  -fn           - FileName (default)"
          + "\n  -dn           - DirectoryName (default)"
          + "\n  -ct           - CreationTime"
          + "\n  -at           - Attributes"
          + "\n  -sc           - Security"
          + "\n  -sz           - Size"
          + "\n\nLegend:"
          + "\n  **            - Changed"
          + "\n  ++            - Created"
          + "\n  --            - Deleted"
          + "\n  ~~            - Renamed"
          + "\n\nExample:"
          + "\n  this.exe c:\\tmp"
          + "\n"
          ;
      }
    }
  };
}
