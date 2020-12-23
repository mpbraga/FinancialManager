using FinancialManager.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialManager.Models
{
    public class Bill : IEntity
    {
        /// <summary>
        /// Object identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Billing description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Billing type.
        /// </summary>
        public BillType? Type { get; set; }

        /// <summary>
        /// Billing due date.
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Bill payment date.
        /// </summary>
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Billing value.
        /// </summary>
        public decimal BillingValue { get; set; }

        /// <summary>
        /// Bill amount payed with taxes.
        /// </summary>
        public decimal AmountPayed { get; set; }

        /// <summary>
        /// Creation date.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Last update date.
        /// </summary>
        public DateTime LastUpdatedAt { get; set; }

        /// <summary>
        /// Supplier id.
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Supplier.
        /// </summary>
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
    }
}
