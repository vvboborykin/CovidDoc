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
   /// ЭП документа
   /// </summary>
   [System.ComponentModel.Description("ЭП документа")]
   public partial class Signature
   {
      partial void Init();

      /// <summary>
      /// Default constructor
      /// </summary>
      public Signature()
      {
         Init();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="signdatetime"></param>
      /// <param name="signdata"></param>
      /// <param name="signatoryuser"></param>
      /// <param name="document"></param>
      public Signature(DateTime signdatetime, byte signdata, global::CovidDoc.Model.AppUser signatoryuser, global::CovidDoc.Model.Document document)
      {
         this.SignDateTime = signdatetime;

         this.SignData = signdata;

         if (signatoryuser == null) throw new ArgumentNullException(nameof(signatoryuser));
         this.SignatoryUser = signatoryuser;
         signatoryuser.Signatures.Add(this);

         if (document == null) throw new ArgumentNullException(nameof(document));
         this.Document = document;
         document.Signatures.Add(this);

         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="signdatetime"></param>
      /// <param name="signdata"></param>
      /// <param name="signatoryuser"></param>
      /// <param name="document"></param>
      public static Signature Create(DateTime signdatetime, byte signdata, global::CovidDoc.Model.AppUser signatoryuser, global::CovidDoc.Model.Document document)
      {
         return new Signature(signdatetime, signdata, signatoryuser, document);
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
      public DateTime SignDateTime { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      [Required]
      public byte SignData { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

      /// <summary>
      /// Required
      /// </summary>
      [Display(Name="Подписал")]
      public virtual global::CovidDoc.Model.AppUser SignatoryUser { get; set; }

      /// <summary>
      /// Required
      /// </summary>
      [Display(Name="Подписанный документ")]
      public virtual global::CovidDoc.Model.Document Document { get; set; }

   }
}

