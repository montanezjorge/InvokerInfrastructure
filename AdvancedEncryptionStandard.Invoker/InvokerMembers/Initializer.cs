namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using System;
    using System.Threading.Tasks;
    using global::Invoker.Infrastructure;

    public class Initializer : InvokerMemberBase<(byte[] plaintext, byte[] iv, byte[] key), CryptoOperationDto>
    {
        protected override async Task<CryptoOperationDto> Invoke((byte[] plaintext, byte[] iv, byte[] key) param)
        {
            var ivCopy = new byte[param.iv.Length];

            Array.Copy(param.iv, ivCopy, param.iv.Length);

            return new CryptoOperationDto
            {
                BlockIteration = 0,
                IV = ivCopy,
                Key = param.key,
                Ciphertext = new byte[0],
                Plaintext = param.plaintext,
                KeyWords = param.key.Length >> 2,
                KeyScheduleIndex = param.key.Length >> 2,
                RoundIndex = 0,
                OutputBlock = new byte[16]
            };
        }
    }
}
