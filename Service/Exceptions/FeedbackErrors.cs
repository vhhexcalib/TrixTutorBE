using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class FeedbackErrors
    {
        public static Error FailCreatingFeedback => new("Create feedback", "Feed back thất bại.");
    }
}
