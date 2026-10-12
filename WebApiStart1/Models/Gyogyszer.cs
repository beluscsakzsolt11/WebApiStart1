namespace WebApiStart1.Models
{
    public class Gyogyszer
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Hatoanyag { get; set; }=string.Empty;
        public bool Venykoteles { get; set; }
        public string kepnev { get; set; }=string.Empty;
    }
}