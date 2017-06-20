using System;
using System.Runtime.InteropServices;
using System.Text;
using GacRecce.Api.Enums;

namespace GacRecce.Api
{
    [ComVisible(false)]
    public class AssemblyCacheEnum
    {
        // null means enumerate all the assemblies
        public AssemblyCacheEnum(String assemblyName)
        {
            IAssemblyName fusionName = null;
            int hr = 0;

            if (assemblyName != null)
            {
                hr = Utils.CreateAssemblyNameObject(
                    out fusionName,
                    assemblyName,
                    CreateAssemblyNameObjectFlags.CANOF_PARSE_DISPLAY_NAME,
                    IntPtr.Zero);
            }

            if (hr >= 0)
            {
                hr = Utils.CreateAssemblyEnum(
                    out _assemblyEnum,
                    IntPtr.Zero,
                    fusionName,
                    AssemblyCacheFlags.GAC,
                    IntPtr.Zero);
            }

            if (hr < 0)
            {
                Marshal.ThrowExceptionForHR(hr);
            }
        }

        public String GetNextAssembly()
        {
            int hr;
            IAssemblyName fusionName;

            if (_done)
            {
                return null;
            }

            // Now get next IAssemblyName from _assemblyEnum
            hr = _assemblyEnum.GetNextAssembly((IntPtr)0, out fusionName, 0);

            if (hr < 0)
            {
                Marshal.ThrowExceptionForHR(hr);
            }

            if (fusionName != null)
            {
                return GetFullName(fusionName);
            }
            else
            {
                _done = true;
                return null;
            }
        }

        private String GetFullName(IAssemblyName fusionAsmName)
        {
            StringBuilder sDisplayName = new StringBuilder(1024);
            int iLen = 1024;

            int hr = fusionAsmName.GetDisplayName(sDisplayName, ref iLen, (int)AssemblyNameDisplayFlags.ALL);
            if (hr < 0)
            {
                Marshal.ThrowExceptionForHR(hr);
            }

            return sDisplayName.ToString();
        }

        private readonly IAssemblyEnum _assemblyEnum;
        private bool _done;
    }
}