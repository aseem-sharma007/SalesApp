namespace FluorSalesApp.Models
{
    public class SalesRepresentative
    {
        /// <summary>
        /// Gets or sets the unique identifier for the sales representative.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the sales representative.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the platform associated with the sales representative.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the platform associated with the sales representative.
        /// </summary>
        public string Platform { get; set; }
        /// <summary>
        /// Gets or sets the region where the sales representative operates.
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Gets or sets the status of the sales representative.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
