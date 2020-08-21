using System.Linq;

namespace DataStore.Models
{
    public class SidebarMenus
    {

        public SidebarMenus(string permisssions)
        {
            this.Permisssion = permisssions;
        }
        public SidebarMenus()
        {

        }
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string LinkName { get; set; }
        public string Parameters { get; set; }
        private string Permisssion { get; set; } = string.Empty;
        public string[] Permisssions {
            get {
               return string.IsNullOrEmpty(this.Permisssion) ? new string[0] :
                                     this.Permisssion.Split(',').ToArray();
            }
        }
    }
}
