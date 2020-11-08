using System;

namespace Almotkaml.Attributes
{
    public class PhraseAttribute : ResourceBasedAttribute
    {
        public PhraseAttribute(Type type, string name) : base(type)
        {
            Display = ResourceType.GetString(name);
        }

        public override string Display { get; }
    }
}