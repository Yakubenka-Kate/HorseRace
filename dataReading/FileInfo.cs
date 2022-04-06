
namespace dataReading
{
    internal class FileInfo
    {
        public string HorseNameFile { get; set; }
        public string HorseCoefFile { get; set; }
        public string HorsePositionFile { get; set; }
        public string UserResultFile { get; set; }

        public FileInfo()
        {
            HorseNameFile = string.Empty;
            HorseCoefFile = string.Empty;
            HorsePositionFile = string.Empty;
            UserResultFile = string.Empty;
        }

        public override string ToString()
        {
            return $"{HorseNameFile} {HorseCoefFile} {HorsePositionFile} {UserResultFile}";
        }
    }
}
