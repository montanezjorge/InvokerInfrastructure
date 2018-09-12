using AdvancedEncryptionStandard.Invoker.InvokerMembers;
using Invoker.Infrastructure;
using Invoker.Infrastructure.BareBonesContainer;
using Invoker.Infrastructure.Extensions;
using System.Threading.Tasks;
using MorseCode.ITask;

namespace AdvancedEncryptionStandard.Invoker
{
    public class AES
    {
        private IInvoker<(byte[] plaintext, byte[] iv, byte[] key), byte[]> transform;

        private static readonly IContainer Container;

        static AES()
        {
            Container = new Container();
            RegisterAESImplementation(Container);
        }

        private IInvoker<(byte[] plaintext, byte[] iv, byte[] key), byte[]> Transform
        {
            get
            {
                if (transform == null)
                {
                    transform = Container.Resolve<IInvoker<(byte[] plaintext, byte[] iv, byte[] key), byte[]>>();
                }

                return transform;
            }
        }

        public async Task<byte[]> EncryptAsync(byte[] plaintext, byte[] iv, byte[] key)
        {
            return await Transform.Invoke(Task.FromResult((plaintext, iv, key)).AsITask());
        }

        private static void RegisterAESImplementation(IContainer container)
        {
            var encryptionConfiguration =
                new InvokerElement<Initializer>("Initializer")
                    .Invokes<BlockLoop>("BlockLoop")
                        .Invokes<CipherBlockChaining>("CBC")
                            .InvokesMultiple(
                                new InvokerElement<InputBlockToStateMatrix>("StateMapper"),
                                new InvokerElement<CopyKeyIntoKeySchedule>("KeyScheduleInit"),
                                new InvokerElement<ComputeKeyScheduleConditional>("KeyScheduleLoop")
                                        .InvokesMultiple(new InvokerElement<ComputeKeyScheduleLogic>("KeyScheduleLogic")
                                            .InvokesMultiple(
                                                new InvokerElement<IsEven>("KeyScheduleConditional")
                                                    .Invokes<RotateWord>("RotateWord")
                                                    .Invokes<SubWord>("SubWord1")
                                                    .Invokes<ShiftRoundConstant>("ShiftRoundConstant"),
                                                new InvokerElement<Is256BitKey>("KeySchedule256BitKeyConditional")
                                                    .Invokes<SubWord>("SubWord2"),
                                                new InvokerElement<XOrWithPrevious>("KeyScheduleComplete"))),
                                new InvokerElement<AddRoundKey>("RoundKey1"),
                                new InvokerElement<RoundConditional>("RoundConditional")
                                        .InvokesMultiple(
                                            new InvokerElement<SubBytes>("SubBytes"),
                                            new InvokerElement<ShiftRows>("ShiftRows"),
                                            new InvokerElement<IfNotLastRound>("IfNotLastRound").Invokes<MixColumns>("MixColumns"),
                                            new InvokerElement<AddRoundKey>("RoundKey2").Invokes<IncrementIndex>("IncrementIndex")),
                                new InvokerElement<StateToOutputBlock>("StateToOutputBlock"),
                            new InvokerElement<ResultBuilder>("Result"));


            container.RegisterInvoker<(byte[] plaintext, byte[] iv, byte[] key), byte[]>(encryptionConfiguration);
        }
    }
}
