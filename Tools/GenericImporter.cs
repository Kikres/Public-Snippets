using Public_Snippets.Common_Models;

namespace Public_Snippets.Tools;

public class GenericImporter
{
    private List<Import> _data { get; set; }
    private readonly DbDataContext _db;

    public GenericImporter(List<Import> data)
    {
        _data = data;
    }

    public async void Run()
    {
        //var transaction = await _db.Database.BeginTransactionAsync();

        // Example usage
        //var brandDict = await genericImportAsync(
        //    async () =>
        //    {
        //        var existingUnits = await _db.Brands.Select(o => new
        //        {
        //            o.BrandID,
        //            o.Name,
        //            o.CategoryID
        //        }).ToListAsync();

        //        return existingUnits.Select(u => (u.BrandID, u.Name)).ToList();
        //    },
        //    obj => (
        //        new Entities.Brands.Brand.SaveEntityRequest
        //        {
        //            entity = new Entities.Brands.Brand.SaveEntityRequest.Entity
        //            {
        //                name = obj.Entity.Brand,
        //                cssClass = "",
        //                showInPopular = false,
        //            }
        //        },
        //        obj.Entity.Brand
        //    ),
        //    async entity => (
        //        (await _someMethods.SaveEntityAsync(entity, false)).EntityID,
        //        entity.entity.name
        //    )
        //);

        //transaction.Commit();
    }

    private async Task<Dictionary<string, (int id, string internalId)>> genericImportAsync<T>(
        Func<Task<List<(int id, string name)>>> fetchDataFunc,
        Func<Import, (T entity, string name)> entityCreator,
        Func<T, Task<(int id, string name)>> saveEntityAsync
    )
    {
        var entityDict = new Dictionary<string, (int id, string name)>();

        // Fetch existing data
        var existingData = await fetchDataFunc();

        foreach (var (id, name) in existingData)
        {
            entityDict.TryAdd(name, (id, name));
        }

        // Process imported JSON content
        foreach (var obj in _data)
        {
            var (entity, entityName) = entityCreator(obj);

            if (entityName == null || entityDict.ContainsKey(entityName))
            {
                continue;
            }

            var @return = await saveEntityAsync(entity);

            entityDict.TryAdd(entityName, @return);
        }

        return entityDict;
    }
}

public class Import
{
    // Match json structure
}