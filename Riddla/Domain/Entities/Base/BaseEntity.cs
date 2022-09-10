using DAL;
using System.Reflection;

namespace Domain.Entities
{
	public class BaseEntity
	{
		/*[DatabaseGenerated(DatabaseGeneratedOption.Identity)]*/
		public int Id { get; set; }

		public List<T> GetList<T>(/*string arrayType, string arrayItemType*/)
		{
			var properties = GetType().GetProperties();

			var result = properties.First(p => p.PropertyType.Name.Contains("List"/*arrayType*/) && p.PropertyType.FullName.Contains(typeof(T).Name /*arrayItemType*/));

			return result.GetValue(this) as List<T>;
		}

		public List<PropertyInfo>? GetAllLists()
		{
			var properties = GetType().GetProperties();

			var result = properties.Where(p => p.PropertyType.Name.Contains("List"));

			return result.ToList();
		}

		public virtual void FillLists(AppDbContext db)
		{

		}

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
