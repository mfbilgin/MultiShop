using AutoMapper;
using MultiShop.Catalog.Dtos.Category;
using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Dtos.ProductImage;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping;

public sealed class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Category,CategoryResultDto>().ReverseMap();
        CreateMap<Category,CategoryCreateDto>().ReverseMap();
        CreateMap<Category,CategoryUpdateDto>().ReverseMap();
        CreateMap<Category,CategoryGetByIdDto>().ReverseMap();
        
        CreateMap<Product,ProductResultDto>().ReverseMap();
        CreateMap<Product,ProductCreateDto>().ReverseMap();
        CreateMap<Product,ProductUpdateDto>().ReverseMap();
        CreateMap<Product,ProductGetByIdDto>().ReverseMap();
        
        CreateMap<ProductDetail,ProductDetailResultDto>().ReverseMap();
        CreateMap<ProductDetail,ProductDetailCreateDto>().ReverseMap();
        CreateMap<ProductDetail,ProductDetailUpdateDto>().ReverseMap();
        CreateMap<ProductDetail,ProductDetailGetByIdDto>().ReverseMap();
        
        CreateMap<ProductImage,ProductImageResultDto>().ReverseMap();
        CreateMap<ProductImage,ProductImageCreateDto>().ReverseMap();
        CreateMap<ProductImage,ProductImageUpdateDto>().ReverseMap();
        CreateMap<ProductImage,ProductImageGetByIdDto>().ReverseMap();
    }
}