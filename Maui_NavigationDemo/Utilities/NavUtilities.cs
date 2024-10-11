using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_NavigationDemo.Utilities
{
    public static class NavUtilities
    {
        public static void Examine(INavigation navigation)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var page in navigation.NavigationStack)
            {
                builder.AppendLine(page.GetType().Name);
            }
            builder.AppendLine("----------");
            Debug.WriteLine(builder.ToString());

        }
    }
}
