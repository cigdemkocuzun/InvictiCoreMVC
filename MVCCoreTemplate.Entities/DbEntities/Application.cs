
using MVCCoreTemplate.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MVCCoreTemplate.Entities.DbEntities
{
    public class Application : IEntitiy
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Url { get; set; }

        public string Description { get; set; }

        public int MonitoringInterval { get; set; }
    }

}
