using System;
using System.Collections.Generic;
using System.Text;

namespace KuiperOS {
    public class IOHandler {

        public string GetInput() {
            return Console.ReadLine();
        }

        public void Output(string output) {
            Console.WriteLine(output);
        }

    }
}