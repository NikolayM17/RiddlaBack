using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rofel.Domain.Entities
{
	public class BaseEntity
	{
		public int Id { get; set; }

		public virtual void UpdateData(object entity)
		{
			if (entity is BaseEntity)
			{
				Id = ((BaseEntity)entity).Id;
			}
			else throw new Exception($"Error convert!\n{this.GetType()}");
		}
	}
}
