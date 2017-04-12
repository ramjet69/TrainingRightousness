using Nop.Web.Framework.Themes;

namespace GPGVM.Nop.Access.IdentityServer.Plugin.Infrastructure
{
    public class EditIdentityEngine : ThemeableRazorViewEngine
    {

        public EditIdentityEngine()
        {

            ViewLocationFormats = new []
            {
                "~/Plugins/GPGVM.Nop.Access.IdentityServer/Plugin/Views/{0}.cshtml",
                "~/Plugins/GPGVM.Nop.Access.IdentityServer/Plugin/Views/Shared/{0}.cshtml",
                "~/Plugins/GPGVM.Nop.Access.IdentityServer/Plugin/Views/Shared/EditorTemplatres/{0}.cshtml",
                "~/Plugins/GPGVM.Nop.Access.IdentityServer/Plugin/Views/ClientConfiguration/{0}.cshtml"
            };


            PartialViewLocationFormats = new []
            {
                "~/Plugins/GPGVM.Nop.Access.IdentityServer/Plugin/Views/{0}.cshtml",
                "~/Plugins/GPGVM.Nop.Access.IdentityServer/Plugin/Views/Shared/{0}.cshtml",
                "~/Plugins/GPGVM.Nop.Access.IdentityServer/Plugin/Views/Shared/EditorTemplates{0}.cshtml",
                "~/Plugins/GPGVM.Nop.Access.IdentityServer/Plugin/Views/ClientConfiguration/{0}.cshtml"
            };



        }

    }
}