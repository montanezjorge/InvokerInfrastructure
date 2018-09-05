namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using System.Threading.Tasks;
    using global::Invoker.Infrastructure;

    public class BlockLoop : InvokerRepeatingMemberBase<CryptoOperationDto>
    {
        protected override async Task<bool> Invoke(CryptoOperationDto param)
        {
            return param.BlockIteration < param.Plaintext.Length / Constants.AES_BLOCK_SIZE;
        }
    }
}
