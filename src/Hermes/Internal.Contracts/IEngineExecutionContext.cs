using System;

namespace Hermes.Internal.Contracts
{
    internal interface IEngineExecutionContext
    {
        void Initialize(Action work);
        void Execute(Action work);
    }
}