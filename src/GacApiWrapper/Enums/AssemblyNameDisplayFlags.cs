using System;

namespace GacRecce.Api.Enums
{
    [Flags]
    internal enum AssemblyNameDisplayFlags
    {
        VERSION = 0x01,
        CULTURE = 0x02,
        PUBLIC_KEY_TOKEN = 0x04,
        PROCESSORARCHITECTURE = 0x20,
        RETARGETABLE = 0x80,
        // This enum will change in the future to include
        // more attributes.
        ALL = VERSION
              | CULTURE
              | PUBLIC_KEY_TOKEN
              | PROCESSORARCHITECTURE
              | RETARGETABLE
    }
}