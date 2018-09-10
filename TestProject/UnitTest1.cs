namespace TestProject
{
    using Invoker.Infrastructure;
    using Invoker.Infrastructure.Extensions;
    using Invoker.Infrastructure.Unity;
    using Microsoft.Practices.Unity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using MorseCode.ITask;
    using TestProject.ClassForTesting;
    using System;
    using AdvancedEncryptionStandard.Invoker;
    using Invoker.Infrastructure.BareBonesContainer;
    using AdvancedEncryptionStandard.Invoker.InvokerMembers;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestAESInvoker()
        {
            var aes = Aes.Create();
            aes.KeySize = 256;
            aes.GenerateKey();
            aes.GenerateIV();

            var encryptor = aes.CreateEncryptor();

            var ciphertext = new byte[16];
            encryptor.TransformBlock(new byte[16], 0, 16, ciphertext, 0);

            var pedagogicalAES = new AES();
            
            var testCiphertext = await pedagogicalAES.EncryptAsync(new byte[16], aes.IV, aes.Key);

            Assert.AreEqual(Convert.ToBase64String(ciphertext), Convert.ToBase64String(testCiphertext));
        }

        [TestMethod]
        public async Task TestInvokerInfrastructure()
        {
            var unityContainer = new UnityContainer();
            var container = new UnityContainerWrapper(unityContainer);

            var configuration =
                new InvokerElement<ClassForTesting.Initializer>("Init")
                    .Invokes<LoopConditional>("Loop")
                        .InvokesMultiple(
                            new InvokerElement<If>("If").Invokes<IfLogic>("IfLogic"),
                            new InvokerElement<Else>("Else").Invokes<ElseLogic>("ElseLogic"))
                        .Invokes<Return>();

            container.RegisterInvoker<string>(configuration);
            var invoker = container.Resolve<IInvoker<string>>();

            await invoker.Invoke(Task.FromResult("HelloWorld!").AsITask());
        }

        [TestMethod]
        public async Task TestAESInvokerEncryption()
        {
            var aes = Aes.Create();
            aes.KeySize = 256;
            aes.GenerateKey();
            aes.GenerateIV();

            var encryptor = aes.CreateEncryptor();

            var ciphertext = new byte[16];
            encryptor.TransformBlock(new byte[16], 0, 16, ciphertext, 0);

            var key = aes.Key;
            var iv = aes.IV;

            var container = new Container();
            var encryptionConfiguration =
                new InvokerElement<AdvancedEncryptionStandard.Invoker.InvokerMembers.Initializer>("Initializer")
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
            var invoker = container.Resolve<IInvoker<(byte[] plaintext, byte[] iv, byte[] key), byte[]>>();

            var testCiphertext = await invoker.Invoke(Task.FromResult((new byte[16], iv, key)).AsITask());

            Assert.AreEqual(Convert.ToBase64String(ciphertext), Convert.ToBase64String(testCiphertext));
        }
    }
}
