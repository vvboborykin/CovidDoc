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
   /// Переход между состояниями
   /// </summary>
   [System.ComponentModel.Description("Переход между состояниями")]
   public partial class StatusTransition
   {
      partial void Init();

      /// <summary>
      /// Default constructor
      /// </summary>
      public StatusTransition()
      {
         GrantedForRoles = new System.Collections.Generic.HashSet<global::CovidDoc.Model.AppRole>();

         Init();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="name"></param>
      /// <param name="code"></param>
      /// <param name="targetstatus"></param>
      public StatusTransition(string name, string code, global::CovidDoc.Model.DocumentStatus targetstatus)
      {
         if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
         this.Name = name;

         if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(nameof(code));
         this.Code = code;

         if (targetstatus == null) throw new ArgumentNullException(nameof(targetstatus));
         this.TargetStatus = targetstatus;
         targetstatus.ToTransitions.Add(this);

         GrantedForRoles = new System.Collections.Generic.HashSet<global::CovidDoc.Model.AppRole>();
         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="name"></param>
      /// <param name="code"></param>
      /// <param name="targetstatus"></param>
      public static StatusTransition Create(string name, string code, global::CovidDoc.Model.DocumentStatus targetstatus)
      {
         return new StatusTransition(name, code, targetstatus);
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
      /// Indexed, Required, Max length = 255
      /// </summary>
      [Required]
      [MaxLength(255)]
      [StringLength(255)]
      [Display(Name="Наименование")]
      public string Name { get; set; }

      /// <summary>
      /// Required, Max length = 50
      /// </summary>
      [Required]
      [MaxLength(50)]
      [StringLength(50)]
      [Display(Name="Код")]
      public string Code { get; set; }

      /// <summary>
      /// Max length = 4096
      /// </summary>
      [MaxLength(4096)]
      [StringLength(4096)]
      [Display(Name="Предикат разрешения перехода")]
      public string EnablePredicate { get; set; }

      /// <summary>
      /// Max length = 4096
      /// </summary>
      [MaxLength(4096)]
      [StringLength(4096)]
      [Display(Name="Предикат автоперехода")]
      public string AutoRunPredicate { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

      public virtual ICollection<global::CovidDoc.Model.AppRole> GrantedForRoles { get; private set; }

      [Display(Name="Начальный статус")]
      public virtual global::CovidDoc.Model.DocumentStatus InitialStatus { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      [Display(Name="Конечный статус")]
      public virtual global::CovidDoc.Model.DocumentStatus TargetStatus { get; set; }

   }
}

