namespace AdvancedEncryptionStandard.Invoker.InvokerMembers
{
    using System.Threading.Tasks;
    using global::Invoker.Infrastructure;
    public class ShiftRows : InvokerMemberBase<CryptoOperationDto, CryptoOperationDto>
    {
        protected override async Task<CryptoOperationDto> Invoke(CryptoOperationDto param)
        {
            var tmp = param.State[1, 0];
            param.State[1, 0] = param.State[1, 1];
            param.State[1, 1] = param.State[1, 2];
            param.State[1, 2] = param.State[1, 3];
            param.State[1, 3] = tmp;

            tmp = param.State[2, 0];
            param.State[2, 0] = param.State[2, 2];
            param.State[2, 2] = tmp;

            tmp = param.State[2, 1];
            param.State[2, 1] = param.State[2, 3];
            param.State[2, 3] = tmp;

            tmp = param.State[3, 3];
            param.State[3, 3] = param.State[3, 2];
            param.State[3, 2] = param.State[3, 1];
            param.State[3, 1] = param.State[3, 0];
            param.State[3, 0] = tmp;

            return param;
        }
    }
}
