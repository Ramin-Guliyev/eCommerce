using Application.Basket.Commands.AddProductToBasket;
using Application.Basket.Commands.CreateBasket;
using Application.Basket.Queries.GetUserBasketByEmail;
using Application.Common.Security;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _mediator.Send(new GetUserBasketByEmailQuery("ramin@ramin.com"));

            return Ok(result);
        }

        [HttpGet("/add")]
        public IActionResult Add()
        {
            var result = _mediator.Send(new AddProductToBasketCommand("ramin@ramin.com",
                new Domain.Entities.Product
                {
                    Description = "salam",
                    ImgUrl = "asf",
                    Name = "asacas",
                    Price = 25,
                    SKU = "salam"
                }));


            return Ok(result);
        }

        [HttpGet("/create")]
        public IActionResult Create()
        {
            var result = _mediator.Send(new CreateBasketCommand(new Domain.Entities.Basket
            {
                CustomerEmail = "ramin@ramin.com",
                BasketItems = new List<Domain.Entities.BasketItem>()
                {
                    new Domain.Entities.BasketItem{
                        CustomerEmail = "ramin@ramin.com",
                        ImgUrl ="salam",
                        ProductID = 1,
                        ProductName ="asacas",
                        Quantity = 1,
                        UnitPrice=25,
                        ID = 1
                    },
                     new Domain.Entities.BasketItem{
                        CustomerEmail = "ramin@ramin.com",
                        ImgUrl ="salam",
                        ProductID = 1,
                        ProductName ="asacas",
                        Quantity = 1,
                        UnitPrice=25,
                        ID = 2
                    }
                },
                ID = 1
            }));

            return Ok(result);
        }
    }
}
