using System.DirectoryServices.Protocols;

namespace ApuStore
{
    public class DirectoryLoginService
    {
        public static bool LdapAuth(string username, string pwd, bool skipAd)
        {
            bool result = true;
            if (!skipAd) {
                System.Net.NetworkCredential credentials = new(username, pwd, "asispa1.es");
                LdapDirectoryIdentifier serverId = new("asispa1.es");
                using (var connection = new LdapConnection(serverId, credentials))
                {
                    try
                    {
                        connection.Bind();
                    }
                    catch
                    {
                        result = false;
                    }
                }
            }
            return result;
        }
    }
}
