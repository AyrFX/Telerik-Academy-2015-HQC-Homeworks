namespace FlyweightDemo
{
    using System;
    using System.Collections.Generic;

    public class FlyweightFactory
    {
        private Dictionary<int, Flyweight> flyweightList = new Dictionary<int, Flyweight>();
 
        public Flyweight GetFlyweight(int type)
        {
            Flyweight flyweight = null;

            if (this.flyweightList.ContainsKey(type))
            {
                flyweight = this.flyweightList[type];
            }
            else
            {
                switch (type)
                {
                    case 1:
                        flyweight = new ConcreteFlyweight1();
                        break;
                    case 2:
                        flyweight = new ConcreteFlyweight2();
                        break;
                    case 3:
                        flyweight = new ConcreteFlyweight3();
                        break;
                }

                this.flyweightList.Add(type, flyweight);
            }

            return flyweight;
        }
    }
}
