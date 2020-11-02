using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace e4_ContactsProject.Utils
{
    public class Extensions
    {
        public static IEnumerable<SelectListItem> GetTitleList()
        {
            IList<SelectListItem> ctypes = new List<SelectListItem>
                {
                    new SelectListItem() {Text="Select", Value=""},
                    new SelectListItem() {Text="Mr", Value="Mr"},
                    new SelectListItem() { Text="Ms", Value="Ms"},
                    new SelectListItem() { Text="Miss", Value="Miss"}
                };
            return ctypes;
        }

        public static IEnumerable<SelectListItem> GetGenderList()
        {
            IList<SelectListItem> genders = new List<SelectListItem>
            {
                new SelectListItem() {Text="Select", Value=""},
                new SelectListItem() {Text="Male", Value="Male"},
                new SelectListItem() { Text="Female", Value="Female"}
            };
                return genders;
        }
    } 
}