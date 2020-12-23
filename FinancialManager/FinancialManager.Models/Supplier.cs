using FinancialManager.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace FinancialManager.Models
{
    public class Supplier : IEntity
    {
        public Supplier()
        {
            Bills = new List<Bill>();
            FilesPatterns = new List<SupplierFilePattern>();
        }

        /// <summary>
        /// Object identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Supplier name.
        /// </summary>
        public string Name { get; set; }

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
        /// Supplier bills.
        /// </summary>
        public virtual ICollection<Bill> Bills { get; set; }

        /// <summary>
        /// Supplier files pattern.
        /// </summary>
        public virtual ICollection<SupplierFilePattern> FilesPatterns { get; set; }
    }
}
