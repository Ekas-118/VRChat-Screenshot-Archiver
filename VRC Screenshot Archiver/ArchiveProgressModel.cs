using System;

namespace VRC_Screenshot_Archiver
{
    /// <summary>
    /// Model for storing archiving progress information
    /// </summary>
    public class ArchiveProgressModel
    {
        /// <summary>
        /// Count of files successfully moved
        /// </summary>
        public int FilesMoved { get; set; } = 0;

        /// <summary>
        /// Count of files that couldn't be moved
        /// </summary>
        public int FilesFailed { get; set; } = 0;

        /// <summary>
        /// Count of total images found
        /// </summary>
        public int ImagesFound { get; set; } = 0;

        /// <summary>
        /// Message of an error, if there is one
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Progress status information
        /// </summary>
        public string Message
        {
            get
            {
                return $"{FilesMoved} images moved. {(FilesFailed > 0 ? $"{FilesFailed} failed." : "")}{Environment.NewLine}{ImagesFound} images found.";
            }
        }
    }
}
