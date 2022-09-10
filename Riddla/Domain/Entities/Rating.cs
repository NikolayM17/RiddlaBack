namespace Domain.Entities
{
	public class Rating : BaseEntity
	{
		/*public int Id { get; set; }*/
		public int? Value { get; set; }

		public int? UserId { get; set; }
		public User User { get; set; }

		public int? TitleId { get; set; }
		public Title Title { get; set; }

		public override void UpdateData(object entity)
		{
			if (entity is Rating rating)
			{
				Value = rating.Value;
				/*UserId = rating.UserId;
				User = rating.User;
				TitleId = rating.TitleId;
				Title = rating.Title;*/
			}
			else throw new Exception($"Error convert!\n{this.GetType()}");
		}
	}
}
