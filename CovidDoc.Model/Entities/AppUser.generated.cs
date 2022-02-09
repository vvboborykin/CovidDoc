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
   /// Пользователь приложения
   /// </summary>
   [System.ComponentModel.Description("Пользователь приложения")]
   public partial class AppUser
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected AppUser()
      {
         Disabled = false;
         Roles = new System.Collections.Generic.HashSet<global::CovidDoc.Model.AppRole>();
         CreatedDocuments = new System.Collections.Generic.HashSet<global::CovidDoc.Model.Document>();
         Signatures = new System.Collections.Generic.HashSet<global::CovidDoc.Model.Signature>();
         CreatedItems = new System.Collections.Generic.HashSet<global::CovidDoc.Model.ReferralItem>();

         Init();
      }

      /// <summary>
      /// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      /// </summary>
      public static AppUser CreateAppUserUnsafe()
      {
         return new AppUser();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="username"></param>
      /// <param name="password"></param>
      /// <param name="fio"></param>
      /// <param name="disabled"></param>
      /// <param name="organization"></param>
      /// <param name="_document0"></param>
      public AppUser(string username, string password, string fio, global::CovidDoc.Model.Organization organization, global::CovidDoc.Model.Document _document0, bool disabled = false)
      {
         if (string.IsNullOrEmpty(username)) throw new ArgumentNullException(nameof(username));
         this.UserName = username;

         if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));
         this.Password = password;

         if (string.IsNullOrEmpty(fio)) throw new ArgumentNullException(nameof(fio));
         this.Fio = fio;

         this.Disabled = disabled;

         if (organization == null) throw new ArgumentNullException(nameof(organization));
         this.Organization = organization;
         organization.AppUsers.Add(this);

         if (_document0 == null) throw new ArgumentNullException(nameof(_document0));
         _document0.ModifiedByUser.Add(this);

         Roles = new System.Collections.Generic.HashSet<global::CovidDoc.Model.AppRole>();
         CreatedDocuments = new System.Collections.Generic.HashSet<global::CovidDoc.Model.Document>();
         Signatures = new System.Collections.Generic.HashSet<global::CovidDoc.Model.Signature>();
         CreatedItems = new System.Collections.Generic.HashSet<global::CovidDoc.Model.ReferralItem>();
         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="username"></param>
      /// <param name="password"></param>
      /// <param name="fio"></param>
      /// <param name="disabled"></param>
      /// <param name="organization"></param>
      /// <param name="_document0"></param>
      public static AppUser Create(string username, string password, string fio, global::CovidDoc.Model.Organization organization, global::CovidDoc.Model.Document _document0, bool disabled = false)
      {
         return new AppUser(username, password, fio, organization, _document0, disabled);
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
      [Display(Name="Логическое имя")]
      public string UserName { get; set; }

      /// <summary>
      /// Required, Max length = 255
      /// </summary>
      [Required]
      [MaxLength(255)]
      [StringLength(255)]
      [Display(Name="Пароль")]
      public string Password { get; set; }

      /// <summary>
      /// Required, Max length = 255
      /// </summary>
      [Required]
      [MaxLength(255)]
      [StringLength(255)]
      [Display(Name="Фио пользователя")]
      public string Fio { get; set; }

      [Display(Name="Код сотрудника в СМСО")]
      public int? SmsoPersonId { get; set; }

      /// <summary>
      /// Required, Default value = false
      /// </summary>
      [Required]
      [Display(Name="Вход запрещен")]
      public bool Disabled { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

      [Display(Name="Роли исполняемые пользователем")]
      public virtual ICollection<global::CovidDoc.Model.AppRole> Roles { get; private set; }

      [Display(Name="Документы созданные пользователем")]
      public virtual ICollection<global::CovidDoc.Model.Document> CreatedDocuments { get; private set; }

      [Display(Name="Проставленные подписи")]
      public virtual ICollection<global::CovidDoc.Model.Signature> Signatures { get; private set; }

      [Display(Name="Созданные элементы")]
      public virtual ICollection<global::CovidDoc.Model.ReferralItem> CreatedItems { get; private set; }

      /// <summary>
      /// Required
      /// </summary>
      [Display(Name="Место работы")]
      public virtual global::CovidDoc.Model.Organization Organization { get; set; }

   }
}
