using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Abstract
{
    public interface IRepository
    {
        IEnumerable<Period> Periods
        {
            get;
        }

        IEnumerable<Day> Days
        {
            get;
        }

        void ConfirmEndPeriod(int periodId);
        void InsertPeriod(Period period);
        void AddSchedule(Day day);
    }
}
