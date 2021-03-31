using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarathonSkills.DesktopApp.Extensions
{
    public static class SyncContextExtensions
    {
        public static void Invoke(this SynchronizationContext syncContext, Action action) => 
            syncContext.Send(_ => action(), null);
    }
}
