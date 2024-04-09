using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.Category;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Category;

public class CategoryManager : ICategoryService
{
    private readonly IMongoCollection<Entities.Category> _categoryCollection;
    private readonly IMapper _mapper;

    public CategoryManager(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Entities.Category>(databaseSettings.CategoryCollectionName);
    }
    
    public async Task<List<CategoryResultDto>> GetAllAsync()
    {
        var categories = await _categoryCollection.Find(category => true).ToListAsync();
        return _mapper.Map<List<CategoryResultDto>>(categories);
    }

    public async Task<CategoryGetByIdDto> GetByIdAsync(string categoryId)
    {
        var category = await _categoryCollection.Find(category => category.CategoryId == categoryId).FirstOrDefaultAsync();
        return _mapper.Map<CategoryGetByIdDto>(category);
    }

    public async Task CreateAsync(CategoryCreateDto categoryCreateDto)
    {
        var category = _mapper.Map<Entities.Category>(categoryCreateDto);
        await _categoryCollection.InsertOneAsync(category);
    }

    public async Task UpdateAsync(CategoryUpdateDto categoryUpdateDto)
    {
        var category = _mapper.Map<Entities.Category>(categoryUpdateDto);
        await _categoryCollection.ReplaceOneAsync(c => c.CategoryId == category.CategoryId, category);
    }

    public async Task DeleteAsync(string categoryId)
    {
        await _categoryCollection.DeleteOneAsync(category => category.CategoryId == categoryId); 
    }
}