// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.Data.Entity.FunctionalTests;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.DependencyInjection.Fallback;

namespace Microsoft.Data.Entity.InMemory.FunctionalTests
{
    public class InMemoryNullKeysTest : NullKeysTestBase<InMemoryNullKeysTest.InMemoryNullKeysFixture>
    {
        public InMemoryNullKeysTest(InMemoryNullKeysFixture fixture)
            : base(fixture)
        {
        }

        public class InMemoryNullKeysFixture : NullKeysFixtureBase
        {
            private readonly IServiceProvider _serviceProvider;
            private readonly DbContextOptions _options;

            public InMemoryNullKeysFixture()
            {
                _serviceProvider = new ServiceCollection()
                    .AddEntityFramework()
                    .AddInMemoryStore()
                    .ServiceCollection
                    .AddTestModelSource(OnModelCreating)
                    .BuildServiceProvider();

                _options = new DbContextOptions();
                _options.UseInMemoryStore(persist: true);

                EnsureCreated();
            }

            public override DbContext CreateContext()
            {
                return new DbContext(_serviceProvider, _options);
            }
        }
    }
}
