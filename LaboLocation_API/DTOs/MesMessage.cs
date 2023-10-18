namespace LaboLocation_API.DTOs
{
    public class MesMessage
    {
        public int Id_message { get; set; }
        public int Id_personne { get; set; }
        public string Mess { get; set; }
        public bool Lu { get; set; }
        public DateTime Date_post { get; set; }
        public int Id_p_receive { get; set; }
    }
}
//m.Id_message,me.Id_personne,m.Mess,m.Lu,m.Date_post,me.Id_p_receive 