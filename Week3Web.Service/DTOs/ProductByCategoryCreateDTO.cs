namespace Week3Web.Service.DTOs
{
    public class ProductByCategoryCreateDTO
    {
        public ProductCreateDTO newProduct { get; set; }
        public Guid CategoryId { get; set; }
    }
}
