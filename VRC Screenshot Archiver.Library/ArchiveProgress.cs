using System;

namespace VRC_Screenshot_Archiver.Library
{
    public class ArchiveProgress
    {
        public int FilesMoved;

        public int FilesFailed;

        public int ImagesFound;

        public string ErrorMessage { get; set; }

        public string Message => 
            $"{(FilesMoved > 0 ? $"{FilesMoved} images moved. " : string.Empty)}" +
            $"{(FilesFailed > 0 ? $"{FilesFailed} failed." : string.Empty)}" +
            $"{(FilesMoved > 0 || FilesFailed > 0 ? Environment.NewLine : string.Empty)}" +
            $"{ImagesFound} images found.";
    }
}
