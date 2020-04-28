using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace KuiperOS {
    public class Kernel : Sys.Kernel {

        private GraphicsManager graphicsManager {get; set;}
        private DirectoryManager directoryManager {get; set;}
        private IOHandler ioHandler {get; set;}
        private CommandHandler commandHandler {get; set;}
        private Sys.FileSystem.CosmosVFS fileSystem {get; set;}

        protected override void BeforeRun() {
            fileSystem = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fileSystem);
            ioHandler = new IOHandler();
            commandHandler = new CommandHandler(this);
            graphicsManager = new GraphicsManager(this);
            graphicsManager.Initialize();
            directoryManager = new DirectoryManager(this);
            directoryManager.Initialize();
            Console.Clear();
            Console.WriteLine("Kuiper OS booted successfully.");
        }
        protected override void Run() {
            graphicsManager.Update();
            directoryManager.Update();
        }

        public void RunTest() {
            var testFile = @"0:\test.txt";

            if (!File.Exists(testFile)) {
                Console.WriteLine("Creating test file!");
                File.Create(testFile);
            } else {
                Console.WriteLine("Test file already exists...deleting!");
                File.Delete(testFile);
            }

        }
    }
}
