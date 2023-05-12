using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityFA.Controls
{
    public static class MauiAppBuilderExtensions
    {
        /// <summary>
        /// Setup to use duotone icons
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="fontFileName">Should be fa-duotone-900.ttf or fa-duotone-900.otf</param>
        /// <returns></returns>
        public static MauiAppBuilder UseDuotoneIcons(this MauiAppBuilder builder, string fontFileName)
        {
            builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont(fontFileName, "FontAwesomeDuotone");
            });

            return builder;
        }
    }
}
