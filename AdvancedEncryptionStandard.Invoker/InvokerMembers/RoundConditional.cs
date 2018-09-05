namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using global::Invoker.Infrastructure;
    using System.Threading.Tasks;

    public class RoundConditional : InvokerRepeatingMemberBase<CryptoOperationDto>
    {
        protected override async Task<bool> Invoke(CryptoOperationDto param)
        {
            param.AddRoundKeyIndex = (param.RoundIndex + 1) * 4;

            return param.RoundIndex < param.KeyWords + 6;
        }
    }
}
