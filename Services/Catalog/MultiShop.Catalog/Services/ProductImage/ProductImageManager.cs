using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImage;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImage;

public class ProductImageManager : IProductImageService
{
    private readonly IMongoCollection<Entities.ProductImage> _productImageCollection;
    private readonly IMapper _mapper;

    public ProductImageManager(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productImageCollection = database.GetCollection<Entities.ProductImage>(databaseSettings.ProductImageCollectionName);
    }
    
    public async Task<List<ProductImageResultDto>> GetAllAsync()
    {
        var categories = await _productImageCollection.Find(productImage => true).ToListAsync();
        return _mapper.Map<List<ProductImageResultDto>>(categories);
    }

    public async Task<ProductImageGetByIdDto> GetByIdAsync(string productImageId)
    {
        var productImage = await _productImageCollection.Find(productImage => productImage.ProductImageId == productImageId).FirstOrDefaultAsync();
        return _mapper.Map<ProductImageGetByIdDto>(productImage);
    }

    public async Task CreateAsync(ProductImageCreateDto productImageCreateDto)
    {
        var productImage = _mapper.Map<Entities.ProductImage>(productImageCreateDto);
        await _productImageCollection.InsertOneAsync(productImage);
    }

    public async Task UpdateAsync(ProductImageUpdateDto productImageUpdateDto)
    {
        var productImage = _mapper.Map<Entities.ProductImage>(productImageUpdateDto);
        await _productImageCollection.ReplaceOneAsync(c => c.ProductImageId == productImage.ProductImageId, productImage);
    }

    public async Task DeleteAsync(string productImageId)
    {
        await _productImageCollection.DeleteOneAsync(productImage => productImage.ProductImageId == productImageId); 
    }
}