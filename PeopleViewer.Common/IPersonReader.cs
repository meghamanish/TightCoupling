using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleViewer.Common
{
	public interface IPersonReader
	{
		IEnumerable<Person> GetPeople();

		Person GetPerson(int id);
	}
}
