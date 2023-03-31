namespace IdentidadeCultural.Compartilhado.Aplicacao.Atributos;

    [AttributeUsage(AttributeTargets.Class)]
    public class InjectionAttribute : Attribute
    {
        public Di Di { get; set; }

        public InjectionAttribute(Di di) => Di = di;
    }

    public enum Di
    {
        Scoped = 0,
        Transient = 1,
        Singleton = 2
    }

    public class JobAttribute : Attribute
    {

    }