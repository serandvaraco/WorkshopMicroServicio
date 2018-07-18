using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ShoppingCartPortal.Pages
{
    public class IndexModel : PageModel
    {

        public void OnGet()
        {
            LoadProductsAsync().ContinueWith(async (x) => ViewData["products"] = await x).Wait();
        }

        /// <summary>
        /// Loads the products.
        /// </summary>
        private async Task<IEnumerable<ProductModel>> LoadProductsAsync()
        {
            using (HttpClient http = new HttpClient())
            {
                http.BaseAddress = new Uri("http://localhost:50140/api/");

                var response = await http.GetAsync("products");
                if (!response.IsSuccessStatusCode)
                    return Enumerable.Empty<ProductModel>();

                var resultObject =
                    JsonConvert.DeserializeObject<ProductModel[]>(
                        await response.Content.ReadAsStringAsync());

                return resultObject;
            }
        }
    }
}
