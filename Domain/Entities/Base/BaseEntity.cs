using System;

namespace Domain.Entities
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
