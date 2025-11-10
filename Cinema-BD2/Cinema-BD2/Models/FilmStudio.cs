namespace Cinema_BD2.Models
{
    public class FilmStudio
    {
        public int FilmId { get; set; }
        public Film Film { get; set; }

        public int StudioId { get; set; }
        public Studio Studio { get; set; }
    }
}
