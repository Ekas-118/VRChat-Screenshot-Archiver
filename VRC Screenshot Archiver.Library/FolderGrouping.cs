using System;

namespace VRC_Screenshot_Archiver.Library
{
    [Flags]
    public enum FolderGrouping
    {
        ByYear = 1 << 0,
        ByMonth = 1 << 1,
        ByDay = 1 << 2
    }
}
