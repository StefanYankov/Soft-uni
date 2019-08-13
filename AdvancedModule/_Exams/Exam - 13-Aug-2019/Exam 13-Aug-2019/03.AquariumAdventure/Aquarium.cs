using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquariumAdventure
{
    public class Aquarium
    {
        //private Dictionary<string, Fish> fishInPool;
        private List<Fish> fishInPool;

        public Aquarium(string name, int capacity, int size)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
            this.fishInPool = new List<Fish>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Size { get; set; }

        public int Count => this.fishInPool.Count;

        public void Add(Fish fish)
        {
            if (this.Count < this.Capacity)
            {
                this.fishInPool.Add(fish);
            }
        }

        public bool Remove(string name)
        {
            bool result = false;
            Fish fishToRemove = this.fishInPool.FirstOrDefault(f => f.Name == name);

            if (this.fishInPool.Contains(fishToRemove))
            {
                result = true;
                this.fishInPool.Remove(fishToRemove);
            }

            return false;
        }

        public Fish FindFish(string name)
        {
            Fish findCurrentFish = this.fishInPool.FirstOrDefault(f => f.Name == name);


                return findCurrentFish;

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Aquarium: {this.Name} ^ Size: {this.Size}");
            foreach (var fish in fishInPool)
            {
                sb.AppendLine($"{fish.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
