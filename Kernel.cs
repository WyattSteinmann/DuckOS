using System;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;

namespace DuckOS.Core
{
    public class Kernel : Sys.Kernel
    {
        private shell Shell;
        private CosmosVFS FS;

        protected override void BeforeRun()
        {
            this.FS = new CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(this.FS);
            Shell = new shell();
            Console.WriteLine("Welcome To DuckOS");
        }

        protected override void Run()
        {
            Shell.run();
        }
    }
}
