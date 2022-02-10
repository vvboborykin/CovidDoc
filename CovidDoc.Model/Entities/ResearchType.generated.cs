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
   /// Тип исследования
   /// </summary>
   [System.ComponentModel.Description("Тип исследования")]
   public partial class ResearchType
   {
      partial void Init();

      /// <summary>
      /// Default constructor
      /// </summary>
      public ResearchType()
      {
         LabResults = new System.Collections.Generic.HashSet<global::CovidDoc.Model.LabResult>();

         Init();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="code"></param>
      /// <param name="name"></param>
      public ResearchType(string code, string name)
      {
         if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));
         this.Code = code;

         if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
         this.Name = name;

         LabResults = new System.Collections.Generic.HashSet<global::CovidDoc.Model.LabResult>();
         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="code"></param>
      /// <param name="name"></param>
      public static ResearchType Create(string code, string name)
      {
         return new ResearchType(code, name);
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
      /// Indexed, Required, Max length = 50
      /// </summary>
      [Required]
      [MaxLength(50)]
      [StringLength(50)]
      [Display(Name="Код")]
      public string Code { get; set; }

      /// <summary>
      /// Indexed, Required, Max length = 255
      /// </summary>
      [Required]
      [MaxLength(255)]
      [StringLength(255)]
      [Display(Name="Наименование")]
      public string Name { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

      [Display(Name="Результаты")]
      public virtual ICollection<global::CovidDoc.Model.LabResult> LabResults { get; private set; }

   }
}

