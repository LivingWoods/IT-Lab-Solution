using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared.Materials
{
	public interface IMaterialService
	{
		Task<IEnumerable<MaterialDto.Index>> GetIndexAsync(string searchTerm);
        Task<int> CreateAsync(MaterialDto.Create model);
	}
}

