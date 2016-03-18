using Domain.Abstract;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public static class GetMocks
    {
        public static Mock<IRepository> GetPeriodMock()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(m => m.Periods).Returns(new List<Period>
            {
                new Period { PeriodId = 1, Number = 1, IsMade = false },
                new Period { PeriodId = 2, Number = 2, IsMade = true },
                new Period { PeriodId = 3, Number = 3, IsMade = false },
                new Period { PeriodId = 4, Number = 4, IsMade = true },
                new Period { PeriodId = 12, Number = 12, IsMade = true },
                new Period { PeriodId = 21, Number = 21, IsMade = false },
                new Period { PeriodId = 31, Number = 31, IsMade = false },
                new Period { PeriodId = 41, Number = 41, IsMade = true }
            });
            return mock;
        }

        public static Mock<IRepository> GetDayMock()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(m => m.Days).Returns(new List<Day>
            {
                new Day
                {
                    DayID = 1,
                    Date = new DateTime(2010, 1, 10),
                    Periods = new List<Period>
                    {
                        new Period { PeriodId = 1, Number = 1, IsMade = false },
                        new Period { PeriodId = 2, Number = 2, IsMade = true },
                        new Period { PeriodId = 3, Number = 3, IsMade = false },
                        new Period { PeriodId = 4, Number = 4, IsMade = true }
                    }
                },
                new Day
                {
                    DayID = 2,
                    Date = new DateTime(2016, 3, 17),
                    Periods = new List<Period>
                    {
                        new Period { PeriodId = 12, Number = 12, IsMade = true },
                        new Period { PeriodId = 21, Number = 21, IsMade = false },
                        new Period { PeriodId = 31, Number = 31, IsMade = false },
                        new Period { PeriodId = 41, Number = 41, IsMade = true }
                    }
                }
            });
            return mock;
        }
    }
}
