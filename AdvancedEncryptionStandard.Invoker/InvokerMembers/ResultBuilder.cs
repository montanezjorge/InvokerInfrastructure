namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using global::Invoker.Infrastructure;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class ResultBuilder : InvokerMemberBase<CryptoOperationDto, byte[]>
    {
        protected override async Task<byte[]> Invoke(CryptoOperationDto param)
        {
            Array.Copy(param.OutputBlock, param.IV, param.OutputBlock.Length);
            param.Ciphertext = param.Ciphertext.Concat(param.OutputBlock).ToArray();
            param.BlockIteration++;

            return param.Ciphertext;
        }
    }
}
