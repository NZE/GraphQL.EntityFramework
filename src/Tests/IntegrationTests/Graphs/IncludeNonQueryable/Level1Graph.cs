using System.Linq;
using GraphQL.EntityFramework;

public class Level1Graph :
    EfObjectGraphType<IntegrationDbContext, Level1Entity>
{
    public Level1Graph(IEfGraphQLService<IntegrationDbContext> graphQlService) :
        base(graphQlService)
    {
        Field(x => x.Id);
        AddNavigationField(
            name: "level2Entity",
            resolve: context => context.Source.IncludeNonQueryableA);
        AddQueryField(
            name: "level2EntityQuery",
            resolve: context =>
            {
                var dataContext = context.DbContext;
                return dataContext.Level1Entities.AsQueryable()
                    .Where(p => p.Level2EntityId != null && p.Level2EntityId == context.Source.Id)
                    .Select(p => p.IncludeNonQueryableA!);
            });
    }
}