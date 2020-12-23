using FinancialManager.Models.Enums;
using FinancialManager.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialManager.Models
{
    public class SupplierFilePattern : IEntity
    {
        /// <summary>
        /// Object identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Pattern file extension.
        /// </summary>
        public FileExtension FileExtension { get; set; }

        /// <summary>
        /// JSON string with the fields pattern indicating the field name and its position at the file properties.
        /// Ex:
        /// {
        ///     "Description": 0,
        ///     "Type": 1,
        ///     "DueDate": 2,
        ///     "BillingValue": 3,
        ///     "PaymentDate": 4,
        ///     "AmountPayed": 5
        /// }
        /// </summary>
        public string FieldsPattern { get; set; }

        /// <summary>
        /// Supplier document.
        /// </summary>
        public string Document { get; set; }

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
