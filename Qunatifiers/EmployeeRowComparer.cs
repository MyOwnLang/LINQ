using System.Collections.Generic;
using System.Data;

namespace Qunatifiers
{
	public class EmployeeRowComparer : IEqualityComparer<DataRow>
	{
		public bool Equals(DataRow x, DataRow y)
		{
			return x.Field<int>("EmployeeID") == y.Field<int>("EmployeeID") && x.Field<string>("FirstName") == y.Field<string>("FirstName");
		}

		public int GetHashCode(DataRow obj)
		{
			return obj.Field<int>("EmployeeID").GetHashCode() ^ obj.Field<int>("FirstName").GetHashCode();
		}
	}
}