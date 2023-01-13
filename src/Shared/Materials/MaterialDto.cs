using System;
using FluentValidation;

namespace Shared.Materials
{
	public static class MaterialDto
	{
		public class Index
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public bool InStock { get; set; }
        }

        public class Create
        {
            public string Name { get; set; }
            public string Description { get; set; }

            public class Validator : AbstractValidator<Create>
            {
                public Validator()
                {
                    RuleFor(x => x.Name).NotEmpty().MaximumLength(250);
                    RuleFor(x => x.Description).MaximumLength(1000);
                }
            }
        }
    }   
}

