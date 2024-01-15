using System;
using System.Threading.Tasks;
using Autodesk.Forge;

namespace CloudAPISample.Forge
{
    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        /// <summary>
        /// 
        /// 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<User> GetUserProfileAsync()
        {
            string userAccessToken = ThreeLeggedToken.GetToken();

            UserProfileApi userProfileApi = new UserProfileApi();
            userProfileApi.Configuration.AccessToken = userAccessToken;
            try
            {
                dynamic user = await userProfileApi.GetUserProfileAsync();
                User curUser = new User();
                curUser.FirstName = user.firstName;
                curUser.LastName = user.lastName;

                return curUser;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }


    }
}
