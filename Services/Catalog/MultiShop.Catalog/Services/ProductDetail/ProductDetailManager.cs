using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetail;

public class ProductDetailManager : IProductDetailService
{
    private readonly IMongoCollection<Entities.ProductDetail> _productDetailCollection;
    private readonly IMapper _mapper;

    public ProductDetailManager(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productDetailCollection = database.GetCollection<Entities.ProductDetail>(databaseSettings.ProductDetailCollectionName);
    }
    
    public async Task<List<ProductDetailResultDto>> GetAllAsync()
    {
        var categories = await _productDetailCollection.Find(productDetail => true).ToListAsync();
        return _mapper.Map<List<ProductDetailResultDto>>(categories);
    }

    public async Task<ProductDetailGetByIdDto> GetByIdAsync(string productDetailId)
    {
        var productDetail = await _productDetailCollection.Find(productDetail => productDetail.ProductDetailId == productDetailId).FirstOrDefaultAsync();
        return _mapper.Map<ProductDetailGetByIdDto>(productDetail);
    }

    public async Task CreateAsync(ProductDetailCreateDto productDetailCreateDto)
    {
        var productDetail = _mapper.Map<Entities.ProductDetail>(productDetailCreateDto);
        await _productDetailCollection.InsertOneAsync(productDetail);
    }

    public async Task UpdateAsync(ProductDetailUpdateDto productDetailUpdateDto)
    {
        var productDetail = _mapper.Map<Entities.ProductDetail>(productDetailUpdateDto);
        await _productDetailCollection.ReplaceOneAsync(c => c.ProductDetailId == productDetail.ProductDetailId, productDetail);
    }

    public async Task DeleteAsync(string productDetailId)
    {
        await _productDetailCollection.DeleteOneAsync(productDetail => productDetail.ProductDetailId == productDetailId); 
    }
}