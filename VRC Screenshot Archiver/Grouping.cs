using System;

namespace VRC_Screenshot_Archiver
{
    /// <summary>
    /// Enum for screenshot grouping settings
    /// </summary>
    [Flags]
    public enum Grouping
    {
        ByYear = 1 << 0,
        ByMonth = 1 << 1,
        ByDay = 1 << 2
    }
}
