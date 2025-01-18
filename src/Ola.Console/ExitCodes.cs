namespace Ola.Console
{
    public static class ExitCodes
    {
        public const int Success = 0;
        public const int UnknownFeature = 1;
        public const int UnknownCommand = 2;
        public const int ScriptFileDoesNotExists = 3;
        public const int BlockMismatch = 4;
        public const int Error = 5;
        public const int ShouldBeOlaScript = 6;
        public const int MissingBankingService = 7;
    }
}