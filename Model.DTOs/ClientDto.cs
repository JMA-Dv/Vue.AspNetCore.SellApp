using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.DTOs
{
    //public class ClientCreateDto
    //{
    //    [Required]
    //    public string Name { get; set; }
    //}
    
    public class ClientUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string Name { get; set; }

    }
}
