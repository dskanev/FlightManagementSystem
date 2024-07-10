using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Domain.Specifications
{
    public class CompositeSpecification<T> : ISpecification<T>
    {
        private readonly List<ISpecification<T>> _specifications = new List<ISpecification<T>>();

        public string ErrorMessage => string.Join(", ", _specifications.Select(s => s.ErrorMessage));

        public void Add(ISpecification<T> specification)
        {
            _specifications.Add(specification);
        }

        public bool IsSatisfiedBy(T entity)
        {
            return _specifications.All(s => s.IsSatisfiedBy(entity));
        }
    }
}
