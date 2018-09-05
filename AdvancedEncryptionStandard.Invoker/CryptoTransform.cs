namespace AdvancedEncryptionStandard.Invoker
{
    using System.Threading.Tasks;
    using global::Invoker.Infrastructure;
    using MorseCode.ITask;

    public class CryptoTransform
    {
        private readonly IInvoker<(byte[] plaintext, byte[] iv, byte[] key), byte[]> encryptionInvoker;

        public CryptoTransform(IInvoker<(byte[] plaintext, byte[] iv, byte[] key), byte[]> encryptionInvoker)
        {
            this.encryptionInvoker = encryptionInvoker;
        }

        public async Task<byte[]> EncryptAsync(byte[] plaintext, byte[] iv, byte[] key)
        {
            return await encryptionInvoker.Invoke(Task.FromResult((plaintext, iv, key)).AsITask());
        }
    }
}
