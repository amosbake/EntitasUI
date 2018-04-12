public class TutorialSystems : Feature
{
    public TutorialSystems(Contexts contexts) : base("TutorialSystems")
    {
        Add(new DebugMessageSystem(contexts.game));
        Add(new TickUpdateSystem(contexts.game));
        Add(new NotifyTickListenerSystem(contexts.game));
    }
}