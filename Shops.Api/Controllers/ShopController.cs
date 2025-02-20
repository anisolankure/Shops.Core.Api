﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shops.Core.Modules;
using Shops.Core.Services;

namespace Shops.Api.Controllers
{
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shop>>> GetShops()
        {
            return new OkObjectResult(await _shopService.GetAllShopsAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Shop>> GetShopById(int id)
        {
            var shop = await _shopService.GetShopByIdAsync(id);

            if (shop == null)
            {
                return NotFound();
            }

            return Ok(shop);
        }
    }
}