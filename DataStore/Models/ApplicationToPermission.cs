namespace DataStore.Models
{
    public class ApplicationToPermission
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public virtual Application Application { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Permission { get; set; }

    }
}
