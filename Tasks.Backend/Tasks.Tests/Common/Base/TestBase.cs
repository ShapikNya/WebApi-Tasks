using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Tests.Common.Base
{
    public abstract class TestBase
    {
        protected CancellationToken CancellationToken => CancellationToken.None;
    }
}
