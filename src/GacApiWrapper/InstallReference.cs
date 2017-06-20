using System;
using System.Runtime.InteropServices;

namespace GacRecce.Api
{
    [StructLayout(LayoutKind.Sequential)]
    public class InstallReference
    {
        public InstallReference(Guid guid, String id, String data)
        {
            cbSize = 2 * IntPtr.Size + 16 + (id.Length + data.Length) * 2;
            flags = 0;
            // quiet compiler warning 
            if (flags == 0) { }
            guidScheme = guid;
            identifier = id;
            description = data;
        }

        public Guid GuidScheme => guidScheme;

        public String Identifier => identifier;

        public String Description => description;

        private int cbSize;
        private readonly int flags;
        private readonly Guid guidScheme;
        [MarshalAs(UnmanagedType.LPWStr)] readonly String identifier;
        [MarshalAs(UnmanagedType.LPWStr)] readonly String description;
    }
}