namespace AspNetCoreH5Examples.Codes
{
    public interface IHashingExamples
    {
        public string MD5Hash(string valueToHash);
        public string BcryptHash(string valueToHash);
    }
}
