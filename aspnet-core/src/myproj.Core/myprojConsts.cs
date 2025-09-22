using myproj.Debugging;

namespace myproj
{
    public class myprojConsts
    {
        public const string LocalizationSourceName = "myproj";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "fcce37bbabda43658add67776b6287c1";
    }
}
