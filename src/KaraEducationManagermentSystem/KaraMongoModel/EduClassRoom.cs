using System.Collections.ObjectModel;
namespace KaraMongoModelNS
{
    public class EduClassRoom
    {
        /// <summary>
        /// Class room name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Short name
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Custom fileds
        /// </summary>
        public ObservableCollection<CustomField> CustomFields;

        /// <summary>
        /// Color
        /// </summary>
        public string Color { get; set; }


    }
}