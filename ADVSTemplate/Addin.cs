using Autodesk.AdvanceSteel.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: ExtensionApplication(typeof(ADVSTemplate.Addin))]
namespace ADVSTemplate
{
    public sealed class Addin : IExtensionApplication
    {
        public void Initialize ()
        {
        }

        public void Terminate ()
        {
        }
    }
}
