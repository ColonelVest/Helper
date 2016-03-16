using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Period
    {
        public int PeriodId
        {
            get;
            set;
        }

        public int DayId
        {
            get;
            set;
        }

        public int Number
        {
            get;
            set;
        }

        public string Comment
        {
            get;
            set;
        }

        public bool IsMade
        {
            get;
            set;
        }

        [Required]
        public int Duration
        {
            get;
            set;
        }

        [Required]
        public string Description
        {
            get;
            set;
        }


    }
}
