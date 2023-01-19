using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Burger20106733.Pages.BurgerTest
{
    public class PurchaseModel : PageModel
    {
        public void OnGet(int BurgerType, int BurgerCount=1)
        {
            string burgerName = "";
            string burgerImg = "";
            int addmore = BurgerCount + 1;
            float sum = 0;

            switch(BurgerType)
            {
                case 1:
                    burgerName = "BLT Whopper";
                    burgerImg = "BLT_whopper.jpg";
                    sum = 10.50f * addmore;
                    break;
                case 2:
                    burgerName = "Grilled Chicken";
                    burgerImg = "Grilled_chicken.jpg";
                    sum = 8.50f * addmore;
                    break;
                case 3:
                    burgerName = "Angus Beef";
                    burgerImg = "Angus_beef.jpg";
                    sum = 9.00f * addmore;
                    break;
                case 4:
                    burgerName = "Vegetarian";
                    burgerImg = "Vegetarian.jpg";
                    sum = 7.00f * addmore;
                    break;
            }

            ViewData["BurgerName"] = burgerName;
            ViewData["BurgerImage"] = burgerImg;
            ViewData["Price"] = sum;
        }
    }
}
