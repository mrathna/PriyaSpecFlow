using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowPOC.CommonUtil
{
    [Binding]
    class CustomArgumentTransform
    {
        [StepArgumentTransformation(@"current date as per (\d+)")]
        public DateTime AddDateToCurrentDate(int daysCount)
        {
            return DateTime.Now.AddDays(daysCount);
        }
    }
}
