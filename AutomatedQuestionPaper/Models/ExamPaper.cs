//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using AutomatedQuestionPaper.Models.ModelsMetaData;

namespace AutomatedQuestionPaper.Models
{
    using System;
    using System.Collections.Generic;

    [MetadataType(typeof(ExamPaperMetaData))]
    public partial class ExamPaper
    {
        public int Id { get; set; }
        public Nullable<int> StaffId { get; set; }
        public string PaperName { get; set; }
        public byte[] PaperValue { get; set; }
    }
}
