using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DtoLayer.DashboardDtos
{
    public class AdminDashboardDto
    {
        public int MessageCount { get; set; }
        public int NonReadedMessageCount { get; set; }
        public int ReadedMessageCount { get; set; }
        public int CarCount { get; set; }
        public int RentedCarCount { get; set; }
        public int BrandCount { get; set; }
        public int BranchCount { get; set; }
        public int UserCount { get; set; }
        public int ServiceCount { get; set; }
        public int PendingBookingCount { get; set; }
        public double AverageCarRating { get; set; }
        public int Total5StarReview { get; set; }
    }
}
