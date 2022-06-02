using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoApiDTO.DAL.Context
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
