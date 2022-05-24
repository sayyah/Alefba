namespace Alefba.Domain
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DocumentName : Attribute
    {
        public string Name { get; set; }
    }
}
