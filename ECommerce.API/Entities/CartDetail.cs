﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.API.Entities
{
    [Table("TB_CARD_DETAIL")]
    public class CartDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("CartHeaderId")]
        public int CartHeaderId { get; set; }
        public virtual CartHeader? CartHeader { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int Count { get; set; }

    }
}
