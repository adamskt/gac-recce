using System;
using System.Runtime.InteropServices;
using GacRecce.Api.Enums;

namespace GacRecce.Api
{
    internal class Utils
    {
        [DllImport("fusion.dll")]
        internal static extern int CreateAssemblyEnum(
            out IAssemblyEnum ppEnum,
            IntPtr pUnkReserved,
            IAssemblyName pName,
            AssemblyCacheFlags flags,
            IntPtr pvReserved);

        [DllImport("fusion.dll")]
        internal static extern int CreateAssemblyNameObject(
            out IAssemblyName ppAssemblyNameObj,
            [MarshalAs(UnmanagedType.LPWStr)]
            String szAssemblyName,
            CreateAssemblyNameObjectFlags flags,
            IntPtr pvReserved);

        [DllImport("fusion.dll")]
        internal static extern int CreateAssemblyCache(
            out IAssemblyCache ppAsmCache,
            int reserved);

        [DllImport("fusion.dll")]
        internal static extern int CreateInstallReferenceEnum(
            out IInstallReferenceEnum ppRefEnum,
            IAssemblyName pName,
            int dwFlags,
            IntPtr pvReserved);
    }
}