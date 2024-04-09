using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Product;

public class ProductManager:IProductService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Entities.Product> _productCollection;

    public ProductManager(IMapper mapper,IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Entities.Product>(databaseSettings.ProductCollectionName);
    }
    public async Task<List<ProductResultDto>> GetAllAsync()
    {
        var products = await _productCollection.Find(product => true).ToListAsync();
        return _mapper.Map<List<ProductResultDto>>(products);
    }

    public async Task<ProductGetByIdDto> GetByIdAsync(string productId)
    {
        var product = await _productCollection.Find(p => p.ProductId == productId).FirstOrDefaultAsync();
        return _mapper.Map<ProductGetByIdDto>(product);
    }

    public async Task CreateAsync(ProductCreateDto productCreateDto)
    {
        var product = _mapper.Map<Entities.Product>(productCreateDto);
        await _productCollection.InsertOneAsync(product);
    }

    public async Task UpdateAsync(ProductUpdateDto productUpdateDto)
    {
        var product = _mapper.Map<Entities.Product>(productUpdateDto);
        await _productCollection.ReplaceOneAsync(p => p.ProductId == product.ProductId,product);
    }

    public async Task DeleteAsync(string productId)
    {
        await _productCollection.DeleteOneAsync(product => product.ProductId == productId);
    }
}