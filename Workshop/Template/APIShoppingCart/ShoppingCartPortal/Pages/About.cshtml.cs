using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ShoppingCartPortal.Pages
{
    public class AboutModel : PageModel
    {
        public void OnGet()
        {
            GetShoppingCartAsync()
                .ContinueWith(async (x) => ViewData["products"] = await x).Wait();
        }

        public async Task<IEnumerable<ProductModel>> GetShoppingCartAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://apishoppingcart/api/");
                    var response = await client.GetAsync("ShoppingCart");
                    if (!response.IsSuccessStatusCode)
                        return Enumerable.Empty<ProductModel>();

                    return JsonConvert.DeserializeObject<ProductModel[]>(
                        await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<ProductModel>();
            }
        }

        public void ProcessOrder()
        {

        }
    }
}
