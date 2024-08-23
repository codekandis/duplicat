using Newtonsoft.Json;
using SharpKandis.ComponentModel;

namespace CodeKandis.DupliCat.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    internal class Md5 :
        NotifyPropertyAbstract,
        Md5Interface
    {
        [JsonProperty(PropertyName = "checksum")]
        private string checksum;

        [JsonProperty(PropertyName = "files")] private FileList files;

        public virtual string Checksum
        {
            get => checksum;
            private set
            {
                PropertyChangingRaise();
                checksum = value;
                PropertyChangedRaise();
            }
        }

        public virtual FileList Files
        {
            get => files;
            private set
            {
                PropertyChangingRaise();
                files = value;
                PropertyChangedRaise();
            }
        }
    }
}