using MVCCoreTemplate.Entities.DbEntities;
using System.ComponentModel.DataAnnotations;


namespace MVCCoreTemplate.Models.ApplicationViewModels
{
    public class ApplicationViewModel
    {
        //[Required]
        //public int ApplicationId { get; set; }

        //[Required]
        //[MaxLength(100)]
        //public string Name { get; set; }

        //[Required]
        //[MaxLength(50)]
        //[Url]
        //public string Url { get; set; }

        //public string Description { get; set; }

        //[Display(Name = "Monitoring Interval (minutes)")]
        //public int MonitoringInterval { get; set; }

        public Application Application { get; set; }
    }
}
