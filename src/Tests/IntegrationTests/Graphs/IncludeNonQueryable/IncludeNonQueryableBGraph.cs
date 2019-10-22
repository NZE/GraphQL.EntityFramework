using System.Linq;
using GraphQL.EntityFramework;

public class IncludeNonQueryableBGraph :
    EfObjectGraphType<IntegrationDbContext, IncludeNonQueryableB>
{
    public IncludeNonQueryableBGraph(IEfGraphQLService<IntegrationDbContext> graphQlService) :
        base(graphQlService)
    {
        Field(x => x.Id);
        AddQueryField(
            name: "field",
            resolve: context =>
            {
                var dataContext = context.DbContext;
                return dataContext.IncludeNonQueryableBs.AsQueryable()
                    .Where(p =>  p.IncludeNonQueryableAId == context.Source.Id)
                    .Select(p => p.IncludeNonQueryableA);
            });
    }
}