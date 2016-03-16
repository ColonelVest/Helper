using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Day
    {
        public List<Period> Periods
        {
            get;
            set;
        }

        public int DayID
        {
            get;
            set;
        }

        public string UserID
        {
            get;
            set;
        }

        public bool IsMade
        {
            get;
            set;
        }

        public DateTime StartTime
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }
    }
}
