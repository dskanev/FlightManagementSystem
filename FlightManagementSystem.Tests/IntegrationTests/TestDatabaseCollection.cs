using FlightManagementSystem.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem.Tests.IntegrationTests
{
    [CollectionDefinition("TestDatabase")]
    public class TestDatabaseCollection : ICollectionFixture<TestDatabaseFixture>
    {
    }
}
