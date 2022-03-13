using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderItem.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace OrderItem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetCartBy(int id)
        {

            using (HttpClient client = new HttpClient())
            {

                var responseTask = client.GetAsync("MenuItem");
                responseTask.Wait();
                var result = responseTask.Result;


                List<Cart> ltems = new List<Cart>();


                if (result.IsSuccessStatusCode)
                {

                    string jsonData = result.Content.ReadAsStringAsync().Result;


                    ltems = JsonConvert.DeserializeObject<List<Cart>>(jsonData);
                    Cart obj1 = ltems.SingleOrDefault(item => item.Id == id);

                    //Cart obj = new Cart();
                    obj1.menuItemId = 1;
                    obj1.userId = 1;


                    return Ok(obj1);

                }
                else
                {

                    return BadRequest();

                }

            };

        }

    }

}
