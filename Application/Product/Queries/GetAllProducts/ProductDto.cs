﻿namespace Application.Product.Queries.GetAllProducts
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;
    }
}