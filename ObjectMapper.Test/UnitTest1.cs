using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ObjectMapper.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestToStringGenericMethodMap()
		{
			var mapper = new ObjectMapper();
			var testUserSrc = new TestUserSrc
			{
				Id = 10,
				Birthdate = new DateTime(2000, 1, 1),
				Name = "TestUser"
			};

			var result = mapper.Map<TestUserDest>(testUserSrc);

			Assert.AreEqual(testUserSrc.Id.ToString(), result.Id);
			Assert.AreEqual(testUserSrc.Name, result.Name);
			Assert.AreEqual(testUserSrc.Birthdate.ToString(), result.Birthdate);
		}

		[TestMethod]
		public void TestToStringMap()
		{
			var mapper = new ObjectMapper();
			var testUserSrc = new TestUserSrc
			{
				Id = 10,
				Birthdate = new DateTime(2000, 1, 1),
				Name = "TestUser"
			};

			var result = mapper.Map(testUserSrc, typeof(TestUserDest));

			Assert.IsInstanceOfType(result, typeof(TestUserDest));
			var instance = (TestUserDest)result;

			Assert.AreEqual(testUserSrc.Id.ToString(), instance.Id);
			Assert.AreEqual(testUserSrc.Name, instance.Name);
			Assert.AreEqual(testUserSrc.Birthdate.ToString(), instance.Birthdate);
		}


		[TestMethod]
		public void TestCollectionGenericMethodMap()
		{
			var mapper = new ObjectMapper();
			var users = new List<TestUserSrc>
			{
				new TestUserSrc{ Id = 1, Birthdate = new DateTime(2001, 1, 1), Name = "Test1" },
				new TestUserSrc{ Id = 2, Birthdate = new DateTime(2002, 2, 2), Name = "Test2" },
				new TestUserSrc{ Id = 3, Birthdate = new DateTime(2003, 3, 3), Name = "Test3" },
			};

			var strings = new List<string>
			{
				"Test_string_1",
				"Test_string_2",
				"Test_string_3"
			};

			var testCollectionSrc = new TestCollectionSrc
			{
				Users = users,
				Strings = strings
			};

			var result = mapper.Map<TestCollectionDest>(testCollectionSrc);

			Assert.AreEqual(users, result.Users);
			Assert.AreEqual(strings, result.Strings);
		}



		[TestMethod]
		public void TestCollectionMap()
		{
			var mapper = new ObjectMapper();
			var users = new List<TestUserSrc>
			{
				new TestUserSrc{ Id = 1, Birthdate = new DateTime(2001, 1, 1), Name = "Test1" },
				new TestUserSrc{ Id = 2, Birthdate = new DateTime(2002, 2, 2), Name = "Test2" },
				new TestUserSrc{ Id = 3, Birthdate = new DateTime(2003, 3, 3), Name = "Test3" },
			};

			var strings = new List<string>
			{
				"Test_string_1",
				"Test_string_2",
				"Test_string_3"
			};

			var testCollectionSrc = new TestCollectionSrc
			{
				Users = users,
				Strings = strings
			};

			var result = mapper.Map(testCollectionSrc, typeof(TestCollectionDest));

			Assert.IsInstanceOfType(result, typeof(TestCollectionDest));
			var instance = (TestCollectionDest)result;

			Assert.AreEqual(users, instance.Users);
			Assert.AreEqual(strings, instance.Strings);
		}
	}


	public class TestUserSrc
	{
		private int PrivateProperty { get; set; }

		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Birthdate { get; set; }
	}

	public class TestUserDest
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Birthdate { get; set; }
	}


	public class TestCollectionSrc
	{
		public IEnumerable<TestUserSrc> Users { get; set; }
		public IEnumerable<string> Strings { get; set; }
	}


	public class TestCollectionDest
	{
		public IEnumerable<TestUserSrc> Users { get; set; }
		public IEnumerable<string> Strings { get; set; }
	}
}
