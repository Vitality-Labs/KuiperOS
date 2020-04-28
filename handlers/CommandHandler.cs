using System;
using System.Collections.Generic;
using System.Text;

namespace KuiperOS {

    public class CommandHandler {

        private Kernel kernel;

        public CommandHandler(Kernel _kernel) {
            this.kernel = _kernel;
        }

        private string[] commands = new string[] {
            "clr", // clear
            "test",
        };

        public string RunCommand(string command) {

            int commandIndex = -1;

            for (int i = 0; i < commands.Length; i++) {
                if (command.ToLower().Equals(commands[i])) {
                    commandIndex = i;
                }
            }

            if (commandIndex != -1) {

                switch (commandIndex) {
                    case 0:
                        Console.Clear();
                        return "";
                    case 1:
                        kernel.RunTest();
                        return "";
                }

            }
                return "'" + command+ "' command not found!";
        }

    }

}