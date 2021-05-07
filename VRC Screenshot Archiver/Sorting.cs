using System;

namespace VRC_Screenshot_Archiver
{
    /// <summary>
    /// Enum for screenshot sorting settings
    /// </summary>
    [Flags]
    public enum Sorting
    {
        ByYear = 1 << 0,
        ByMonth = 1 << 1,
        ByDay = 1 << 2
    }
}
