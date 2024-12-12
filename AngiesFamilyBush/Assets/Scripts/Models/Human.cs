using System.Collections.Generic;

namespace Assets.Scripts.Models
{
    public  class Human
    {
        public Human Mother { get; set; }
        public Human Father { get; set; }
        public List<Human> Parents => new List<Human> { Mother, Father };

        public Sex Sex { get; set; }
        
        // ?
        // public List<Human> Sublings { get; set; }

        public List<Human> Children {  get; set; }
    }

    public enum Sex
    {
        Banana,
        Peach
    }
}
