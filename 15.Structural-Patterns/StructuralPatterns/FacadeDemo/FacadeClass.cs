namespace FacadeDemo
{
    using System;

    public class Facade
    {
        private SubSystemA a = new SubSystemA();

        private SubSystemB b = new SubSystemB();

        private SubSystemC c = new SubSystemC();

        public void FacadeOperation1()
        {
            Console.WriteLine("Operation 1\n" +
            this.a.OperationA1() +
            this.a.OperationA2() +
            this.b.OperationB1());
        }

        public void FacadeOperation2()
        {
            Console.WriteLine("Operation 2\n" +
            this.b.OperationB2() +
            this.c.OperationC1() +
            this.c.OperationC2());
        }
    }
}
