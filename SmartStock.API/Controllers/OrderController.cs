﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartStock.Domain.DTO;
using SmartStock.Domain.Entities;
using SmartStock.Domain.Interfaces.Services;
using SmartStock.Domain.Models;

namespace SmartStock.API.Controllers
{
    [ApiController]
    [Route("/api/{controller}")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("date"), Authorize]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByDate([FromBody] DateFilterModel filter)
        {
            try
            {
                var initial = DateTime.Parse(filter.InitialDate);
                var end = DateTime.Parse(filter.EndDate);
                var orders = await _orderService.GetOrdersByDate(initial, end);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{orderId}"), Authorize]
        public async Task<ActionResult<Order>> GetOrderById(int orderId)
        {
            try
            {
                var order = await _orderService.GetOrderById(orderId);
                if (order == null)
                {
                    return NotFound("Orçamento não encontrado!");
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/details/{orderId}"), Authorize]
        public async Task<ActionResult<OrderDetail>> GetOrderDetailsById(int orderId)
        {
            try
            {
                var order = await _orderService.GetOrderDetailsById(orderId);
                if (order == null)
                {
                    return NotFound($"Detalhes do orçamento {orderId} não encontrado!");
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Authorize]
        public async Task<ActionResult<Order>> NewOrder(OrderDTO order)
        {
            try
            {
                var newOrder = await _orderService.NewOrder(order);

                return Ok(newOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut, Authorize]
        public async Task<ActionResult> UpdateUser(Order order)
        {
            try
            {
                var updateOrder = await _orderService.UpdateOrder(order);
   
                return Ok(updateOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var deleteOrder = await _orderService.DeleteOrderById(id);

                return Ok(deleteOrder);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
