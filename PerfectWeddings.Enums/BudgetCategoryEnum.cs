using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Enums
{
    public enum BudgetCategoryEnum
    {
        [Description("Fashion and Beauty")]
        FashionAndBeauty = 1,
        [Description("Reception")]
        Reception = 2,
        [Description("Ceremoony")]
        Ceremoony = 3,
        [Description("WeddingRings")]
        WeddingRings = 4,
        [Description("Photo and Video")]
        PhotoAndVideo = 5,
        [Description("Decorations")]
        Decorations = 6,
        [Description("Flowers")]
        Flowers = 7,
        [Description("Entertainment")]
        Entertainment = 8,
        [Description("Stationery")]
        Stationery = 9,
        [Description("Gifts")]
        Gifts = 10,
        [Description("Wedding Cake")]
        WeddingCake = 11,
        [Description("Transportation and Accommodation")]
        TransportationAndAccommodation = 12
    }
}
