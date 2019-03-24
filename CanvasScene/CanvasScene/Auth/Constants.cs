using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasScene.Auth
{
    public class Constants
    {
        public const string Issuer = "CanvasScene";

        public const string Audience = "CanvasSceneFront";

        public const string SecretKey = "TotallySecretKey";


        public static byte[] GetKey()
        {
            return Encoding.ASCII.GetBytes(SecretKey);
        }
    }
}
