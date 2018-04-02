using System;

namespace ThreadHandling
{
    public static class ConfigHelper
    {
        public static string BooksApiBaseUri => System.Configuration.ConfigurationManager.AppSettings["BooksApiBaseUri"];
    }
}
