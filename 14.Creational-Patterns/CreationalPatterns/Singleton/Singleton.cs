namespace Singleton
{
    using System.Runtime.CompilerServices;

    internal class Singleton
    {
        private static Singleton instance;

        private int exampleField;

        private Singleton()
        {
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                return new Singleton();
            }
            else
            {
                return instance;
            }
        }

        public void ExampleMethod()
        {
        }
    }
}