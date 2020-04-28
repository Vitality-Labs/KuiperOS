namespace KuiperOS {

    public abstract class KuiperManager {

        private Kernel kernel {get; set;}
 
        public KuiperManager(Kernel _kernel) {
            this.kernel = _kernel;
        }

        public abstract void Initialize();
        public abstract void Update();

    }

}