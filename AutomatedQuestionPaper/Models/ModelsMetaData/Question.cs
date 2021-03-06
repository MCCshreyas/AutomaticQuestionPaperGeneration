using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AutomatedQuestionPaper.Models
{

    [MetadataType(typeof(QuestionMetaData))]
    public partial class Question
    {

    }


    public class QuestionMetaData
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuestionMetaData()
        {
            Answers = new HashSet<AnswerMetaData>();
        }


        [Key] public int Id { get; set; }

        [DisplayName("Chapter Id")] [Required] public int? ChapterId { get; set; }
        
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnswerMetaData> Answers { get; set; }
    }
}