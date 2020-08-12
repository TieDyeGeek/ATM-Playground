using System;
using CSESoftware.Core.Entity;

namespace ATM.Persistence.Models
{
	public class Account : BaseEntity<Guid>
	{
		public string Name { get; set; }

		public int HolderId { get; set; }
		public virtual Holder Holder { get; set; }
	}
}
