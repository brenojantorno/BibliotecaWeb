using System.Text;
namespace BibliotecaWeb.Security
{
    public static class SecuritySettings
    {
        private static string Secret = "F9327F9D21F97C2171CF06D8E79F8054";
        public static byte[] KeyEncoding => Encoding.ASCII.GetBytes(Secret);
    }
}