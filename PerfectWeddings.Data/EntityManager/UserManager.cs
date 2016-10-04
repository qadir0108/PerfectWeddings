using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using PerfectWeddings.Data.Entities;
using PerfectWeddings.Data;
using PerfectWeddings.Enums;
using PerfectWeddings.Common;

namespace PerfectWeddings.Data.EntityManager
{
    public class UserManager : BaseEntityManager<User>
    {
        public UserManager()
        {

        }

        public UserLoginStatusEnum Authenticate(string UserName, string Password)
        {
            var user = GetAll().FirstOrDefault(x => x.UserName.Equals(UserName, StringComparison.InvariantCultureIgnoreCase));
            if (user == null) return UserLoginStatusEnum.NotFound;

            if (user.Status == UserStatusEnum.Expired) return UserLoginStatusEnum.Expired;

            var decryptedPassword = Encryption.Decrypt(user.Password);

            if (decryptedPassword.Equals(Password, StringComparison.InvariantCultureIgnoreCase)
                        && user.Status == UserStatusEnum.Active)
                return UserLoginStatusEnum.Authenticated;
            else
                return UserLoginStatusEnum.NotAuthenticated;
        }
    }
}
