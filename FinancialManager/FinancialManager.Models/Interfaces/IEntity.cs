using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialManager.Models.Interfaces
{
    public interface IEntity
    {
        int Id { get; }

        /// <summary>
        /// Gets/Sets the creation date
        /// </summary>
        /// <value>
        /// The creation date
        /// </value>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets/Sets last update date
        /// </summary>
        /// <value>
        /// The date of the last update
        /// </value>
        DateTime LastUpdatedAt { get; set; }
    }
}
