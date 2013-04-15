using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LogiQ.Models
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }

    [Table("webpages_Roles")]
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [StringLength(256)]
        public string RoleName { get; set; }
        public virtual ICollection<UserProfile> Users { get; set; }
    }

    [Table("webpages_OAuthMembership")]
    public class OAuthMembership
    {
        [Key, Column(Order = 0), StringLength(30)]
        public string Provider { get; set; }
        [Key, Column(Order = 1), StringLength(100)]
        public string ProviderUserId { get; set; }
        public int UserId { get; set; }
    }

    [Table("webpages_Membership")]
    public class Membership
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        [StringLength(128)]
        public string ConfirmationToken { get; set; }
        public bool? IsConfirmed { get; set; }
        public DateTime? LastPasswordFailureDate { get; set; }
        public int PasswordFailuresSinceLastSuccess { get; set; }
        [Required, StringLength(128)]
        public string Password { get; set; }
        public DateTime? PasswordChangedDate { get; set; }
        [Required, StringLength(128)]
        public string PasswordSalt { get; set; }
        [StringLength(128)]
        public string PasswordVerificationToken { get; set; }
        public DateTime? PasswordVerificationTokenExpirationDate { get; set; }
    }

    #region View Models

    public class MembershipUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }

        public string FullName
        {
            get
            {
                string fullName = "";

                if (!string.IsNullOrEmpty(FirstName))
                {
                    fullName = FirstName;
                }

                if (!string.IsNullOrEmpty(LastName))
                {
                    if (!string.IsNullOrEmpty(fullName))
                        fullName += " ";
                    fullName += LastName;
                }

                if (string.IsNullOrEmpty(fullName))
                    fullName = UserName;

                return fullName;
            }
        }
    }

    #endregion View Models
}