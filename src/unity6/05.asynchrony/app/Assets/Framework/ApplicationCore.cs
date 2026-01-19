using UnityEngine;
using System.Threading.Tasks;
using System;

namespace Assets.Framework
{
    public class ApplicationCore
    {
        // Static instance
        private static ApplicationCore mInstance;
        public int count;
        // Static method
        public static ApplicationCore getInstance() {
            if (mInstance == null)
                mInstance = new ApplicationCore();
            return mInstance; }
        // Singletion pattern :
        // Constructor
        private ApplicationCore()
        {
            Debug.Log("Application instance startup.");
        }
        // Facade pattern :
        // System statup method
        public ApplicationCore SystemStartup()
        {
            Debug.Log("Application system startup.");
            return this;
        }
        // Module startup method
        public ApplicationCore ModuleStatrup()
        {
            Debug.Log("Application module startup.");
            this.count = 0;
            return this;
        }

        public async void RunCount()
        {
            // Wait for 1 second asynchronously (1000 milliseconds)
            await Task.Delay(5000);
            //
            this.count = (new System.Random()).Next(1, 500);
        }
    }
}
