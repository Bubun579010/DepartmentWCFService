using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DepartmentWCFService
{
    [DataContract]
    public class DepartmentEntity
    {
        [DataMember]
        [Required(ErrorMessage = "ID is required")]
        public int ID { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50,MinimumLength = 2, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(200,MinimumLength = 10, ErrorMessage = "Description cannot exceed 50 characters")]
        public string Description { get; set; }

        [DataMember]
        public bool Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}