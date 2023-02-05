using System.Diagnostics.CodeAnalysis;

namespace DesignPatterns.Behavioral.TemplateMethod
{
    public abstract class ModuleBase<T> where T : IStuff, new()
    {
        [AllowNull]
        protected T Stuff { get; private set; }

        public T Start()
        {
            this.Stuff = new T();

            this.DoFirstThing();
            this.DoSecondThing();

            return this.Stuff;
        }

        protected abstract void DoFirstThing();

        protected abstract void DoSecondThing();
    }
}