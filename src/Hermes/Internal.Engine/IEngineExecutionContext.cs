using System;

namespace Hermes.Internal.Engine
{
    internal interface IEngineExecutionContext
    {
        void Initialize(Action work);
        void Execute(Action work);
    }
}