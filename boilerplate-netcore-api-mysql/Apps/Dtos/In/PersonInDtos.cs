using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace boilerplate_netcore_api_mysql.Apps.Dtos.In
{
    /// <summary>
    /// 
    /// </summary>
    public class PersonInDtos
    {
        /// <summary>
        /// This value for Name
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
