using FinancialManager.Models;
using FinancialManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace FinancialManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly IBillService _billService;
        private readonly ILogger<SupplierController> _logger;

        public SupplierController(
            ISupplierService supplierService,
            IBillService billService,
            ILogger<SupplierController> logger)
        {
            _supplierService = supplierService;
            _billService = billService;
            _logger = logger;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddSupplier([FromBody] SupplierDTO supplier)
        {
            _supplierService.Add(supplier);

            return Ok();
        }

        [HttpPost]
        [Route("{id}/update")]
        public IActionResult UpdateSupplier(int id, [FromBody] SupplierDTO supplier)
        {
            _supplierService.Update(id, supplier);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public IActionResult AddSupplier(int id)
        {
            var supplier = _supplierService.Find(id);
            if (supplier != null)
            {
                _supplierService.Delete(supplier);
            }

            return Ok();
        }

        [HttpGet]
        [Route("{id}/get")]
        public IActionResult GetSupplier(int id)
        {
            var supplier = _supplierService.Find(id);

            return Ok(supplier);
        }

        [HttpGet]
        [Route("{id}/getbillsfromperiod")]
        public IActionResult GetSupplierBillsFromPeriod(int id, DateTime? startDate, DateTime? endDate)
        {
            startDate ??= DateTime.MinValue;
            endDate ??= DateTime.MaxValue;

            var bills = _billService.GetSupplierBillsFromPeriod(id, startDate.Value, endDate.Value);

            return Ok(bills);
        }
    }
}
