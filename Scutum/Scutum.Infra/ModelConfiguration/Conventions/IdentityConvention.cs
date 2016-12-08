using System;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Scutum.Infra.ModelConfiguration.Conventions
{
    public class IdentityConvention : Convention
    {
        public IdentityConvention()
        {
            this.Properties<Int32>()
                .Where(p => p.Name == "Id")
                .Configure(x => x.IsKey());
        }
    }
}