using FireworksFramework.Types;
using IsWiXAutomationInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppXDesigner.Models
{
    public class AppXModel : ObservableObject
    {
        const string APPX = "1. AppX (Required)";
        const string APPXOPT = "2. AppX (Optional)";

        [CategoryAttribute(APPX)]
        [Description(@"Identity of the AppX package.")]
        [ReadOnly(true)]
        public string Id { get; set; }

        [CategoryAttribute(APPX)]
        [Description(@"Publisher of the AppX package. Must be in the form of a certificate name, e.g. CN=FireGiant.")]
        public string Publisher { get; set; }

        [CategoryAttribute(APPX)]
        [Description(@"Target device family for the AppX package.")]
        public TargetType Target { get; set; }

        [CategoryAttribute(APPXOPT)]
        [Description(@"The AppX package name (aka: Appx/@Id) of the parent package. Use this only when this package is to be referenced by a sparse bundle.")]
        public string MainPackage { get; set; }

        [CategoryAttribute(APPXOPT)]
        [Description(@"Overrides the description provided by the 'ARPCOMMENTS' Property. It is recommended to use the 'ARPCOMMENTS' Property instead of using this attribute.")]
        public string Description { get; set; }

        [CategoryAttribute(APPXOPT)]
        [Description(@"Overrides the display name provided by the Product/@Name. It is not recommended to use this attribute.")]
        public string DisplayName { get; set; }

        [CategoryAttribute(APPXOPT)]
        [Description(@"Overrides the manufacturer provided by the Product/@Manufacturer. It is not recommended to use this attribute.")]
        public string Manufacturer { get; set; }

        [CategoryAttribute(APPXOPT)]
        [Description(@"Overrides the package icon provided by the 'ARPPRODUCTICON' with a path to a image file. It is recommended to use the 'ARPPRODUCTICON' Property instead of using this attribute.")]
        public string LogoFile { get; set; }

        [CategoryAttribute(APPXOPT)]
        [Description(@"Overrides the version provided by the Product/@Version. It is not recommended to use this attribute.")]
        public string Version { get; set; }

        public override string ToString()
        {
            return Id;
        }
    }
}
