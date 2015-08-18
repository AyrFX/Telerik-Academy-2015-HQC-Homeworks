public class Chef
    {
        public void Cook()
        {
            Potato potato = GetPotato();
            Carrot carrot = GetCarrot();
            Bowl bowl = GetBowl();

            int potatosNeeded = 2;
            for (int i = 0; i < potatosNeeded; i++)
            {
                Peel(potato);
                //Cut(potato);
                bowl.Add(potato);
            }

            int carrotsNeeded = 2;
            for (int i = 0; i < carrotsNeeded; i++) {
                Peel(carrot);
                //Cut(carrot);
                bowl.Add(carrot);
            }
        }

        private Potato GetPotato()
        {
            //...
        }

        private Carrot GetCarrot()
        {
            //...
        }

        private Bowl GetBowl()
        {
            //... 
        }

        private void Peel(Vegetable potato)
        {
            //...
        }

        private void Cut(Vegetable potato)
        {
            //...
        }
    }