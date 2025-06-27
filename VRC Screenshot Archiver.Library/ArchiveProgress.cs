using System;

namespace VRC_Screenshot_Archiver.Library
{
    public class ArchiveProgress
    {
        public int FilesMoved { get; set; }

        public int FilesFailed { get; set; }

        public int ImagesFound { get; set; }

        public string ErrorMessage { get; set; }

        public string Message => $"{FilesMoved} images moved. {(FilesFailed > 0 ? $"{FilesFailed} failed." : "")}{Environment.NewLine}{ImagesFound} images found.";
    }
}
