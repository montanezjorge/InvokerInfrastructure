namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using global::Invoker.Infrastructure;
    using System.Linq;
    using System.Threading.Tasks;

    public class CipherBlockChaining : InvokerMemberBase<CryptoOperationDto, CryptoOperationDto>
    {
        protected override async Task<CryptoOperationDto> Invoke(CryptoOperationDto param)
        {
            param.InputBlock = param.Plaintext.Skip(param.BlockIteration * Constants.AES_BLOCK_SIZE).Take(Constants.AES_BLOCK_SIZE).ToArray();
            param.InputBlock = param.InputBlock.Zip(param.IV, (b1, b2) => (byte)(b1 ^ b2)).ToArray();
            
            return param;
        }
    }
}
