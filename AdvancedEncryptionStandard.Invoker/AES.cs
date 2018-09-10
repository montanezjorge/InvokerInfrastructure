using AdvancedEncryptionStandard.Invoker.InvokerMembers;
using Invoker.Infrastructure;
using Invoker.Infrastructure.BareBonesContainer;
using Invoker.Infrastructure.Extensions;
using Invoker.Infrastructure.Unity;
using Microsoft.Practices.Unity;
using System.Threading.Tasks;

namespace AdvancedEncryptionStandard.Invoker
{
    public class AES
    {
        private CryptoTransform transform;

        private static readonly IContainer Container;

        static AES()
        {
            //var underlyingContainer = new UnityContainer();
            //Container = new UnityContainerWrapper(underlyingContainer);
            Container = new Container();
            RegisterAESImplementation(Container);
        }

        public CryptoTransform Transform
        {
            get
            {
                if (transform == null)
                {
                    transform = Container.Resolve<CryptoTransform>();
                }

                return transform;
            }
        }

        public async Task<byte[]> EncryptAsync(byte[] plaintext, byte[] iv, byte[] key)
        {
            return await Transform.EncryptAsync(plaintext, iv, key);
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
