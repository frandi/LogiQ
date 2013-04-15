using LogiQ.Helpers;
using LogiQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogiQ
{
    public static class LogiQWebSecurity
    {
        public static string CreateUserAndAccount(string userName, string password, string email, bool requireConfirmationToken = false)
        {
            return WebMatrix.WebData.WebSecurity.CreateUserAndAccount(userName, password, new { Email = email }, requireConfirmationToken);
        }

        public static IEnumerable<MembershipUser> GetAllUsers()
        {
            IList<MembershipUser> mUsers = new List<MembershipUser>();

            LogiQContext db = new LogiQContext();
            var profiles = db.UserProfiles.OrderBy(u => u.UserName).ToList();
            foreach (var profile in profiles)
            {
                MembershipUser mUser = new MembershipUser();
                mUser.UserId = profile.UserId;
                mUser.UserName = profile.UserName;
                mUser.FirstName = profile.FirstName;
                mUser.LastName = profile.LastName;
                mUser.Email = profile.Email;
                mUser.Phone = profile.Phone;
                mUser.Roles = System.Web.Security.Roles.GetRolesForUser(profile.UserName);

                mUsers.Add(mUser);
            }

            return mUsers;
        }

        public static MembershipUser GetUser(string userName)
        {
            MembershipUser user = null;

            if (WebMatrix.WebData.WebSecurity.UserExists(userName))
            {
                user = new MembershipUser();

                LogiQContext db = new LogiQContext();
                UserProfile profile = db.UserProfiles.Where(u => u.UserName == userName).FirstOrDefault();
                user.UserId = profile.UserId;
                user.UserName = profile.UserName;
                user.FirstName = profile.FirstName;
                user.LastName = profile.LastName;
                user.Email = profile.Email;
                user.Phone = profile.Phone;
                user.Roles = System.Web.Security.Roles.GetRolesForUser(userName);
            }
            
            return user;
        }

        public static int GetCurrentUserId()
        {
            return WebMatrix.WebData.WebSecurity.CurrentUserId;
        }

        public static bool IsCurrentUserAuthenticated()
        {
            return WebMatrix.WebData.WebSecurity.IsAuthenticated;
        }

        public static bool Login(string userName, string password, bool persistCookie = false)
        {
            return WebMatrix.WebData.WebSecurity.Login(userName, password, persistCookie);
        }

        public static void UpdateUser(MembershipUser user)
        {
            if (user != null)
            {
                LogiQContext db = new LogiQContext();
                UserProfile profile = db.UserProfiles.Where(u => u.UserName == user.UserName).FirstOrDefault();
                if (profile != null)
                {
                    profile.FirstName = user.FirstName;
                    profile.LastName = user.LastName;
                    profile.Email = user.Email;
                    profile.Phone = user.Phone;

                    db.SaveChanges();

                    string[] currentRoles = System.Web.Security.Roles.GetRolesForUser(user.UserName);
                    if (RolesChanged(currentRoles, user.Roles))
                    {
                        if(currentRoles.Length > 0)
                            System.Web.Security.Roles.RemoveUserFromRoles(user.UserName, currentRoles);

                        if(user.Roles.Length > 0)
                            System.Web.Security.Roles.AddUserToRoles(user.UserName, user.Roles);
                    }
                }
            }
        }

        public static bool RolesChanged(string[] currentRole, string[] newRole)
        {
            if (currentRole.Length != newRole.Length)
            {
                return true;
            }

            for (int i = 0; i < currentRole.Length; i++)
            {
                if (!newRole.Contains(currentRole[i]))
                    return true;
            }

            for (int i = 0; i < newRole.Length; i++)
            {
                if (!currentRole.Contains(newRole[i]))
                    return true;
            }

            return false;
        }
    }
}