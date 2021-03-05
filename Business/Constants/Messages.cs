using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {

        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };

        public static string errorAll = "Incorrect operation please try again...";

        public static string carAdded = "The car was successfully added ";
        public static string carDelete = "The car was successfully deleted ";
        public static string carUpdate = "The car was successfully updated ";
        public static string carListAll = "Cars Listed ";
        public static string carFilter = "Car filtered";
        public static string carDetailDto = "Car Details";
        public static string carBrand = "cars sorted by brand ";
        public static string carColour = "cars sorted by colour ";


        public static string brandAdded = "Brand Added";
        public static string brandDeleted = "Brand Deleted";
        public static string brandUpdated = "Brand Updated";
        public static string brandListed = "Brand Listed";
        public static string brandGet = "Brand Filtered";


        public static string colorAdded = "Color Added";
        public static string colorDeleted = "Color Deleted";
        public static string colorUpdated = "Color Updated";
        public static string colorListed = "Color Listed";
        public static string colorGet = "Color Filtered";


        public static string customerAdded = "Customer Added";
        public static string customerDeleted = "Customer Deleted";
        public static string customerUpdated = "Customer Updated";
        public static string customerListed = "Customer Listed";
        public static string customerGet = "Customer Filtered";


        public static string userAdded = "User Added";
        public static string userDeleted = "User Deleted";
        public static string userUpdated = "User Updated";
        public static string userListed = "User Listed";
        public static string userGet = "User Filtered";


        public static string rentalAdded = "Rental Added";
        public static string rentalDeleted = "Rental Deleted";
        public static string rentalUpdated = "Rental Updated";
        public static string rentalListed = "Rental Listed";
        public static string rentalGet = "Rental Filtered";

        public static string CarImageMustBeExists = "Böyle bi resim bulunamadı";
        public static string AuthorizationDenied = "Yetkiniz Yok.";


    }
}
