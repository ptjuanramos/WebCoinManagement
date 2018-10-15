namespace WebCoinManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Coins
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public int? CategoryID { get; set; }

        public int Counter { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string CoinType { get; set; }

        [Required]
        [StringLength(255)]
        public string FacialValue { get; set; }

        [Required]
        [StringLength(255)]
        public string MarketValue { get; set; }

        [Required]
        [StringLength(255)]
        public string Country { get; set; }

        [Required]
        [StringLength(255)]
        public string CoinDate { get; set; }

        public virtual CoinsCategory CoinsCategory { get; set; }

        public virtual Users Users { get; set; }
    }
}
