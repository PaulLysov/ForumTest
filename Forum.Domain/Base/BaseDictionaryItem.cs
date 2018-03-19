using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Forum.Domain.Base
{ 
	public class BaseDictionaryItem
	{
		public int Id { get; set; }

		[StringLength(50)]
		[DisplayName("Название")]
		public string Name { get; set; }
	}
}