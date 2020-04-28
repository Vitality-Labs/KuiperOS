using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace KuiperOS {
    public class Kernel : Sys.Kernel {

        private IOHandler ioHandler;
        private CommandHandler commandHandler;
        private Sys.FileSystem.CosmosVFS fileSystem;

        bool testRun = false;

        protected override void BeforeRun() {
            fileSystem = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fileSystem);
            ioHandler = new IOHandler();
            commandHandler = new CommandHandler(this);
            Console.Clear();
            Console.WriteLine("Kuiper OS booted successfully.");
        }
        protected override void Run() {
            Console.Write("> ");
            ioHandler.Output(commandHandler.RunCommand(ioHandler.GetInput()));
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
