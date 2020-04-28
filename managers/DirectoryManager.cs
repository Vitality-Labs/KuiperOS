namespace KuiperOS {
    public class DirectoryManager : KuiperManager {

        private string CurrentDirectory {get; set;}

        public DirectoryManager(Kernel kernel) : base (kernel) {

        }

        public override void Initialize() {
            CurrentDirectory = @"0:\";
        }

        public override void Update() {

        }

    }
}