using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeopleViewer.Common;

namespace PersonDataReader.SQL
{
	public class PersonContext : DbContext
	{
		public PersonContext(DbContextOptions<PersonContext> options)
			: base(options)
		{ }

		public DbSet<Person> People { get; set; }
	}
}
