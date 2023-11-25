using System;

namespace TemplateApplication.Models
{
    public class UserDetail
    {
        public int? ID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool? IsDeleted { get; set; }
        public int? UserRoll { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }



}
