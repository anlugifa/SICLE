using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace Sicle.Web.Util
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
    }
}