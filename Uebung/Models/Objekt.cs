namespace Uebung.Models
{
    public class Objekt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public List<ListenObjekt> ListenObjekt { get; set; } = new List<ListenObjekt>();
    }
}
