# InvokerInfrastructure
Pedagogical C# framework, akin to functional programming.  
It provides a way of bulding a program as a tree of tasks. 

As an example, what follows is the specification of the encrypt operation of the AES algorithm in this framework:

```
var encryptionConfiguration =
    new InvokerElement<Initializer>("Initializer")
        .Invokes<BlockLoop>("BlockLoop")
            .Invokes<CipherBlockChaining>("CBC")
                .Invokes(
                    new InvokerElement<InputBlockToStateMatrix>("StateMapper"),
                    new InvokerElement<CopyKeyIntoKeySchedule>("KeyScheduleInit"),
                    new InvokerElement<ComputeKeyScheduleConditional>("KeyScheduleLoop")
                            .Invokes(new InvokerElement<ComputeKeyScheduleLogic>("KeyScheduleLogic")
                                .Invokes(
                                    new InvokerElement<IsEven>("KeyScheduleConditional")
                                        .Invokes<RotateWord>("RotateWord")
                                        .Invokes<SubWord>("SubWord1")
                                        .Invokes<ShiftRoundConstant>("ShiftRoundConstant"),
                                    new InvokerElement<Is256BitKey>("KeySchedule256BitKeyConditional")
                                        .Invokes<SubWord>("SubWord2"),
                                    new InvokerElement<XOrWithPrevious>("KeyScheduleComplete"))),
                    new InvokerElement<AddRoundKey>("RoundKey1"),
                    new InvokerElement<RoundConditional>("RoundConditional")
                            .Invokes(
                                new InvokerElement<SubBytes>("SubBytes"),
                                new InvokerElement<ShiftRows>("ShiftRows"),
                                new InvokerElement<IfNotLastRound>("IfNotLastRound").Invokes<MixColumns>("MixColumns"),
                                new InvokerElement<AddRoundKey>("RoundKey2").Invokes<IncrementIndex>("IncrementIndex")),
                    new InvokerElement<StateToOutputBlock>("StateToOutputBlock"),
                new InvokerElement<ResultBuilder>("Result"));
```
