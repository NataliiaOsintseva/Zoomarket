namespace Zoomarket.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string PetName { get; set; }
        public string PetSpecies { get; set; }
        public int OwnerId { get; set; }
        public virtual Owner Owner{ get; set;}
    }
}