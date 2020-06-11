using Microsoft.AspNetCore.Http;

namespace Sicle.Logs.Util
{
    public static class SessionVariables
    {
        private static IHttpContextAccessor m_httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            m_httpContextAccessor = httpContextAccessor;
        }

        public static HttpContext Current
        {
            get{
                return m_httpContextAccessor.HttpContext;
            }
        }


        public static int? UserId
        {
            get {
                return Current.Session.GetInt32("UserId");
            }

            set {
                Current.Session.SetInt32("UserId", value.Value);
            }
        } 

        public static string UserCode
        {
            get {
                return Current.Session.GetString("UserCode");
            }

            set {
                Current.Session.SetString("UserCode", value);
            }
        }
    }
}