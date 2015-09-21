namespace CompositeDemo
{
    using System;
    using System.Collections.Generic;

    public abstract class CompositeClass
    {
        public abstract void DoSomething();
    }

    public class SimpleObject : CompositeClass
    {
        public override void DoSomething()
        {
            Console.WriteLine("Simple object something done!");
        }
    }

    public class CompositeObject : CompositeClass
    {
        private List<CompositeClass> children;

        public override void DoSomething()
        {
            foreach (var child in this.children)
            {
                child.DoSomething();
            }
        }

        public void AddChild(CompositeClass child)
        {
            this.children.Add(child);
        }

        public void RemoveChild(CompositeClass child)
        {
            this.children.Remove(child);
        }
    }
}
