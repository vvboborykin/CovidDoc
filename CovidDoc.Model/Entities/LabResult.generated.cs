//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v3.0.7.2
//     Source:                    https://github.com/msawczyn/EFDesigner
//     Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner
//     Documentation:             https://msawczyn.github.io/EFDesigner/
//     License (MIT):             https://github.com/msawczyn/EFDesigner/blob/master/LICENSE
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CovidDoc.Model
{
   /// <summary>
   /// Результат исследования
   /// </summary>
   [System.ComponentModel.Description("Результат исследования")]
   public partial class LabResult
   {
      partial void Init();

      /// <summary>
      /// Default constructor
      /// </summary>
      public LabResult()
      {
         Init();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="resultdate"></param>
      /// <param name="resultcode"></param>
      /// <param name="researchtype"></param>
      /// <param name="researchresult"></param>
      /// <param name="_referralitem0"></param>
      public LabResult(DateTime resultdate, byte resultcode, global::CovidDoc.Model.ResearchType researchtype, global::CovidDoc.Model.ResearchResult researchresult, global::CovidDoc.Model.ReferralItem _referralitem0)
      {
         this.ResultDate = resultdate;

         this.ResultCode = resultcode;

         if (researchtype == null) throw new ArgumentNullException(nameof(researchtype));
         this.ResearchType = researchtype;
         researchtype.LabResults.Add(this);

         if (researchresult == null) throw new ArgumentNullException(nameof(researchresult));
         this.ResearchResult = researchresult;
         researchresult.LabResults.Add(this);

         if (_referralitem0 == null) throw new ArgumentNullException(nameof(_referralitem0));
         _referralitem0.LabResult = this;

         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="resultdate"></param>
      /// <param name="resultcode"></param>
      /// <param name="researchtype"></param>
      /// <param name="researchresult"></param>
      /// <param name="_referralitem0"></param>
      public static LabResult Create(DateTime resultdate, byte resultcode, global::CovidDoc.Model.ResearchType researchtype, global::CovidDoc.Model.ResearchResult researchresult, global::CovidDoc.Model.ReferralItem _referralitem0)
      {
         return new LabResult(resultdate, resultcode, researchtype, researchresult, _referralitem0);
      }

      /*************************************************************************
       * Properties
       *************************************************************************/

      /// <summary>
      /// Identity, Indexed, Required
      /// Unique identifier
      /// </summary>
      [Key]
      [Required]
      [System.ComponentModel.Description("Unique identifier")]
      public long Id { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      [Required]
      [Display(Name="Дата результата")]
      public DateTime ResultDate { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      [Required]
      [Display(Name="Код результата")]
      public byte ResultCode { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

      /// <summary>
      /// Required
      /// </summary>
      [Display(Name="Тип исследования")]
      public virtual global::CovidDoc.Model.ResearchType ResearchType { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      [Display(Name="Тип результата")]
      public virtual global::CovidDoc.Model.ResearchResult ResearchResult { get; set; }

   }
}

