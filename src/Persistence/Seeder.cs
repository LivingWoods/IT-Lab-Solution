using System;
using System.Linq;
using Bogus;
using Domain.Materials;

namespace Persistence
{
	public static class Seeder
	{
		public static void Seed(ApplicationDbContext dbContext)
        {
			if (dbContext.Materials.Any())
				return;

			var faker = new Faker<Material>()
				.CustomInstantiator(f => new Material(f.Commerce.ProductName(), f.Commerce.ProductDescription()));

			dbContext.Materials.AddRange(faker.Generate(10));
			dbContext.SaveChanges();
		}
	}
}

