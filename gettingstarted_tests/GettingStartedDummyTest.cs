using System;
using gettingstarted.Services;
using Xunit;

namespace gettingstarted_tests
{
    public class GettingStartedDummyTest
    {
        [Fact]
		public void TestFetchAll()
        {
			IGettingStartedRepo repo = new GettingStartedRepo();

			string[] result = repo.FetchAll();

			Assert.Equal(3, result.Length);
        }
    }
}
