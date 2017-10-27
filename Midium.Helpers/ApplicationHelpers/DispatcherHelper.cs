using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Midium.Helpers.ApplicationHelpers
{
    public static class DispatcherHelper
    {
        /// <summary>
        /// Simulate Application.DoEvents function of <see cref=" System.Windows.Forms.Application"/> class.
        /// </summary>
        [SecurityPermission ( SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode )]
        public static void DoEvents ( )
        {
            DispatcherFrame frame = new DispatcherFrame ( );
            Dispatcher.CurrentDispatcher.BeginInvoke ( DispatcherPriority.Background,
                new DispatcherOperationCallback ( ExitFrames ), frame );

            try
            {
                Dispatcher.PushFrame ( frame );
            }
            catch ( InvalidOperationException e)
            {
                Debug.WriteLine(e.InnerException);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        private static object ExitFrames ( object frame )
        {
            ( ( DispatcherFrame ) frame ).Continue = false;

            return null;
        }
    }
}
