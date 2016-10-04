using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectWeddings.Enums
{
    public enum SupplierCategoryEnum
    {
        [Description("Jewellery and Wedding Rings")]
        JewelleryAndWeddingRings = 1,

        [Description("Venues")]
        Venues = 2,

        [Description("Photography Videography & Cinematography")]
        PhotographyVideographyAndCinematography = 3,

        [Description("Fashion & Clothing")]
        FashionAndClothing = 4,

        [Description("Footwear")]
        Footwear = 5,

        [Description("Florists & Bouquets")]
        FloristsAndBouquets = 6,

        [Description("Cake")]
        Cake = 7,

        [Description("Music DJs & Entertainment")]
        MusicDJsAndEntertainment = 8,

        [Description("Wedding Preparation & Planner")]
        WeddingPreparationAndPlanner = 9,

        [Description("Decorators & Wedding Stylist")]
        DecoratorsAndWeddingStylist = 10,

        [Description("Drinks & Beverages")]
        DrinksAndBeverages = 11,

        [Description("Fireworks for Wedding")]
        FireworksForWedding = 12,

        [Description("Food & Catering")]
        FoodAndCatering = 13,

        [Description("Honeymoon & Accommodation (In Mauritius)")]
        HoneymoonAndAccommodation = 14,

        [Description("Invitation Cards & Wedding Stationary")]
        InvitationCardsAndWeddingStationary = 15,

        [Description("Make-up Hair & Nail & Henna")]
        MakeupHairAndNailAndHenna = 16,

        [Description("Marriage Celebrant")]
        MarriageCelebrant = 17,

        [Description("Wedding Cars & Transport")]
        WeddingCarsAndTransport = 18,

        [Description("Other Party Products Supplies & Accessories")]
        OtherPartyProductsSuppliesAndAccessories = 19

    }
}
