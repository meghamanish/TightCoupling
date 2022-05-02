﻿using System;
using System.Collections.Generic;
using System.Linq;
using PeopleViewer.Common;

namespace PersonDataReader.Decorators
{
	public class CachingReader : IPersonReader
	{
		private IPersonReader _wrappedReader;
		private IEnumerable<Person> _cachedItems;
		private readonly TimeSpan _cacheDuration = new(0, 0, 30);
		private DateTime _dataDateTime;

		public CachingReader(IPersonReader wrappedReader)
		{
			_wrappedReader = wrappedReader;
		}
		public IEnumerable<Person> GetPeople()
		{
			ValidateCache();
			return _cachedItems;
		}

		public Person GetPerson(int id)
		{
			ValidateCache();
			return _cachedItems.FirstOrDefault(x => x.Id == id);
		}

		public bool IsCacheValid
		{
			get
			{
				if (_cachedItems == null)
					return false;

				var cacheAge = DateTime.Now - _dataDateTime;
				return cacheAge < _cacheDuration;
			}
		}

		private void ValidateCache()
		{
			if (IsCacheValid)
				return;

			try
			{
				_cachedItems = _wrappedReader.GetPeople();
				_dataDateTime = DateTime.Now;
			}
			catch
			{
				_cachedItems = new List<Person>()
				{
					new Person()
					{
						GivenName = "No Data Available",
						FamilyName = string.Empty,
						Rating = 0,
						StartDate = DateTime.Today,
					}
				};
				InValidateCache();
			}
		}

		private void InValidateCache()
		{
			_dataDateTime = DateTime.MinValue;
		}
	}
}
