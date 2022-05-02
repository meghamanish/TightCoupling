using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PeopleViewer.Common;

namespace PersonDataReader.SQL
{
	public class SQLReader : IPersonReader
	{
		private DbContextOptions<PersonContext> options;

		public SQLReader()
		{
			var optionsBuilder = new DbContextOptionsBuilder<PersonContext>();
			optionsBuilder.UseSqlite("Data Source=people.db");
			options = optionsBuilder.Options;
		}
		public IEnumerable<Person> GetPeople()
		{
			using (var context = new PersonContext(options))
			{
				return context.People.ToList();
			}
		}

		public Person GetPerson(int id)
		{
			return GetPeople().FirstOrDefault(x => x.Id == id);
		}
	}
}
